
using BlApi;
using BO;

namespace BlImplementation;

internal class OrderImplementation : BlApi.IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public List<BO.SaleInProduct> SearchSaleForProduct(int id, bool isPreferred, int amount)
    {
        try
        {
            List<DO.Sale?> sales = _dal.Sale.ReadAll();
            sales = (from s in sales
                     where s.IdSaleP == id
                     select s).ToList();
            if (!isPreferred)
            {
                sales = sales.FindAll(s => !(bool)s.IsOnlyClub);
            }
            List<BO.SaleInProduct> listSaleInProductBO = (from s in sales
                                                          where s.StartSaleDate <= DateTime.Now && s.LastSaleDate > DateTime.Now && amount >= s.MinAmountSale
                                                          select new BO.SaleInProduct(s.IdSaleP, s.MinAmountSale, s.FainalPrice, s.IsOnlyClub)).ToList();
            return listSaleInProductBO.OrderBy(p => p.Price / p.Amount).ToList();
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

   

    public void CalcTotalPriceForProduct(BO.ProductInOrder productInOrderBO)
    {
        try
        {
            if (productInOrderBO.ListSaleInProduct == null)
                productInOrderBO.ListSaleInProduct = new List<BO.SaleInProduct?>();

            // איפוס מחיר סופי
            productInOrderBO.FinalPrice = 0;

            int? count = productInOrderBO.Amount ?? 0;
            List<BO.SaleInProduct> activeSales = new List<BO.SaleInProduct>();

            // מיון המבצעים לפי מחיר ליחידה הכי משתלם
            var sortedSales = productInOrderBO.ListSaleInProduct
                .Where(s => s != null && s.Amount > 0)
                .OrderBy(s => (double)s.Price / s.Amount)
                .ToList();

            foreach (var sale in sortedSales)
            {
                if (count <= 0)
                    break;

                int applicableTimes = (int)(count / sale.Amount);
                if (applicableTimes > 0)
                {
                    productInOrderBO.FinalPrice += applicableTimes * sale.Price;
                    count -= applicableTimes * sale.Amount;
                    activeSales.Add(sale);
                }
            }

            // מחיר רגיל לשארית
            if (count > 0)
                productInOrderBO.FinalPrice += count * productInOrderBO.BasePrice;

            // שמירת רק המבצעים שיושמו
            productInOrderBO.ListSaleInProduct = activeSales;
        }
        catch (Exception e)
        {
            throw new Exception("שגיאה בחישוב מחיר למוצר: " + e.Message);
        }
    }



    public void CalcTotalPrice(BO.Order order)
    {
        try
        {
            order.TotalPrice = (from p in order.ListProductInOrder
                                select p.FinalPrice ?? 0).Sum();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    public List<BO.SaleInProduct?> AddProductToOrder(BO.Order order, int idProductToAdd, int amount, bool isPreferred)
    {
        try
        {
            if (order.ListProductInOrder == null)
                order.ListProductInOrder = new List<BO.ProductInOrder?>();
            if (amount == 0)
                throw new Exception("כמות שגויה");

            DO.Product productDO = _dal.Product.Read(idProductToAdd);
            BO.ProductInOrder productBO = order.ListProductInOrder.FirstOrDefault<BO.ProductInOrder>(p => p.IdProductInOrder == idProductToAdd);
            //אם אין עדין את המוצר בהזמנה נוסיף חדש
            if (productBO == null)
            {
                if (productDO == null)
                    throw new Exception("לא נמצא מוצר ");

                if (productDO.Amount >= amount)
                {
                    productBO = new BO.ProductInOrder(idProductToAdd, productDO.NameProduct, productDO.Price ?? 0, amount);
                    order.ListProductInOrder.Add(productBO);
                }
                else
                {
                    throw new Exception("אין במלאי");
                }
            }
            else
            {
                if (productBO.Amount + amount <= productDO.Amount)
                {
                    productBO.Amount += amount;
                }
                else
                {
                    throw new Exception("אין במלאי");
                }
            }
            productBO.ListSaleInProduct = SearchSaleForProduct(idProductToAdd, isPreferred, productBO.Amount ?? 0);

            CalcTotalPriceForProduct(productBO);
            CalcTotalPrice(order);
            // רשימת המבצעים שמומשו למוצר זה.
            foreach (var item in productBO.ListSaleInProduct)
            {
                Console.WriteLine(item);
                //Console.WriteLine($"IdSaleInProduct = {item.IdSaleInProduct}, Amount = {item.Amount}, Price = {item.Price}, IsSaleForAllCustomers = {item.IsSaleForAllCustomers}");

            }
            return productBO.ListSaleInProduct;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
            //return new List<BO.SaleInProduct>();
        }
    }

    public void DoOrder(BO.Order order)
    {
        try
        {
            foreach (var productInOrder in order.ListProductInOrder)
            {
                DO.Product productDO = _dal.Product.Read(productInOrder.IdProductInOrder);
                if (productDO == null)
                {
                    throw new Exception("שגיאה בתשלום הזמנה");
                }
                _dal.Product.Update(productDO with { Amount = productDO.Amount - productInOrder.Amount });
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


}
