// Christopher O'Driscoll

using System.Xml.Serialization;

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Address
    {
        private string line1;
        private string line2;
        private string city;
        private string postcode;
        private Countries country;

        public Address() { }
        public Address(string line1, string line2, string city, string postcode, Countries country)
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            Postcode = postcode;
            Country = country;
        }
        public string Line1 { get => line1; set => line1 = value; }
        [XmlElement(IsNullable = false)]
        public string Line2 { get => line2; set => line2 = value; }
        public string City { get => city; set => city = value; }
        public string Postcode { get => postcode; set => postcode = value; }
        public Countries Country { get => country; set => country = value; }


        public override string ToString()
        {
            return
                "\n " + line1 +
                "\n " + line2 +
                "\n " + city +
                "\n " + postcode +
                "\n " + country;
        }
    }
}
