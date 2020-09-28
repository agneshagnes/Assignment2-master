using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Interface;
namespace Assignment_2._0.Classes
{
    class ListManager<T> : IListManager<T>

    {
        private List<T> m_list;
        private int count;
       // private String[] toStringArray;
       // private List<string> toStringList;

        public ListManager()
        {
            m_list = new List<T>();
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool Add(T aType)
        {
            m_list.Add(aType);
            return true;
        }

        public bool BinaryDeSerialize(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool BinarySerialize(string fileName)
        {
            throw new NotImplementedException();
        }

        public bool ChangeAt(T aType, int anIndex)
        {
            throw new NotImplementedException();
        }

        public bool CheckIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool DeleteAt(int anIndex)
        {
            throw new NotImplementedException();
        }

        public T GetAt(int anIndex)
        {
            throw new NotImplementedException();
        }

        public string[] ToStringArray()
        {
            throw new NotImplementedException();
        }

        public List<string> ToStringList()
        {
            throw new NotImplementedException();
        }

        public bool XMLSerialize(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
