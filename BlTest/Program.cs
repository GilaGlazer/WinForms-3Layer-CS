
using BO;
using DalApi;
using DO;

namespace BlTest;

internal class Program
{
    static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
    private static void Main(string[] args)
    {
        try
        {
           // int IsInitialize = PrintMainMenu("1 to initialize");
           // if (IsInitialize == 1)
           //איתחול
            //DalTest.Initialization.initialize();
            int customerID = PrintMainMenu("ID customer");
            if (customerID < 0)
            {
                throw new BO.BlInputNotCorrectExeption("input not correct");
            }
            int selectAddOrderOrExit = PrintMainMenu("1 for add order \n 0 for exit");
            while (selectAddOrderOrExit == 1)
            {
                Order myOrder = new Order();
                myOrder.IsPreferred = s_bl.ICustomer.IsExist(customerID);
                int selectAddProductOrFinishOrder = PrintMainMenu("1 for add product to order \n 0 for finish your order");
                while (selectAddProductOrFinishOrder==1)
                {
                    int productID = PrintMainMenu("product ID");
                    int amountProduct = PrintMainMenu("amount of the product in order");
                    if (productID == -1 || amountProduct <= 0)
                    {
                        throw new BO.BlInputNotCorrectExeption("input not correct");
                    }
                    List<BO.SaleInProduct> listSaleInProducts = s_bl.IOrder.AddProductToOrder(myOrder, productID,amountProduct, myOrder.IsPreferred ?? false);
                    // List<BO.SaleInProduct> listSaleInProducts = s_bl.IProduct.GetActiveSales(productID, true);
                    if (listSaleInProducts != null) 
                    {
                        //כבר הדפסנו בפונקציה ADDPRODUCT
                        //Console.WriteLine(string.Join(",", listSaleInProducts));
                    }
                    else
                    {
                        //Console.WriteLine("have no sale for this product");
                    }
                    //s_bl.IOrder.CalcTotalPrice(myOrder);
                    Console.WriteLine($"TotalPrice for this product: {myOrder.TotalPrice}");
                    selectAddProductOrFinishOrder = PrintMainMenu("1 for add product to order \n 0 for finish your order");
                }
                s_bl.IOrder.DoOrder(myOrder);
                selectAddOrderOrExit = PrintMainMenu("1 for add order \n 0 for exit");
            }

        }
        catch (BO.BlInputNotCorrectExeption e)
        {
            throw new BO.BlInputNotCorrectExeption("", e);
        }

    }
    public static int PrintMainMenu(string str)
    {
        Console.WriteLine($"Enter {str}");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            return -1;
        return select;
    }



}
