

namespace BO;

public class Customer
{
    public int Id { get; set; }

    public string? NameCustomer { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }
    public override string ToString() => this.ToStringProperty();

    public Customer() { }
    public Customer(int id, string? nameCustomer, string? address, string? phone)
    {
        Id = id;
        NameCustomer = nameCustomer;
        Address = address;
        Phone = phone;
    }
}
