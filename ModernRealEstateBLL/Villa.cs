// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Villa : Residential
    {
        public Villa()
        {
            EstateType = EstateTypes.Villa;
        }

    }
}
