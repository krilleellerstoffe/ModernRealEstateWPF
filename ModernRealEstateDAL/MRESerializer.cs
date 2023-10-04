using System.Runtime.Serialization.Formatters.Binary;

namespace ModernRealEstateDAL
{
    public class MRESerializer
    {
        public static bool BinarySerialize(object objToSerialize, string filePath)
        {
            using (FileStream fs = File.Create(filePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, objToSerialize);
            }
            return true;
        }
        public static object BinaryDeserialize(object obj, string  filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(fs);
            }
            return obj;
        }

        public static bool XMLSerialize(Object objToSerialize, string filePath)
        {
            return true;
        }
    }
}
