// Christopher O'Driscoll

using System.Xml.Serialization;

namespace ModernRealEstateBLL
{
    [Serializable]
    [XmlInclude(typeof(Bank))]
    [XmlInclude(typeof(Paypal))]
    [XmlInclude(typeof(WesternUnion))]
    public abstract class Payment : IPayment
    {
        private string paymentName;
        private string paymentDetails;
        private PaymentTypes paymentType;
        private decimal amount;

        public Payment()
        {
        }

        protected Payment(string name, string paymentDetails)
        {
            this.paymentName = name;
            this.paymentDetails = paymentDetails;
        }
        [XmlElement(IsNullable = false)]
        public string PaymentDetails { get => paymentDetails; set => paymentDetails = value; }
        public PaymentTypes PaymentType { get => paymentType; set => paymentType = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public string PaymentName { get => paymentName; set => paymentName = value; }
    }
}
