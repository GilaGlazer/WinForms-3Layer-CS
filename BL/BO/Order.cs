

namespace BO;

public class Order
{
    public bool? IsPreferred { get; set; }//לקוח מועדף
    public List<ProductInOrder?> ListProductInOrder { get; set; }
    public double TotalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();
}
