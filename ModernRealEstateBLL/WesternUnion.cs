// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class WesternUnion : Payment
    {
        public WesternUnion()
        {
        }

        public WesternUnion(string name, string email) : base(name, email)
        {
            base.PaymentType = PaymentTypes.Western_Union;
        }
    }
}
