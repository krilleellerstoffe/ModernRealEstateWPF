// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Buyer : Person
    {
        public Buyer()
        {
        }

        public Buyer(string fullname) : base(fullname)
        {
            base.PersonType = PersonTypes.Buyer;
        }

        public Buyer(string firstName, string lastName) : base(firstName, lastName)
        {
            base.PersonType = PersonTypes.Buyer;
        }
    }
}
