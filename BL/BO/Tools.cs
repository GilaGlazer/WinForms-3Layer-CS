

using System.Text;
using System.Collections;
using System.Reflection;
using DO;


namespace BO;

internal static class Tools
{
   // פונקציות המרה מטיפוסי DO לטיפוסי BO ולהיפך.
    public static BO.Customer CastCustomerDOToBO(this DO.Customer customerDO)
    {
        BO.Customer customerBO = new BO.Customer(customerDO.Id, customerDO.NameCustomer, customerDO.Address, customerDO.Phone);
        return customerBO;
    }
    public static DO.Customer CastCustomerBOToDO(this BO.Customer customerBO)
    {
        DO.Customer customerDO = new DO.Customer(customerBO.Id, customerBO.NameCustomer, customerBO.Address, customerBO.Phone);
        return customerDO;
    }

    public static DO.Product CastProductBOtoDO(this BO.Product productBO)
    {
        DO.Product productDO = new DO.Product(productBO.Id, productBO.NameProduct, (DO.CategoryProduct)productBO.Category, productBO.Price, productBO.Amount);
        return productDO;
    }

    public static BO.Product CastProductDOToBO(this DO.Product productDO)
    {
        return new BO.Product(productDO.Id, productDO.NameProduct, (BO.CategoryProduct)productDO.Category, productDO.Price, productDO.Amount);
    }

    public static BO.Sale CastSaleDOToBO(this DO.Sale saleDO)
    {
        return new BO.Sale(saleDO.IdSale, saleDO.IdSaleP, saleDO.MinAmountSale, saleDO.FainalPrice, saleDO.IsOnlyClub, saleDO.StartSaleDate, saleDO.LastSaleDate);
    }

    public static DO.Sale CastSaleBOtoDO(this BO.Sale saleBO)
    {
        DO.Sale saleDO = new DO.Sale(saleBO.IdSale, saleBO.IdSaleP, saleBO.MinAmountSale, saleBO.FainalPrice, saleBO.IsOnlyClub, saleBO.StartSaleDate, saleBO.LastSaleDate);
        return saleDO;
    }

    //public static string ToStringProperty<T>(this T obj, string prefix = "")
    //{
    //    StringBuilder sb = new StringBuilder();
    //    Type t = obj?.GetType() ?? throw new Exception("Obj is NULL");
    //    foreach (PropertyInfo prop in t.GetProperties())
    //    {
    //        if (prop.PropertyType.IsPrimitive
    //            || prop.PropertyType == typeof(string)
    //            || prop.PropertyType == typeof(DateTime)
    //            || prop.PropertyType == typeof(BO.CategoryProduct))
    //            sb.AppendLine($"{prefix}{prop.Name} = {prop.GetValue(obj)}");
    //        else
    //            sb.Append($"{prefix}{prop.Name} =\n{prop.GetValue(obj).ToStringProperty(prefix + "\t")}");
    //    }
    //    return sb.ToString();
    //}

    //public static string ToStringProperty<T>(this T obj, string prefix = "", HashSet<object> printedObjects = null)
    //{
    //    StringBuilder sb = new StringBuilder();

    //    // אם לא נמסר HashSet, ניצור אחד חדש
    //    if (printedObjects == null)
    //    {
    //        printedObjects = new HashSet<object>();
    //    }

    //    // אם האובייקט כבר הודפס, נחזיר
    //    if (printedObjects.Contains(obj))
    //    {
    //        return "";
    //    }

    //    // אחרת, נוסיף אותו לרשימה
    //    printedObjects.Add(obj);

    //    Type t = obj?.GetType() ?? throw new Exception("Obj is NULL");

    //    // עבור על כל המאפיינים של האובייקט
    //    foreach (PropertyInfo prop in t.GetProperties())
    //    {
    //        // הימנע מהדפסת מאפיינים כפולים
    //        var value = prop.GetValue(obj);

    //        if (value != null)
    //        {
    //            if (value is string || value.GetType().IsPrimitive || value is DateTime || value is BO.CategoryProduct)
    //            {
    //                // הדפסת ערכים פשוטים
    //                sb.AppendLine($"{prefix}{prop.Name} = {value}");
    //            }
    //            else
    //            {
    //                // הדפסת אובייקטים פנימיים בצורה רקורסיבית
    //                sb.AppendLine($"{prefix}{prop.Name} =");
    //                sb.Append(value.ToStringProperty(prefix + "\t", printedObjects));
    //            }
    //        }
    //    }

    //    return sb.ToString();
    //}
    public static string ToStringProperty<T>(this T obj, string prefix = "", HashSet<object> printedObjects = null)
    {
        StringBuilder sb = new StringBuilder();

        if (obj == null)
            return "Object is NULL";

        if (printedObjects == null)
            printedObjects = new HashSet<object>();

        if (printedObjects.Contains(obj))
            return ""; // כבר הודפס

        printedObjects.Add(obj);

        Type t = obj.GetType();

        foreach (PropertyInfo prop in t.GetProperties())
        {
            object value = null;

            try
            {
                value = prop.GetValue(obj);
            }
            catch
            {
                sb.AppendLine($"{prefix}{prop.Name} = [Unable to read]");
                continue;
            }

            if (value == null)
            {
                sb.AppendLine($"{prefix}{prop.Name} = null");
            }
            else if (value is string || value.GetType().IsPrimitive || value is DateTime || value is Enum)
            {
                sb.AppendLine($"{prefix}{prop.Name} = {value}");
            }
            else if (value is System.Collections.IEnumerable enumerable && !(value is string))
            {
                sb.AppendLine($"{prefix}{prop.Name} = [");
                foreach (var item in enumerable)
                {
                    sb.AppendLine($"{prefix}  - {item?.ToStringProperty(prefix + "\t", printedObjects)}");
                }
                sb.AppendLine($"{prefix}]");
            }
            else
            {
                sb.AppendLine($"{prefix}{prop.Name} =");
                sb.Append(value.ToStringProperty(prefix + "\t", printedObjects));
            }
        }

        return sb.ToString();
    }


}
