
namespace Assignment1
{

    // Interface for an Address with simple get, set properties

    public interface IAddress
    {   
        string Street { get; set; }
        string ZipCode { get; set; }
        string City { get; set; }
        string Country { get; set; }
    }
}
