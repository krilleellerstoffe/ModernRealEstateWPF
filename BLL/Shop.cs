// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Shop : Commercial
    {
        public Shop()
        {
            base.EstateType = EstateTypes.Shop;
        }

    }
}
