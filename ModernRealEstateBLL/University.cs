// Christopher O'Driscoll

using UtilitiesLib;

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
