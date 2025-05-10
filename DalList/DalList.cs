

using DalApi;
using DO;

namespace Dal;

internal sealed class DalList : IDal
{
    private static readonly DalList instance = new DalList();
    public static DalList Instance {  get { return instance; } }  
    private DalList() { }
    public ICustomer Customer
    {
        get
        {
            return new CustomerImplementation();
        }
    }
    public ISale Sale => new SaleImplementation();
    public IProduct Product => new ProductImplementation();

}
