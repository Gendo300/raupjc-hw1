using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public interface IIntegerList
    {
        ///<summary>
        /// Adds an item to the collection
        /// </summary>
        void Add(int item);

        /// <summary >
        /// Removes  the  first  occurrence  of an item  from  the  collection.
        /// If the  item  was  not found , method  does  nothing  and  returns  false.
        ///  </summary >
        bool Remove(int item);

        /// <summary >
        /// Removes  the  item at the  given  index in the  collection.
        /// Throws  IndexOutOfRange  exception  if  index  out of  range.
        ///  </summary >
        bool RemoveAt(int index);

        /// <summary >
        /// Returns  the  item at the  given  index in the  collection.
        /// Throws  IndexOutOfRange  exception  if  index  out of  range.
        ///  </summary >
        int GetElement(int index);

        /// <summary >
        /// Returns  the  index of the  item in the  collection.
        /// If item is not  found in the  collection , method  returns  -1.
        ///  </summary >
        int IndexOf(int item);

        /// <summary >
        /// Readonly  property. Gets  the  number  of  items  contained  in the collection.
        ///  </summary >
        int Count { get; }

        /// <summary >
        /// Removes  all  items  from  the  collection.
        ///  </summary >
        void Clear();

        /// <summary >
        /// Determines  whether  the  collection  contains a specific  value.
        ///  </summary >
        bool Contains(int item);
    }

    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _last;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _last = -1;
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[(initialSize)];
            _last = -1;
        }

        public void Add(int item)
        {
            if (_last >= _internalStorage.Length - 1)
            {
                int[] temp = new int[_internalStorage.Length * 2];
                _internalStorage.CopyTo(temp, 0);
                _internalStorage = temp;
            }
            _internalStorage[++_last] = item;
        }

        public int IndexOf(int X)
        {
            for (int i = 0; i <= _last; i++)
            {
                if (_internalStorage[i] == X)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index > _last)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i <= _last - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _internalStorage[_last] = 0;
            --_last;
            return true;
        }

        public bool Remove(int x)
        {
            int index = IndexOf(x);
            if (index == -1)
            {
                return false;
            }
            else
            {
                return RemoveAt(index);
            }
        }

        public int GetElement(int Index)
        {
            if (Index > _last)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[Index];
            }
        }

        public int Count => _last + 1;

        public void Clear()
        {
            for (; _last >= 0; _last--)
            {
                _internalStorage[_last] = 0;
            }
        }

        public bool Contains(int item)
        {
            return IndexOf(item) != -1;
        }
    }



}

