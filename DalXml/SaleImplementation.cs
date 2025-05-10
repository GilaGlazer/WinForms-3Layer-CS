using DalApi;
using DO;
using System.Xml.Linq;
using Tools;
using System.Reflection;

namespace Dal;

internal class SaleImplementation : ISale
{
    private const string FILE_PATH = "../xml/sales.xml";
    private const string ID_SALE = "IdSale";
    private const string ID_SALE_P = "IdSaleProduct";
    private const string MIN_AMOUNT_SALE = "minAmountSale";
    private const string FAINAL_PRICE = "finalPrice";
    private const string IS_ONLY_CLUB = "isOnlyClub";
    private const string START_SALE_DATE = "startSaleDate";
    private const string LAST_SALE_DATE = "lastSaleDate";
    private const string CLASS = "Sale";

    public int Create(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start create in sale {item.ToString()}");
        try
        {
            if (item == null) throw new DalNullObjectExeption(CLASS);
            XElement saleXml = XElement.Load(FILE_PATH);
            Sale s = item with { IdSale = Config.CodeSale };
            saleXml.Add(new XElement(CLASS,
                         new XElement(ID_SALE, s.IdSale),
                         new XElement(ID_SALE_P, s.IdSaleP),
                         new XElement(MIN_AMOUNT_SALE, s.MinAmountSale),
                         new XElement(FAINAL_PRICE, s.FainalPrice),
                         new XElement(IS_ONLY_CLUB, s.IsOnlyClub),
                         new XElement(START_SALE_DATE, s.StartSaleDate),
                         new XElement(LAST_SALE_DATE, s.LastSaleDate)
                ));
            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end create in sale {item.ToString()}");
            return s.IdSale;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "create");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == id);
            if (element == null) { throw new DalIdNotExistExeption(CLASS); }
            Sale sale = new Sale()
            {
                IdSale = int.Parse(element.Element(ID_SALE).Value),
                IdSaleP = int.Parse(element.Element(ID_SALE_P).Value),
                MinAmountSale = int.Parse(element.Element(MIN_AMOUNT_SALE).Value),
                FainalPrice = int.Parse(element.Element(FAINAL_PRICE).Value),
                IsOnlyClub = bool.Parse(element.Element(IS_ONLY_CLUB).Value),
                StartSaleDate = DateTime.Parse(element.Element(START_SALE_DATE).Value),
                LastSaleDate = DateTime.Parse(element.Element(LAST_SALE_DATE).Value)
            };
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in sale");
            return sale;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "read");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read with filter in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).Single(s => filter(
                new Sale()
                {
                    IdSale = int.Parse(s.Element(ID_SALE).Value),
                    IdSaleP = int.Parse(s.Element(ID_SALE_P).Value),
                    MinAmountSale = int.Parse(s.Element(MIN_AMOUNT_SALE).Value),
                    FainalPrice = int.Parse(s.Element(FAINAL_PRICE).Value),
                    IsOnlyClub = bool.Parse(s.Element(IS_ONLY_CLUB).Value),
                    StartSaleDate = DateTime.Parse(s.Element(START_SALE_DATE).Value),
                    LastSaleDate = DateTime.Parse(s.Element(LAST_SALE_DATE).Value)
                }));
            if (element == null)
            {
                throw new DalIdNotExistExeption(CLASS);
            }
            Sale sale = new Sale()
            {
                IdSale = int.Parse(element.Element(ID_SALE).Value),
                IdSaleP = int.Parse(element.Element(ID_SALE_P).Value),
                MinAmountSale = int.Parse(element.Element(MIN_AMOUNT_SALE).Value),
                FainalPrice = int.Parse(element.Element(FAINAL_PRICE).Value),
                IsOnlyClub = bool.Parse(element.Element(IS_ONLY_CLUB).Value),
                StartSaleDate = DateTime.Parse(element.Element(START_SALE_DATE).Value),
                LastSaleDate = DateTime.Parse(element.Element(LAST_SALE_DATE).Value)
            };
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read with filter in sale");
            return sale;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "read");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in sale");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            List<Sale> resultList = saleXml.Elements(CLASS).Select(s =>
                new Sale()
                {
                    IdSale = int.Parse(s.Element(ID_SALE).Value),
                    IdSaleP = int.Parse(s.Element(ID_SALE_P).Value),
                    MinAmountSale = int.Parse(s.Element(MIN_AMOUNT_SALE).Value),
                    FainalPrice = double.Parse(s.Element(FAINAL_PRICE).Value),
                    IsOnlyClub = bool.Parse(s.Element(IS_ONLY_CLUB).Value),
                    StartSaleDate = DateTime.Parse(s.Element(START_SALE_DATE).Value),
                    LastSaleDate = DateTime.Parse(s.Element(LAST_SALE_DATE).Value)
                })
                .Where(filter ?? (_ => true)) // בדיקה שהפילטר לא `null`
                .ToList();
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in sale");
            return resultList;
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "readAll");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Sale item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start update in sale {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption(CLASS);
            XElement saleXml = XElement.Load(FILE_PATH);
            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == item.IdSale);
            if (element == null) { throw new DalIdNotExistExeption(CLASS); }

            element.Element(ID_SALE).SetValue(item.IdSale);
            element.Element(ID_SALE_P).SetValue(item.IdSaleP);
            element.Element(MIN_AMOUNT_SALE).SetValue(item.MinAmountSale);
            element.Element(FAINAL_PRICE).SetValue(item.FainalPrice);
            element.Element(IS_ONLY_CLUB).SetValue(item.IsOnlyClub);
            element.Element(START_SALE_DATE).SetValue(item.StartSaleDate);
            element.Element(LAST_SALE_DATE).SetValue(item.LastSaleDate);

            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end update in sale {item.ToString()}");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "update");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start delete in sale {id.ToString()}");
        try
        {
            XElement saleXml = XElement.Load(FILE_PATH);
            var saletTempXml = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == id);
            if (saletTempXml == null) { throw new DalIdNotExistExeption(CLASS); }
            saletTempXml.Remove();
            saleXml.Save(FILE_PATH);
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end delete in sale {id.ToString()}");
        }
        catch (Exception e)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {e.Message}-----------------");
            throw new DalGeneralExeption(CLASS, "delete");
        }
        finally
        {
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}


