
using DO;
using DalApi;
using System.Reflection;
using Tools;
namespace Dal;


public class CustomerImplementation : ICustomer
{
    public int Create(Customer c)
    {
        
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create in customer");
        var q = from item in DataSource.customers
                where item.Id == c.Id
                select item;
        if (q.FirstOrDefault() == null) { 
            DataSource.customers.Add(c);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end create in customer");
            LogManager.Tab= LogManager.Tab.Substring(0, LogManager.Tab.Length-1);
            return c.Id;
        }
        throw new DalIdExistExeption("Customer");
    }
    public Customer? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in customer");
        var q = from item in DataSource.customers
                where item.Id==id
                select item;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in customer");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return q.First();
        throw new DalIdNotExistExeption("Customer");

    }
    public Customer? Read(Func<Customer, bool> filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in customer");
        var q = from item in DataSource.customers
                where filter(item)
                select item;
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in customer");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return q.First();
        throw new DalIdNotExistExeption("Customer");

    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in customer");
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in customer");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        return new List<Customer>(DataSource.customers);
    }
    public void Update(Customer item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update in customer");
        Delete(item.Id);
        DataSource.customers.Add(item);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end update in customer");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);

    }
    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete in customer");
        Customer c=Read(id);
        DataSource.customers.Remove(c);
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end delete in customer");
        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
    }
}
