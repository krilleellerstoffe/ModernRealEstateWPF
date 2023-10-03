// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public abstract class Institution : Estate
    {

        public override string ToString()
        {
            return Address.Line1 + ", " + Address.City + " : " + EstateType;
        }
        public override string[] Details()
        {
            string[] details = new string[6];
            details[0] = ("\nID: " + ID);
            details[1] = ("\n" + Address);
            details[2] = ("\nSize: " + Size + " square metres");
            details[3] = ("\nInstitutional Property Type: " + EstateType);
            if (Seller != null)
            {
                details[4] = ("\nSeller: " + Seller);
            }
            else
            {
                details[4] = "No Seller";
            }
            if (Buyer != null)
            {
                details[5] = ("\nBuyer: " + Buyer);
            }
            else
            {
                details[5] = "No Buyer";
            }
            return details;
        }
    }
}
