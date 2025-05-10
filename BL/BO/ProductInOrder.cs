

namespace BO;

public class ProductInOrder
{
    public int IdProductInOrder { get; set; }
    public string? NameProductInOrder { get; set; }
    public double? BasePrice { get; set; }
    public int? Amount { get; set; }
    public List<SaleInProduct?> ListSaleInProduct { get; set;}
    public double? FinalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();

    public ProductInOrder() { }
    public ProductInOrder(int IdProductInOrder,string NameProductInOrder,double BasePrice,int Amount)
    {
        this.IdProductInOrder = IdProductInOrder;
        this.NameProductInOrder = NameProductInOrder;
        this.BasePrice = BasePrice;
        this.Amount = Amount;
        this.ListSaleInProduct = null;
        this.FinalPrice = 0;
    }
}
