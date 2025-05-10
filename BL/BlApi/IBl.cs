

namespace BlApi;

public interface IBl
{
    public ISale ISale { get; }
    public IProduct IProduct { get; }
    public ICustomer ICustomer { get; }
    public IOrder IOrder { get; }
}
