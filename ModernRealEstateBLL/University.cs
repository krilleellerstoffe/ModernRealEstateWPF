// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class University : Institution
    {
        public University()
        {
            base.EstateType = EstateTypes.University;
        }
    }
}
