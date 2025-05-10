

//namespace Dal;

//using DO;
//using DalApi;
//using System.Reflection;
//using Tools;

//internal class SaleImplementation:ISale
//{
//    public int Create(Sale item)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create in sale");
//        Sale s = item with { IdSale = DataSource.Config.CodeSale };
//        DataSource.sales.Add(s);
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end create in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
//        return s.IdSale;
//    }

//    public Sale? Read(int id)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in sale");
//        var q = from item in DataSource.sales
//                where item.IdSale==id
//                select item;
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
//        //מחזיר את הערך הראשון שמתאים
//        return q.First();
//        //אם לא מצא יזרוק שגיאה מתאימה
//        throw new DalIdNotExistExeption("Sale");
//    }
//    public Sale? Read(Func<Sale, bool> filter)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in sale");
//        var q = from item in DataSource.sales
//                where filter(item)
//                select item;
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
//        //מחזיר את הערך הראשון שמתאים
//        return q.First();
//        //אם לא מצא יזרוק שגיאה מתאימה
//        throw new DalIdNotExistExeption("Sale");
//    }
//    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in sale");
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
//        return new List<Sale>(DataSource.sales);

//    }
//    public void Update(Sale item)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update in sale");
//        Delete(item.IdSale);
//        DataSource.sales.Add(item);
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end update in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);

//    }
//    public void Delete(int id)
//    {
//        LogManager.Tab += "\t";
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete in sale");
//        Sale? s = Read(id);
//        DataSource.sales.Remove(s);
//        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end delete in sale");
//        LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
//    }
//}

namespace Dal;

using DO;
using DalApi;
using System.Reflection;
using Tools;
using System.Linq;

internal class SaleImplementation : ISale
{
    public int Create(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start create in sale");
        try
        {
            Sale s = item with { IdSale = DataSource.Config.CodeSale };
            DataSource.sales.Add(s);
            return s.IdSale;
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end create in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in sale");
        try
        {
            var q = DataSource.sales.FirstOrDefault(item => item.IdSale == id);
            if (q != null) return q;
            throw new DalIdNotExistExeption("Sale");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read with filter in sale");
        try
        {
            var q = DataSource.sales.FirstOrDefault(item => filter(item));
            if (q != null) return q;
            throw new DalIdNotExistExeption("Sale");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read with filter in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Sale> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in sale");
        try
        {
            return filter == null
                ? new List<Sale>(DataSource.sales)
                : DataSource.sales.Where(filter).ToList();
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start update in sale");
        try
        {
            Delete(item.IdSale);
            DataSource.sales.Add(item);
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end update in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start delete in sale");
        try
        {
            Sale? s = Read(id);
            DataSource.sales.Remove(s);
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end delete in sale");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}

