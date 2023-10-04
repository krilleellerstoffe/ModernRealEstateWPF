// Christopher O'Driscoll

using System.Xml.Serialization;
using UtilitiesLib;
using ModernRealEstateDAL;

namespace ModernRealEstateBLL
{
    [Serializable]
    [XmlInclude(typeof(EstateManager))]
    public class ListManager<T> : IListManager<T>
    {
        private List<T> m_list;
        public ListManager()
        {
            m_list = new List<T>();
        }
        public int Count { get { return m_list.Count; } }
        public List<T> List { get => m_list; set => m_list = value; }
        //add item to list, if item already in list, replace with newer item
        public bool Add(T item)
        {
            //check item is correct type
            if (!(item is T) || item == null) { return false; }
            int existingIndex = m_list.IndexOf(item);
            if (existingIndex >= 0)
            {
                ChangeAt(item, existingIndex);
            }
            else
            {
                m_list.Add(item);
            }
            return true;
        }
        //replace item in list, at specified index
        public bool ChangeAt(T item, int index)
        {
            //check index is valid
            if (!CheckIndex(index)) { return false; }
            //check item is correct type
            if (!(item is T) || item == null) { return false; }
            m_list[index] = item;
            return true;
        }
        //method to check index is valid
        public bool CheckIndex(int index)
        {
            if (index < 0 || index >= m_list.Count)
            {
                return false;
            }
            return true;
        }
        //remove everything from list
        public void DeleteAll()
        {
            m_list.Clear();
        }
        //remove from list, at specified index
        public bool DeleteAt(int index)
        {
            //check index is valid
            if (!CheckIndex(index)) { return false; }
            m_list.RemoveAt(index);
            return true;
        }
        //fetch item from list, at specified index
        public T GetAt(int index)
        {
            if (!CheckIndex(index)) { return default(T); }
            return m_list[index];
        }
        //return an array of stings, representing each item in list
        public string[] ToStringArray()
        {
            string[] strings = new string[m_list.Count];
            for (int i = 0; i < m_list.Count; i++)
            {
                strings[i] = m_list[i].ToString();
            }
            return strings;
        }
        //return a list of strings, representing each item in list
        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();
            foreach (T item in m_list)
            {
                stringList.Add(item.ToString());
            }
            return stringList;
        }
        //
        //Following methods not currently used
        //
        public bool BinarySerialize(string fileName)
        {
            return MRESerializer.BinarySerialize(this, fileName);

        }
        public IListManager<T> BinaryDeSerialize(string fileName)
        {
            return (ListManager<T>) MRESerializer.BinaryDeserialize(this, fileName);
            
        }
        public bool XMLSerialize(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
