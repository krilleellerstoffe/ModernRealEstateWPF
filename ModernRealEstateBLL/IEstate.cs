// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    public interface IEstate
    {
        //these properties should be implemented in all subclasses
        Guid ID { get; set; }
        Address Address { get; set; }
        int Size { get; set; }
        EstateTypes EstateType { get; set; }
        Buyer Buyer { get; set; }
        Seller Seller { get; set; }
        Payment Payment { get; set; }
        string ImageSource { get; set; }

    }
}