//using DalApi;
//using DO;
//using System.Xml.Linq;

//namespace Dal;

//internal class SaleImplementation : ISale
//{
//    private const string FILE_PATH = "../xml/sales.xml";
//    private const string ID_SALE = "IdSale";
//    private const string ID_SALE_P = "IdSaleProduct";
//    private const string MIN_AMOUNT_SALE = "minAmountSale";
//    private const string FAINAL_PRICE = "finalPrice";
//    private const string IS_ONLY_CLUB = "isOnlyClub";
//    private const string START_SALE_DATE = "startSaleDate";
//    private const string LAST_SALE_DATE = "lastSaleDate";
//    private const string CLASS = "Sale";

//    public int Create(Sale item)
//    {
//        try
//        {
//            if (item == null) throw new DalNullObjectExeption(CLASS);
//            XElement saleXml = XElement.Load(FILE_PATH);
//            Sale s = item with { IdSale = Config.CodeSale };
//            saleXml.Add(new XElement(CLASS,
//                         new XElement(ID_SALE, s.IdSale),
//                         new XElement(ID_SALE_P, s.IdSaleP),
//                         new XElement(MIN_AMOUNT_SALE, s.MinAmountSale),
//                         new XElement(FAINAL_PRICE, s.FainalPrice),
//                         new XElement(IS_ONLY_CLUB, s.IsOnlyClub),
//                         new XElement(START_SALE_DATE, s.StartSaleDate),
//                         new XElement(LAST_SALE_DATE, s.LastSaleDate)
//                ));
//            saleXml.Save(FILE_PATH);
//            return s.IdSale;
//        }
//        catch (Exception e)
//        {
//            throw new DalGeneralExeption(CLASS, "create");
//        }
//    }



//    public Sale? Read(int id)
//    {
//        try
//        {
//            XElement saleXml = XElement.Load(FILE_PATH);
//            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == id);
//            if (element == null) { throw new DalIdNotExistExeption(CLASS); }
//            Sale sale = new Sale()
//            {
//                IdSale = int.Parse(element.Element(ID_SALE).Value),
//                IdSaleP = int.Parse(element.Element(ID_SALE_P).Value),
//                MinAmountSale = int.Parse(element.Element(MIN_AMOUNT_SALE).Value),
//                FainalPrice = int.Parse(element.Element(FAINAL_PRICE).Value),
//                IsOnlyClub = bool.Parse(element.Element(IS_ONLY_CLUB).Value),
//                StartSaleDate = DateTime.Parse(element.Element(START_SALE_DATE).Value),
//                LastSaleDate = DateTime.Parse(element.Element(LAST_SALE_DATE).Value)
//            };
//            return sale;

//        }
//        catch (Exception e)
//        {
//            throw new DalGeneralExeption(CLASS, "read");
//        }
//    }

