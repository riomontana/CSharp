
namespace Assignment1
{

    // Interface for a real estate object with simple get, set properties

    public interface IEstate
    {
        int Id { get; set; }
        string Category { get; set; }
        string Type { get; set; }
        string LegalForm { get; set; }
        Address Address { get; set; }
    }
}
