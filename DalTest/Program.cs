using DO;
using DalApi;
using Dal;
using Tools;
using System.Reflection;

namespace DalTest;

internal class Program
{
    private static IDal s_dal = Factory.Get;
    private static void Main(string[] args)
    {
        try
        {
            Initialization.initialize();
            int select = -1;
            while (select != 0)
            {
                select = PrintMainMenu();
                switch (select)
                {
                    case 0:
                        break;
                    case 1:
                        CustomerMenu();
                        break;
                    case 2:
                        SaleMenu();
                        break;
                    case 3:
                        ProductMenu();
                        break;
                    case 4:
                        LogManager.DeleteLogContent();
                        break;
                    default:
                        Console.WriteLine("error, please print again");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e.Message);
        }

    }
    public static void CustomerMenu()
    {
        try
        {
            int select2 = -1;
            while (select2 != 0)
            {
                select2 = PrintSubMenu("customer");
                switch (select2)
                {
                    case 0:
                        break;
                    case 1:
                        CreateCustomer();
                        break;
                    case 2:
                        Read(s_dal.Customer);
                            break;
                    case 3:
                        ReadAll(s_dal.Customer);
                        break;
                    case 4:
                        UpdateCustomer();
                        break;
                    case 5:
                        Delete(s_dal.Customer);
                        break;
                    default:
                        Console.WriteLine("error, please print again");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e.Message);
        }
    }
    public static void CreateCustomer()
    {
        Customer c = inputDetailCustomer();
        s_dal.Customer.Create(c);
        Console.WriteLine(c);
    }
    public static Customer inputDetailCustomer()
    {
        Console.WriteLine("insert id,name ,address,phone");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
            return null;
        Customer c = new Customer(id, Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
        return c;
    }
    
    public static void UpdateCustomer()
    {
        Customer c = inputDetailCustomer();
        s_dal.Customer.Update(c);
    }
    //-------------SaleMenu-------------
    public static void SaleMenu()
    {
        try
        {
            int select2 = -1;
            while (select2 != 0)
            {
                select2 = PrintSubMenu("sale");
                switch (select2)
                {
                    case 0:
                        break;
                    case 1:
                        CreateSale();
                        break;
                    case 2:
                        Read(s_dal.Sale);
                        break;
                    case 3:
                        ReadAll(s_dal.Sale);
                        break;
                    case 4:
                        UpdateSale();
                        break;
                    case 5:
                        Delete(s_dal.Sale);
                        break;
                    default:
                        Console.WriteLine("error, please print again");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e.Message);
        }
    }
    public static void CreateSale()
    {
        Sale s = inputDetailSale();
        int code = s_dal.Sale.Create(s);
        s = s with { IdSale = code };
        Console.WriteLine(s);
    }
    public static Sale inputDetailSale()
    {
        Console.WriteLine("insert idSale idSaleP,minAmountSale, fainalPrice,isOnlyClub");
        int idSale, idSaleP, minAmountSale; 
        double fainalPrice;
        bool isOnlyClub;
        DateTime startSaleDate, lastSaleDate;
        if (!int.TryParse(Console.ReadLine(), out idSale))
            return null;
        if (!int.TryParse(Console.ReadLine(), out idSaleP))
            idSaleP= 0;
        if (!int.TryParse(Console.ReadLine(), out minAmountSale))
            minAmountSale = 0;
        if (!double.TryParse(Console.ReadLine(), out fainalPrice))
            fainalPrice= 0;
        if (!bool.TryParse(Console.ReadLine(), out isOnlyClub))
            isOnlyClub= false;
        Console.WriteLine("Please insert the startSaleDate, lastSaleDate in the following format: dd-MM-yyyy HH:mm");
        if (!DateTime.TryParse(Console.ReadLine(), out startSaleDate))
            startSaleDate = DateTime.Now;
        if (!DateTime.TryParse(Console.ReadLine(), out lastSaleDate))
            lastSaleDate = DateTime.Now.AddDays(7);
        Sale s= new Sale(idSale,idSaleP, minAmountSale, fainalPrice, isOnlyClub, startSaleDate, lastSaleDate);

        return s;
    }
    public static void UpdateSale()
    {
        Sale s = inputDetailSale();
        s_dal.Sale.Update(s);
    }

    //-----------------ProductMenu----------------------
    public static void ProductMenu()
    {
        try
        {
            int select2 = -1;
            while (select2 != 0)
            {
                select2 = PrintSubMenu("product");
                switch (select2)
                {
                    case 0:
                        break;
                    case 1:
                        CreateProduct();
                        break;
                    case 2:
                        Read(s_dal.Product);
                        break;
                    case 3:
                        ReadAll(s_dal.Product);
                        break;
                    case 4:
                        UpdateProduct();
                        break;
                    case 5:
                        Delete(s_dal.Product);
                        break;
                    default:
                        Console.WriteLine("error, please print again");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, e.Message);
            Console.WriteLine(e.Message);
        }
    }
    public static void CreateProduct()
    {
        Product p = inputDetailProduct();
        int code = s_dal.Product.Create(p);
        p = p with { Id = code };
        Console.WriteLine(p);
    }
    public static Product inputDetailProduct()
    {
        Console.WriteLine("insert id, nameProduct,category ,price,amount");
        int categoryInt, amount, id;
        Double price;
        if (!int.TryParse(Console.ReadLine(), out id))
            return null;
        if (!int.TryParse(Console.ReadLine(), out categoryInt))
            categoryInt=0;
        if (!Double.TryParse(Console.ReadLine(), out price))
            price = 0;
        if (!int.TryParse(Console.ReadLine(), out amount))
            amount = 0;
        Product p = new Product(id, Console.ReadLine(), (CategoryProduct)categoryInt, price, amount);
        return p;
    }

    public static void UpdateProduct()
    {
        Product p = inputDetailProduct();
        s_dal.Product.Update(p);
    }



    public static void ReadAll<T>(ICrud<T> icrud)
    {
        var q = from item in icrud.ReadAll()
                select item;
        Console.WriteLine(String.Join(' ', q.ToList()));
      
    }
    public static void Read<T>(ICrud<T> icrud)
    {
        Console.WriteLine("insert id");
        int id;
        if (int.TryParse(Console.ReadLine(), out id))
            Console.WriteLine(icrud.Read(id));
    }
    public static void Delete<T>(ICrud<T> icrud)
    {
        Console.WriteLine("insert id");
        int id ;
        if (int.TryParse(Console.ReadLine(), out id))
            icrud.Delete(id);
    }
    public static int PrintMainMenu()
    {
        Console.WriteLine("to customer press 1");
        Console.WriteLine("to sale press 2");
        Console.WriteLine("to product press 3");
        Console.WriteLine("to exit press 0");
        Console.WriteLine("to delete content directory log press 4");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            return -1;
        return select;
    }

    public static int PrintSubMenu(string item)
    {
        Console.WriteLine($"to creat {item} press 1");
        Console.WriteLine($"to read one {item} press 2");
        Console.WriteLine($"to read all {item} press 3");
        Console.WriteLine($"to update {item} press 4");
        Console.WriteLine($"to delete {item} press 5");
        Console.WriteLine("to exit out sub menu press 0");
        int select;
        if (!int.TryParse(Console.ReadLine(), out select))
            return -1;
        return select;
    }
   
}