//    public Sale? Read(Func<Sale, bool> filter)
//    {
//        try
//        {
//            XElement saleXml = XElement.Load(FILE_PATH);
//            var element = saleXml.Elements(CLASS).Single(s => filter(
//                new Sale()
//                {
//                    IdSale = int.Parse(s.Element(ID_SALE).Value),
//                    IdSaleP = int.Parse(s.Element(ID_SALE_P).Value),
//                    MinAmountSale = int.Parse(s.Element(MIN_AMOUNT_SALE).Value),
//                    FainalPrice = int.Parse(s.Element(FAINAL_PRICE).Value),
//                    IsOnlyClub = bool.Parse(s.Element(IS_ONLY_CLUB).Value),
//                    StartSaleDate = DateTime.Parse(s.Element(START_SALE_DATE).Value),
//                    LastSaleDate = DateTime.Parse(s.Element(LAST_SALE_DATE).Value)
//                }));
//            if (element == null)
//            {
//                throw new DalIdNotExistExeption(CLASS);
//            }
//            Sale sale = new Sale()
//            {
//                IdSale = int.Parse(element.Element(ID_SALE).Value),
//                IdSaleP = int.Parse(element.Element(ID_SALE_P).Value),
//                MinAmountSale = int.Parse(element.Element(MIN_AMOUNT_SALE).Value),
//                FainalPrice = int.Parse(element.Element(FAINAL_PRICE).Value),
//                IsOnlyClub = bool.Parse(element.Element(IS_ONLY_CLUB).Value),
//                StartSaleDate = DateTime.Parse(element.Element(START_SALE_DATE).Value),
//                LastSaleDate = DateTime.Parse(element.Element(LAST_SALE_DATE).Value)
//            };
//            return sale;
//        }
//        catch (Exception e)
//        {
//            throw new DalGeneralExeption(CLASS, "read");
//        }
//    }

//    public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
//    {
//        try
//        {
//            XElement saleXml = XElement.Load(FILE_PATH);
//            List<Sale> resultList = saleXml.Elements(CLASS).Select(s =>
//                new Sale()
//                {
//                    IdSale = int.Parse(s.Element(ID_SALE).Value),
//                    IdSaleP = int.Parse(s.Element(ID_SALE_P).Value),
//                    MinAmountSale = int.Parse(s.Element(MIN_AMOUNT_SALE).Value),
//                    FainalPrice = double.Parse(s.Element(FAINAL_PRICE).Value),
//                    IsOnlyClub = bool.Parse(s.Element(IS_ONLY_CLUB).Value),
//                    StartSaleDate = DateTime.Parse(s.Element(START_SALE_DATE).Value),
//                    LastSaleDate = DateTime.Parse(s.Element(LAST_SALE_DATE).Value)
//                })
//                .Where(filter ?? (_ => true)) // בדיקה שהפילטר לא `null`
//                .ToList();
//            if (resultList == null)
//            {
//                throw new DalIdNotExistExeption(CLASS);
//            }
//            return resultList;
//        }
//        catch (Exception e)
//        {
//            //Console.WriteLine($"שגיאה במהלך הקריאה: {e.Message}");
//            //Console.WriteLine($"StackTrace: {e.StackTrace}");
//            throw new DalGeneralExeption(CLASS, "readAll");
//        }
//    }

//    public void Update(Sale item)
//    {
//        try
//        {
//            if (item == null)
//                throw new DalNullObjectExeption(CLASS);
//            XElement saleXml = XElement.Load(FILE_PATH);
//            var element = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == item.IdSale);
//            if (element == null) { throw new DalIdNotExistExeption(CLASS); }

//            element.Element(ID_SALE).SetValue(item.IdSale);
//            element.Element(ID_SALE_P).SetValue(item.IdSaleP);
//            element.Element(MIN_AMOUNT_SALE).SetValue(item.MinAmountSale);
//            element.Element(FAINAL_PRICE).SetValue(item.FainalPrice);
//            element.Element(IS_ONLY_CLUB).SetValue(item.IsOnlyClub);
//            element.Element(START_SALE_DATE).SetValue(item.StartSaleDate);
//            element.Element(LAST_SALE_DATE).SetValue(item.LastSaleDate);

//            saleXml.Save(FILE_PATH);
//        }
//        catch (Exception e)
//        {
//            throw new DalGeneralExeption(CLASS, "update");
//        }
//    }

//    public void Delete(int id)
//    {
//        try
//        {
//            XElement saleXml = XElement.Load(FILE_PATH);
//            var saletTempXml = saleXml.Elements(CLASS).FirstOrDefault(s => int.Parse(s.Element(ID_SALE).Value) == id);
//            if (saletTempXml == null) { throw new DalIdNotExistExeption(CLASS); }
//            saletTempXml.Remove();
//            saleXml.Save(FILE_PATH);
//        }
//        catch (Exception e)
//        {
//            throw new DalGeneralExeption(CLASS, "delete");
//        }
//    }
//}
