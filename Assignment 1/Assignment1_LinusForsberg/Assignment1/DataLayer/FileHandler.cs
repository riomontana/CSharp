using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataLayer
{

    // Class handling serialization of objects to binary files
    // and deserializes binary files back to object

    public class FileHandler
    {

        // Serializes object to a binary file
        public void BinaryFileSerialize(Object obj, string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(fileStream, obj);

            if (fileStream != null)
               fileStream.Close();
        }

        // Deserializes binary file
        public T BinaryFileDeSerialize<T>(string filePath)
        {
            FileStream fileStream = null;
            Object obj = null;
            fileStream = new FileStream(filePath, FileMode.Open);
            BinaryFormatter b = new BinaryFormatter();
            obj = b.Deserialize(fileStream);
          
            if (fileStream != null)
                fileStream.Close();

            return (T)obj;
        }

    }
}
