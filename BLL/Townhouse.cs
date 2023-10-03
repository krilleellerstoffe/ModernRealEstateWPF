// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Townhouse : Villa
    {
        public Townhouse()
        {
            base.EstateType = EstateTypes.Townhouse;
        }
    }
}
