using System;
using System.Collections.Generic;

namespace Assignment1
{

    // Class for managing a generic list
    // Implements IListManager<T> interface

    [Serializable]
    public class ListManager<T> : IListManager<T>
    {
        private List<T> list;

        public ListManager()
        {
            list = new List<T>();
        }

        public int Count => list.Count;

        public bool Add(T aType)
        {
            list.Add(aType);
            return true;
        }

        public bool ChangeAt(T aType, int anIndex)
        {
            list[anIndex] = aType;
            return true;
        }

        public bool CheckIndex(int index)
        {
            return (index >= 0 && index < Count);
        }

        public void DeleteAll()
        {
            list.Clear();
            list = null;
        }

        public bool DeleteAt(int anIndex)
        {
            list.RemoveAt(anIndex);
            return true;
        }

        public T GetAt(int anIndex)
        {
            return list[anIndex];
        }

        public string[] ToStringArray()
        {
            string[] stringArray = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                stringArray[i] = list[i].ToString();
            }

            return stringArray;
        }

        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();

            foreach (T t in list)
            {
                stringList.Add(t.ToString());
            }

            return stringList;
        }

        public bool XMLSerialize(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool BinaryDeSerialize(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool BinarySerialize(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
