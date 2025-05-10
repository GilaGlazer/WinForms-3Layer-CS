

namespace BO;

public class SaleInProduct
{
    public int IdSaleInProduct { get; set; }
    public int? Amount { get; set; }
    public double? Price { get; set; }
    public bool? IsSaleForAllCustomers { get; set; }
    public override string ToString() => this.ToStringProperty();

    public SaleInProduct() { }  
    public SaleInProduct(int idSaleInProduct, int? amount, double? price, bool? isSaleForAllCustomers)
    {
        IdSaleInProduct = idSaleInProduct;
        Amount = amount;
        Price = price;
        IsSaleForAllCustomers = isSaleForAllCustomers;
    }
}
