// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Paypal : Payment
    {
        public Paypal()
        {
        }

        public Paypal(string name, string email) : base(name, email)
        {
            base.PaymentType = PaymentTypes.PayPal;
        }
    }
}
