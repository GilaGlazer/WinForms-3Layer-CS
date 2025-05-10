
using BO;
namespace BlApi;

public interface IOrder
{
    List<SaleInProduct> AddProductToOrder(Order order, int idProductToAdd, int amount, bool isPreferred);
    void CalcTotalPriceForProduct(ProductInOrder productInOrder);
    void CalcTotalPrice(Order order);
    void DoOrder(Order order);
    List<SaleInProduct> SearchSaleForProduct(int id,bool isPreferred,int amount);
}
