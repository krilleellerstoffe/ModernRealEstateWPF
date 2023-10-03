// Christopher O'Driscoll

namespace ModernRealEstateBLL;

public interface IPerson
{
    string FirstName { get; set; }
    string LastName { get; set; }
    Address Address { get; set; }
}
