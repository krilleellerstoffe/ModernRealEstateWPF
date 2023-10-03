// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Seller : Person
    {
        public Seller()
        {
        }

        public Seller(string fullname) : base(fullname)
        {
            base.PersonType = PersonTypes.Seller;
        }

        public Seller(string firstName, string lastName) : base(firstName, lastName)
        {
            base.PersonType = PersonTypes.Seller;
        }
    }
}
