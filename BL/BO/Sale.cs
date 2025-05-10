

namespace BO;

public class Sale
{
    public int IdSale { get; set; }
    public int IdSaleP { get; set; }
    public int? MinAmountSale { get; set; }
    public double? FainalPrice { get; set; }
    public bool? IsOnlyClub { get; set; }
    public DateTime? StartSaleDate { get; set; }
    public DateTime? LastSaleDate { get; set; }
    public override string ToString() => this.ToStringProperty();
    public Sale() { }
    public Sale(int idSale, int idSaleP, int? minAmountSale, double? fainalPrice, bool? isOnlyClub, DateTime? startSaleDate, DateTime? lastSaleDate)
    {
        IdSale = idSale;
        IdSaleP = idSaleP;
        MinAmountSale = minAmountSale;
        FainalPrice = fainalPrice;
        IsOnlyClub = isOnlyClub;
        StartSaleDate = startSaleDate;
        LastSaleDate = lastSaleDate;
    }
}
