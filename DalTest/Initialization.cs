using DO;
using DalApi;

namespace DalTest;

public static class Initialization
{
    private static IDal s_dal;
    private static List<int> productCodes = new List<int>();
    private static void createProducts()
    {
        productCodes.Add(s_dal.Product.Create(new Product(0, "Gold Necklace", CategoryProduct.Necklaces, 150, 50)));
        productCodes.Add(s_dal.Product.Create(new Product(1, "Silver Bracelet", CategoryProduct.Bracelets, 75, 100)));
        productCodes.Add(s_dal.Product.Create(new Product(2, "Diamond Ring", CategoryProduct.Rings, 300, 30)));
        productCodes.Add(s_dal.Product.Create(new Product(3, "Pearl Earrings", CategoryProduct.Earrings, 120, 20)));
        productCodes.Add(s_dal.Product.Create(new Product(4, "Luxury Watch", CategoryProduct.Watches, 500, 10)));
    }

    private static void createSales()
    {
        s_dal.Sale.Create(new Sale(0,productCodes[0],5,4,false,DateTime.Now, DateTime.Now.AddDays(5)));
        s_dal.Sale.Create(new Sale(0,productCodes[1], 2, 10.5, false, DateTime.Now, DateTime.Now.AddDays(8)));
        s_dal.Sale.Create(new Sale(0,productCodes[2], 12, 20, false, DateTime.Now, DateTime.Now.AddDays(3)));
        s_dal.Sale.Create(new Sale(0,productCodes[3],5, 6.5, false, DateTime.Now, DateTime.Now.AddDays(2)));
        s_dal.Sale.Create(new Sale(0,productCodes[4], 2, 10, false, DateTime.Now, DateTime.Now.AddDays(4)));
    }
    private static void createCustomers()
    {
        s_dal.Customer.Create(new Customer(123456789,"tamar","mesilat yossef","0556775210"));
        s_dal.Customer.Create(new Customer(234567891, "gila", "netivot hamishpat", "0553896745"));
        s_dal.Customer.Create(new Customer(345678912, "rivki", "rabi hakiva", "0556777251"));
        s_dal.Customer.Create(new Customer(456789123, "tova", "mesilat yossef", "0541236498"));
        s_dal.Customer.Create(new Customer(567891234, "shalom", "mesilat yesharim", "0529873612"));
    }
    public static void initialize()
    {
        s_dal = Factory.Get; 
        createCustomers();  
        createProducts();
        createSales();
    }


}
