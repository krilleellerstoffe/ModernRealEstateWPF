// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class School : Institution
    {
        public School()
        {
            base.EstateType = EstateTypes.School;
        }
    }
}
