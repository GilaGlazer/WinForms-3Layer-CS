
using DO;
using DalApi;
using System.Reflection;
using Tools;

namespace Dal;


internal class ProductImplementation : IProduct
{
    public int Create(Product item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create in product");
        Product p = item with { Id =DataSource.Config.CodeProduct };
        DataSource.products.Add(p);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end create in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return p.Id;
    }

    public Product? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in product");
        var q = from item in DataSource.products
                where item.Id==id
                select item;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return q.First();


    }

    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in product");
        var q = from item in DataSource.products
                where filter(item)
                select item;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return q.First();

    }
    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in product");
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return new List<Product>(DataSource.products);
      
    }
    public void Update(Product item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update in product");
        Delete(item.Id);
        DataSource.products.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end update in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);

    }
    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete in product");
        Product? p = Read(id);
        DataSource.products.Remove(p);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end delete in product");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
    }
}
