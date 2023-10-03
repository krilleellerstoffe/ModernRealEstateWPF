// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Warehouse : Commercial
    {
        public Warehouse()
        {
            base.EstateType = EstateTypes.Warehouse;
        }
    }
}
