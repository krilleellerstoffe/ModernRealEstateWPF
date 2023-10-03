// Christopher O'Driscoll

using System.Xml.Serialization;

namespace ModernRealEstateBLL
{

    [Serializable]
    [XmlInclude(typeof(Seller))]
    [XmlInclude(typeof(Buyer))]
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private Address address;
        private PersonTypes personType;

        public Person() { }
        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        //split name into first/last names
        protected Person(string fullname)
        {
            string[] parts = fullname.Split(' ');
            this.FirstName = parts[0];
            //double check for a surname
            if (parts.Length > 1)
            {
                this.LastName = parts[1];
            }
            //in case of double-barrelled surnames, simply add together
            if (parts.Length > 2)
            {
                for (int i = 2; i < parts.Length; i++)
                {
                    this.LastName += " " + parts[i];
                }
            }

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public PersonTypes PersonType { get => personType; set => personType = value; }
        public Address Address { get => address; set => address = value; }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
