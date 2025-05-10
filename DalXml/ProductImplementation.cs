
using System.Xml.Serialization;
using DalApi;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class ProductImplementation : IProduct
{
    static object lockObject = new object();

    private List<Product> Deserialize()
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start deserialize in product");
        try
        {
            List<Product> listProducts;
            XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Open, FileAccess.Read))
                {
                    listProducts = serializerList.Deserialize(fs) as List<Product>;
                }
            }
            if (listProducts == null)
            {
                listProducts = new List<Product>();
            }
            return listProducts;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalReadFromXmlExeption("Product");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end deserialize in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    private void Serialize(List<Product> listProduct)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start serialize in product");
        try
        {
            lock (lockObject)
            {
                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
                    serializerList.Serialize(fs, listProduct);
                }
            }
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalWriteToXmlExeption("Product");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end serialize in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public int Create(Product item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start create in product {item.ToString()}");
        try
        {
            if (item == null) throw new DalNullObjectExeption("Product");
            List<Product> listProduct = Deserialize();
            Product p = item with { Id = Config.CodeProduct };
            bool b = listProduct.Any(c => c.Id == item.Id);
            if (b) throw new DalIdExistExeption("Product");
            listProduct.Add(p);
            Serialize(listProduct);
            return p.Id;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "create");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end create in product {item.ToString()}");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Product? Read(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read in product");
        try
        {
            List<Product> listProduct = Deserialize();
            Product Product = listProduct.SingleOrDefault(c => c.Id == id);
            return Product;
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "read");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public Product? Read(Func<Product, bool> filter)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start read with filter in product");
        try
        {
            List<Product> listProduct = Deserialize();
            return listProduct.SingleOrDefault(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "read");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end read with filter in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "start readAll in product");
        try
        {
            List<Product> listProduct = Deserialize() ?? new List<Product>();
            if (filter == null) return listProduct;
            return listProduct.FindAll(p => filter(p));
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "readAll");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "end readAll in product");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Update(Product item)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start update in product {item.ToString()}");
        try
        {
            if (item == null)
                throw new DalNullObjectExeption("Product");
            Delete(item.Id);
            List<Product> listProduct = Deserialize();
            listProduct.Add(item);
            Serialize(listProduct);
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "update");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end update in product {item.ToString()}");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }

    public void Delete(int id)
    {
        LogManager.Tab += "\t";
        LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"start delete in product {id.ToString()}");
        try
        {
            List<Product> listProduct = Deserialize();
            int prodId = listProduct.RemoveAll(prod => prod.Id == id);
            if (prodId == 0)
            {
                throw new DalIdNotExistExeption("Product");
            }
            Serialize(listProduct);
        }
        catch (Exception ex)
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"-----------------error: {ex.Message}-----------------");

            throw new DalGeneralExeption("Product", "delete");
        }
        finally
        {
            LogManager.WriteToLog(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, $"end delete in product {id.ToString()}");
            LogManager.Tab = LogManager.Tab.Substring(0, LogManager.Tab.Length - 1);
        }
    }
}

//using System.Xml.Serialization;
//using DalApi;
//using DO;

//namespace Dal;

//internal class ProductImplementation : IProduct
//{
//    static object lockObject = new object();


//    private List<Product> Deserialize()
//    {
//        try
//        {
//            List<Product> listProducts;
//            XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
//            lock (lockObject)
//            {
//                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Open, FileAccess.Read))
//                {
//                    listProducts = serializerList.Deserialize(fs) as List<Product>;
//                }
//            }
//            if (listProducts == null)
//            {
//                listProducts = new List<Product>();
//            }
//            return listProducts;
//        }
//        catch
//        {
//            throw new DalReadFromXmlExeption("Product");
//        }

