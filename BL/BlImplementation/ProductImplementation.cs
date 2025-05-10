

using BO;
using DO;
using static BO.Tools;
namespace BlImplementation;

internal class ProductImplementation : BlApi.IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Product item)
    {
        try
        {
            if (item == null)
            {
                throw new ArgumentNullException("לא נשלח מוצר לעדכון");
            }
            DO.Product Product = item.CastProductBOtoDO();
            return _dal.Product.Create(Product);
        }
        catch (DO.DalIdExistExeption e)
        {
            throw new BO.BlIdExistExeption("", e);
        }
    }

    public void Delete(int id)
    {
        try
        {
            var product = _dal.Product.Read(id);
            if (product == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר למחוק מוצר לא קיים.");
            }
            _dal.Product.Delete(id);
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }


    public BO.Product? Read(int id)
    {
        try
        {
            DO.Product product = _dal.Product.Read(id);
            if (product == null)
            {
                throw new BO.BlNullObjectExeption("לא נמצא מוצר עם קוד זה");
            }
            BO.Product productBO = product.CastProductDOToBO();
            productBO.ListSaleInProduct = GetActiveSales(productBO.Id, true, productBO.Amount ?? 0);
            return productBO;
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        try
        {
            if (filter == null)
                throw new BO.BlNullObjectExeption("לא נשלח פרמטר לסינון");
             List<DO.Product?> list = _dal.Product.ReadAll();

             DO.Product? product = list.SingleOrDefault<DO.Product>(p => filter(p.CastProductDOToBO()));

            if (product == null)
                throw new BO.BlNullObjectExeption("לא נמצא מוצר עם סינון זה");
            BO.Product productBO = product.CastProductDOToBO();
            productBO.ListSaleInProduct = GetActiveSales(productBO.Id,true, productBO.Amount ?? 0);
            return productBO;
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter = null)
    {
        try
        {
            List<DO.Product?> listDO = _dal.Product.ReadAll();

            List<BO.Product?> listBO;

            if (filter == null)
            {
                listBO = (from c in listDO
                          select c.CastProductDOToBO()).ToList();
            }
            else
            {
                listBO = (from c in listDO
                          let bo = c.CastProductDOToBO()
                          where filter(bo)
                          select bo).ToList();
            }

            foreach (var product in listBO)
            {
                product.ListSaleInProduct=GetActiveSales(product.Id, true, product.Amount ?? 0);
            }

            return listBO;
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }


    public void Update(BO.Product item)
    {
        try
        {
            if (item == null)
            {
                throw new ArgumentNullException("לא נשלח מוצר לעדכון");
            }
            int id = item.Id;

            var p = _dal.Product.Read(id);

            if (p == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר למחוק מוצר לא קיים.");
            }

            _dal.Product.Update(item.CastProductBOtoDO());
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }
    public List<BO.SaleInProduct> GetActiveSales(int id, bool isPreferred,int amount)
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
                                                          where s.StartSaleDate <= DateTime.Now && s.LastSaleDate > DateTime.Now && amount>=s.MinAmountSale
                                                          select new BO.SaleInProduct(s.IdSaleP, s.MinAmountSale, s.FainalPrice, s.IsOnlyClub)).ToList();
            return listSaleInProductBO.OrderBy(p => p.Price / p.Amount).ToList();

        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }
}
