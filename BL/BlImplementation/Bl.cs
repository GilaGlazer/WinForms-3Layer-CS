

using BlApi;

namespace BlImplementation;

internal class Bl : IBl
{
    public ISale ISale => new SaleImplementation();

    public IProduct IProduct =>  new ProductImplementation();

    public ICustomer ICustomer =>  new CustomerImplementation();

    public IOrder IOrder => new OrderImplementation();

    public Bl() { }
}
