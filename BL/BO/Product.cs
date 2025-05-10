
namespace BO;

public class Product
{
    public int Id { get; set; }

    public string? NameProduct { get; set; }

    public CategoryProduct? Category { get; set; }

    public double? Price { get; set; }

    public int? Amount { get; set; }
    public List<SaleInProduct?> ListSaleInProduct { get; set; }
    public override string ToString() => this.ToStringProperty();
    public Product() { }
    public Product(int id, string? nameProduct, CategoryProduct? category, double? price, int? amount)
    {
        Id = id;
        NameProduct = nameProduct;
        Category = category;
        Price = price;
        Amount = amount;
    }
}
