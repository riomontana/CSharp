using DataLayer;

namespace Assignment1
{

    // Class handling the connection between PresentationLayer and DataLayer

    public class DataController
    {

        private FileHandler fileHandler = new FileHandler();

        public T DeSerializeFile<T>(string fileName)
        { 
            return fileHandler.BinaryFileDeSerialize<T>(fileName);
        }

        public void SerializeFile(EstateManager estateManager, string fileName)
        {
            fileHandler.BinaryFileSerialize(estateManager, fileName);
        }
    }

      
}
