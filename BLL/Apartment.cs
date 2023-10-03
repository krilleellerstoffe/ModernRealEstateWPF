// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Apartment : Residential
    {
        public Apartment()
        {
            base.EstateType = EstateTypes.Apartment;
        }
    }
}
