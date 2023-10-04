// Christopher O'Driscoll

namespace ModernRealEstateBLL
{
    public interface IListManager<T>
    {
        int Count { get; }
        bool Add(T item);
        bool ChangeAt(T type, int index);
        bool CheckIndex(int index);
        void DeleteAll();
        bool DeleteAt(int index);
        T GetAt(int index);
        string[] ToStringArray();
        List<string> ToStringList();
        bool BinarySerialize(string fileName);
        IListManager<T> BinaryDeSerialize(string fileName);
        bool XMLSerialize(string fileName);
    }
}