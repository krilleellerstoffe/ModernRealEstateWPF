using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

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
        public static object BinaryDeserialize(object obj, string filePath)
        {
            using (FileStream fs = File.Open(filePath, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                obj = bf.Deserialize(fs);
            }
            return obj;
        }

        public static bool XMLSerialize(object obj, string filePath)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    xs.Serialize(writer, obj);
                    writer.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //TODO Fix this type casting!!
        public static object XMLDeserialize(object obj, string filePath)
        {
            try
            {
                Type type = obj.GetType();
                object deserializedObject;
                XmlSerializer xs = new XmlSerializer(type);
                using (Stream reader = new FileStream(filePath, FileMode.Open))
                {
                    deserializedObject = xs.Deserialize(reader);
                    reader.Close();
                    return deserializedObject;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