//    }
//    private void Serialize(List<Product> listProduct)
//    {
//        try
//        {
//            lock (lockObject)
//            {
//                using (FileStream fs = new FileStream("../xml/products.xml", FileMode.Create, FileAccess.Write))
//                {
//                    XmlSerializer serializerList = new XmlSerializer(typeof(List<Product>));
//                    serializerList.Serialize(fs, listProduct);
//                }
//            }
//        }
//        catch
//        {
//            throw new DalWriteToXmlExeption("Product");
//        }

//    }

//    public int Create(Product item)
//    {
//        try
//        {
//            if (item == null) throw new DalNullObjectExeption("Product");
//            List<Product> listProduct = Deserialize();
//            Product p = item with { Id = Config.CodeProduct };

//            bool b = listProduct.Any(c => c.Id == item.Id);
//            if (b) throw new DalIdExistExeption("Product");
//            listProduct.Add(p);
//            Serialize(listProduct);
//            return p.Id;
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine(e.Message);
//            throw new DalGeneralExeption("Product", "create");
//        }
//    }



//    public Product? Read(int id)
//    {
//        try
//        {
//            List<Product> listProduct = Deserialize();
//            Product Product = listProduct.SingleOrDefault(c => c.Id == id);
//            //   Serialize(listProduct);
//            return Product;
//            throw new DalIdNotExistExeption("Product");
//        }
//        catch
//        {
//            throw new DalGeneralExeption("Product", "read");
//        }
//    }

//    public Product? Read(Func<Product, bool> filter)
//    {
//        try
//        {
//            List<Product> listProduct = Deserialize();
//            //  Serialize(listProduct);
//            return listProduct.SingleOrDefault(p => filter(p));
//            throw new DalIdNotExistExeption("Product");
//        }
//        catch
//        {
//            throw new DalGeneralExeption("Product", "read");
//        }
//    }

//    public List<Product?> ReadAll(Func<Product, bool>? filter = null)
//    {
//        try
//        {
//            List<Product> listProduct = Deserialize() ?? new List<Product>();
//            //Serialize(listProduct);
//            if (filter == null) return listProduct;
//            return listProduct.FindAll(p => filter(p));
//        }
//        catch
//        {
//            throw new DalGeneralExeption("Product", "readAll");
//        }
//    }

//    public void Update(Product item)
//    {
//        try
//        {
//            if (item == null)
//                throw new DalNullObjectExeption("Product");
//            Delete(item.Id);
//            List<Product> listProduct = Deserialize();
//            listProduct.Add(item);
//            //foreach (var item1 in listProduct)
//            //{
//            //    Console.WriteLine(item);
//            //}
//            Serialize(listProduct);
//        }
//        catch
//        {
//            throw new DalGeneralExeption("Product", "update");
//        }
//    }
//    //public void Update(Product item)
//    //{
//    //    try
//    //    {
//    //        if (item == null)
//    //            throw new DalNullObjectExeption("Product");

//    //        List<Product> listProduct = Deserialize();

//    //        // חיפוש האינדקס של המוצר ברשימה
//    //        int index = listProduct.FindIndex(p => p.Id == item.Id);
//    //        if (index == -1)
//    //        {
//    //            throw new DalIdNotExistExeption("Product");
//    //        }

//    //        // יצירת אובייקט חדש עם הערכים החדשים
//    //        Product updatedProduct = item with { };

//    //        // החלפת המוצר הישן בחדש
//    //        listProduct[index] = updatedProduct;

//    //        // שמירת הרשימה המעודכנת לקובץ
//    //        Serialize(listProduct);
//    //    }
//    //    catch
//    //    {
//    //        throw new DalGeneralExeption("Product", "update");
//    //    }
//    //}

//    public void Delete(int id)
//    {
//        try
//        {
//            List<Product> listProduct = Deserialize();
//            int prodId = listProduct.RemoveAll(prod => prod.Id == id);
//            if (prodId == 0)
//            {
//                throw new DalIdNotExistExeption("Product");
//            }
//            // Product p = Read(id);
//            // listProduct.Remove(p);
//            Serialize(listProduct);
//        }
//        catch
//        {
//            throw new DalGeneralExeption("Product", "delete");

//        }
//    }

//}
