// Christopher O'Driscoll

using System.Xml.Serialization;

namespace ModernRealEstateBLL
{
    [Serializable]
    [XmlInclude(typeof(Villa))]
    [XmlInclude(typeof(Townhouse))]
    [XmlInclude(typeof(Apartment))]
    [XmlInclude(typeof(Shop))]
    [XmlInclude(typeof(Warehouse))]
    [XmlInclude(typeof(School))]
    [XmlInclude(typeof(University))]
    [XmlInclude(typeof(Hospital))]
    public abstract class Estate : IEstate
    {
        private Guid estateID;
        private int size;
        private Address address;
        private Buyer buyer;
        private Seller seller;
        private Payment payment;
        private EstateTypes estateType;
        private string[] pictureFiles;
        private int coverPicture;

        protected Estate()
        {
            estateID = Guid.NewGuid();
            coverPicture = 0;
        }

        //each new estate object must have an address and size, a unique ID is created automatically, as is the EstateType by it's constructor
        [XmlAttribute]
        public Guid ID { get => estateID; set => estateID = value; }
        public EstateTypes EstateType { get => estateType; set => estateType = value; }
        public Address Address { get => address; set => address = value; }
        public int Size { get => size; set => size = value; }
        //following attributes can be empty
        [XmlElement(IsNullable = false)]
        public string[] PictureFiles { get => pictureFiles; set => pictureFiles = value; }
        [XmlElement(IsNullable = false)]
        public int CoverPicture { get => coverPicture; set => coverPicture = value; }
        [XmlElement(IsNullable = false)]
        public Buyer Buyer { get => buyer; set => buyer = value; }
        [XmlElement(IsNullable = false)]
        public Seller Seller { get => seller; set => seller = value; }
        [XmlElement(IsNullable = false)]
        public Payment Payment { get => payment; set => payment = value; }

        //details for all estate objects must have their own toString method
        public override abstract string ToString();
        public abstract string[] Details();

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Estate estate = obj as Estate;
                return this.ID == estate.ID;
            }

        }
    }
}
