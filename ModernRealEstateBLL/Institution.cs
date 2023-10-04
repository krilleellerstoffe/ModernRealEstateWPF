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
            string[] details = new string[5];
            details[0] = ("Institutional Property Type: " + EstateType);
            details[1] = ("Address:\n" + Address);
            details[2] = ("Size: " + Size + " square metres");

            if (Seller != null)
            {
                details[3] = ("Seller: " + Seller);
            }
            else
            {
                details[3] = "No Seller";
            }
            if (Buyer != null)
            {
                details[4] = ("Buyer: " + Buyer);
            }
            else
            {
                details[4] = "No Buyer";
            }
            return details;
        }
    }
}
