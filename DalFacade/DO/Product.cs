

namespace DO;

public record Product
    (int Id, // מזהה ייחודי עבור המוצר.
    String? NameProduct,//שם המוצר.
    CategoryProduct? Category,//הקטגוריה של המוצר, מוגדרת על ידי ה-enum CategoryProduct.
    double? Price,//מחיר המוצר
    int? Amount //כמות המוצר הזמינה במלאי
    )
{

    public Product() : this(1, "", null, 0, 0)
    {
    }
}
