// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public abstract class Residential : Estate
    {
        private Ownership ownership;
        private int rooms;

        public Ownership Ownership { get => ownership; set => ownership = value; }
        public int Rooms { get => rooms; set => rooms = value; }

        public override string ToString()
        {
            return Address.Line1 + ", " + Address.City + " : " + EstateType;
        }
        public override string[] Details()
        {
            string[] details = new string[8];
            details[0] = "\nID: " + ID;
            details[1] = "\n" + Address;
            details[2] = "\nSize: " + Size + " square metres";
            details[3] = "\nResidential Property Type: " + EstateType;
            details[4] = "\nRooms: " + rooms;
            details[5] = "\nOwnership: " + Ownership;

            //only show buyer/seller details if they exist
            if (Seller != null)
            {
                details[6] = "\nSeller: " + Seller;
            }
            else
            {
                details[6] = "No Seller";
            }
            if (Buyer != null)
            {
                details[7] = "\nBuyer: " + Buyer;
            }
            else
            {
                details[7] = "No Buyer";
            }
            return details;
        }
    }
}
