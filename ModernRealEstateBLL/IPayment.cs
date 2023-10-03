// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    public interface IPayment
    {
        string PaymentName { get; set; }
        string PaymentDetails { get; set; }
        decimal Amount { get; set; }
        PaymentTypes PaymentType { get; set; }
    }
}
