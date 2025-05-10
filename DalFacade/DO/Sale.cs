

namespace DO;


// מייצג מבצע הקשור למוצר.

public record Sale
        (
         int IdSale,
         int IdSaleP,//המזהה הייחודי של המוצר הנמכר
         int? MinAmountSale,//הכמות המינימלית הנדרשת כדי לזכות במבצע.
         double? FainalPrice,//המחיר הסופי של המוצר במהלך המבצע.
         bool? IsOnlyClub,//מציין אם המבצע מיועד רק לחברי מועדון
         DateTime? StartSaleDate,//תאריך תחילת המבצע
         DateTime? LastSaleDate//תאריך סיום המבצע
        )
{



    public Sale() : this(0,0, null, null, false, null, null)
    {
    }
}
