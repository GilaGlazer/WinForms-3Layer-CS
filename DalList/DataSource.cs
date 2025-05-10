

namespace Dal;

using DO;
using DalApi;

internal static class DataSource
{
    internal static List<Product?> products = new List<Product?>();
    internal static List<Sale?> sales = new List<Sale?>();
    internal static List<Customer?> customers = new List<Customer?>();

    internal static class Config
    {
        //שדה מספרי קבוע (const) בהרשאת internal, שיקבל ערך התחלתי למספר הרץ: המספר המזהה הקטן ביותר לפי דרישת כל ישות.
        internal const int startValProduct= 1;
        internal const int startValSale = 100;

        //שדה מספרי סטטי בהרשאת private שיקבל כערך התחלתי את השדה הקבוע הקודם.
        private static int codeProduct= startValProduct;
        private static int codeSale = startValSale;

        //מאפיין עם get בלבד שיחזיר את ערך השדה הסטטי ויקדם אותו אוטומטית.
        public static int CodeProduct
        {
            get { return codeProduct++; }
        }
       

        public static int CodeSale
        {
            get { return codeSale++; }
        }

    }
}
