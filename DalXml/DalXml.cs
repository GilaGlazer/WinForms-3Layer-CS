

using System.Diagnostics;
using DalApi;

namespace Dal;

public class DalXml:IDal
{
    private static readonly DalXml instance = new DalXml();
    public static DalXml Instance { get { return instance; } }
    private DalXml() { }
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
