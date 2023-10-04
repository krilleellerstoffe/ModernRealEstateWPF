// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public abstract class Residential : Estate
    {
        private Ownership ownership;
        private string rooms;

        public Ownership Ownership { get => ownership; set => ownership = value; }
        public string Rooms { get => rooms; set => rooms = value; }

        public override string ToString()
        {
            return Address.Line1 + ", " + Address.City + " : " + EstateType;
        }
        public override string[] Details()
        {
            string[] details = new string[7];
            details[0] = "Residential Property Type: " + EstateType;
            details[1] = "Address:" + Address;
            details[2] = "Size: " + Size + " square metres";
            details[3] = "Rooms: " + rooms;
            details[4] = "Ownership: " + Ownership;

            //only show buyer/seller details if they exist
            if (Seller != null)
            {
                details[5] = "Seller: " + Seller;
            }
            else
            {
                details[5] = "No Seller";
            }
            if (Buyer != null)
            {
                details[6] = "Buyer: " + Buyer;
            }
            else
            {
                details[6] = "No Buyer";
            }
            return details;
        }
    }
}
