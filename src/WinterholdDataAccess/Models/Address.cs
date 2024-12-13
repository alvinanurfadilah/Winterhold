namespace WinterholdDataAccess.Models;

public class Address
{
    public long Id { get; set; }
    public string AddressName { get; set; }
    public string CustomerNumber { get; set; }

    public Customer Customer { get; set; }
}
