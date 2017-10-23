using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
        public interface IGenericList<X>
        {
            ///<summary>
            /// Adds an item to the collection
            /// </summary>
            void Add(X item);

            /// <summary >
            /// Removes  the  first  occurrence  of an item  from  the  collection.
            /// If the  item  was  not found , method  does  nothing  and  returns  false.
            ///  </summary >
            bool Remove(X item);

            /// <summary >
            /// Removes  the  item at the  given  index in the  collection.
            /// Throws  IndexOutOfRange  exception  if  index  out of  range.
            ///  </summary >
            bool RemoveAt(int index);

            /// <summary >
            /// Returns  the  item at the  given  index in the  collection.
            /// Throws  IndexOutOfRange  exception  if  index  out of  range.
            ///  </summary >
            X GetElement(int index);

            /// <summary >
            /// Returns  the  index of the  item in the  collection.
            /// If item is not  found in the  collection , method  returns  -1.
            ///  </summary >
            int IndexOf(X item);

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
            bool Contains(X item);
        }

        public class GenericList<X> : IGenericList<X>
        {
            private X[] _internalStorage;
            private int _last;

            public GenericList()
            {
                _internalStorage = new X[4];
                _last = -1;
            }

            public GenericList(int initialSize)
            {
                _internalStorage = new X[(initialSize)];
                _last = -1;
            }

            public void Add(X item)
            {
                if (_last >= _internalStorage.Length - 1)
                {
                    X[] temp = new X[_internalStorage.Length * 2];
                    _internalStorage.CopyTo(temp, 0);
                    _internalStorage = temp;
                }
                _internalStorage[++_last] = item;
            }

            public int IndexOf(X item)
            {
                for (int i = 0; i <= _last; i++)
                {
                    if (_internalStorage[i].Equals(item)) 
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
                _internalStorage[_last] = default(X);
                --_last;
                return true;
            }

            public bool Remove(X item)
            {
                int index = IndexOf(item);
                if (index == -1)
                {
                    return false;
                }
                else
                {
                    return RemoveAt(index);
                }
            }

            public X GetElement(int index)
            {
                if (index > _last)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _internalStorage[index];
                }
            }

            public int Count => _last + 1;

            public void Clear()
            {
                for (; _last >= 0; _last--)
                {
                    _internalStorage[_last] = default(X);
                }
            }

            public bool Contains(X item)
            {
                return IndexOf(item) != -1;
            }
        }
    }
