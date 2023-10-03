// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    [Serializable]
    public class Bank : Payment
    {
        public Bank()
        {
        }

        public Bank(string name, string accountNo) : base(name, accountNo)
        {
            base.PaymentType = PaymentTypes.Bank;
        }
    }
}
