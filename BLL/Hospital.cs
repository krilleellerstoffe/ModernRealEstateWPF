// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Hospital : Institution
    {
        public Hospital()
        {
            base.EstateType = EstateTypes.Hospital;
        }
    }
}
