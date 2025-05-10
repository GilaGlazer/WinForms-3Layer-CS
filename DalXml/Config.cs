using System.Data.SqlTypes;
using System.Security.Claims;
using System.Xml.Linq;
using System.Xml.Linq;

namespace Dal;

internal static class Config
{
    private const string FILE_PATH = @"..\xml\data-config.xml";
    private const string CODE_PRODUCT = "codeProduct";
    private const string CODE_SALE = "codeSale";
    
    private static XElement configXml = XElement.Load(FILE_PATH);

    //לעשות סינון לכל ישות לפי משהו מסוים
    public static int CodeProduct
    {
        get 
        {
            //שדה מספרי קבוע (const) בהרשאת internal, שיקבל ערך התחלתי למספר הרץ: המספר המזהה הקטן ביותר לפי דרישת כל ישות.
            int codeProduct = int.Parse(configXml.Element(CODE_PRODUCT)?.Value ?? "10");
            codeProduct++;
            configXml.Element(CODE_PRODUCT)?.SetValue(codeProduct);
            configXml.Save(FILE_PATH);
            return codeProduct; 
        }
    }


    public static int CodeSale
    {
        get
        {
            int codeSale = int.Parse(configXml.Element(CODE_SALE)?.Value ?? "100");
            codeSale++;
            configXml.Element(CODE_SALE)?.SetValue(codeSale);
            configXml.Save(FILE_PATH);
            return codeSale;
        }
    }

}

