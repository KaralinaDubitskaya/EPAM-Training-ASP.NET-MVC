using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QueueLib
{
    /// <summary>
    /// Represents queue abstraction and provides it's methods
    /// </summary>
    public class CustomQueue<T> : ICollection, IEnumerable<T>
    {
        private T[] _array;
        private int _back = -1;
        private int _head = 0;
        private int _count;

        public int Count => _count;

        public bool IsEmpty => Count == 0;

        public object SyncRoot => new object();

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the CustomQueue class.
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns>instance</returns>
        public CustomQueue(int capacity = 10)
        {
            if (capacity <= 0)            
                throw new ArgumentException("Argument can't be less than 1");            

            _array = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of the CustomQueue class.
        /// </summary>
        /// <param name="baseElements"></param>
        /// <returns>instance</returns>
        public CustomQueue(IEnumerable<T> baseElements)
        {
            if (baseElements == null)            
                throw new ArgumentNullException();        
                
            if (baseElements.Count() == 0)
                throw new ArgumentException("Argument length can't be 0");

            _array = baseElements.ToArray();
            _count = _array.Length;
            _back = _array.Length - 1;
            _head = 0;
        }

        /// <summary>
        /// Adds new element to queue's back
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (_array == null)
                throw new NullReferenceException();

            if (_count + _head == _array.Length)
            {
                if (_head != 0)
                    this.TrimExcess();
                if (_count == _array.Length)
                    Array.Resize(ref _array, _array.Length * 2);
            }

            _array[++_back] = item;
            _count++; 
        }

        /// <summary>
        /// Returns element from queue's head
        /// </summary>
        /// <returns>head item</returns>
        public T Peek()
        {
            if (_array == null)
                throw new NullReferenceException();

            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            return _array[_head];
        }

        /// <summary>
        /// Returns element from queue's head and removes it from queue
        /// </summary>
        /// <returns>head item</returns>
        public T Dequeue()
        {
            if (_array == null)
                throw new NullReferenceException();

            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T item = _array[_head];
            _array[_head] = default(T);
            _count--;
            _head++;

            return item;
        }

        /// <summary>
        /// Removes all elements from queue
        /// </summary>
        public void Clear()
        {
            if (_array == null)
                throw new NullReferenceException();

            _count = 0;
            _back = _count - 1;
            _head = 0;
        }

        /// <summary>
        /// Frees unused memory int queue 
        /// </summary>
        public void TrimExcess()
        {
            if (_array == null)
                throw new NullReferenceException();

            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            T[] tempArr = new T[_count];
            Array.Copy(_array, _head, tempArr, 0, _count);

            _array = tempArr;
            _head = 0;
            _count = _array.Length;
            _back = _count - 1;
        }

        /// <summary>
        /// Checks if queue contains the element
        /// </summary>
        /// <param name="item"></param>
        /// <returns>bool</returns>
        public bool Contains(T item)
        {
            if (_array == null)
                throw new NullReferenceException();

            if (item == null)
                throw new ArgumentNullException();

            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            for (int i = 0; i < _count; i++)
            {
                if (_array[i].Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Copies queue to the array from index to the end
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        public void CopyTo(Array arr, int index)
        {
            if (_array == null)
                throw new NullReferenceException();

            if (arr == null)
                throw new ArgumentNullException();

            if (arr.GetType().GetElementType() != typeof(T))
                throw new ArgumentException("Array type must be similar to queue type");

            if (index < 0 || index > _back)
                throw new ArgumentOutOfRangeException();

            if (IsEmpty)
                throw new InvalidOperationException("Queue is empty");

            if (arr.Rank != 1)
                throw new ArgumentException("Array rank must be 1");

            if (arr.Length < _count - index)
                throw new ArgumentException("Array is not long enough to include all the elements");

            Array.Copy(_array, index, arr, 0, _count - index);
        }

        /// <summary>
        /// Returns enumerator for queue
        /// </summary>
        /// <returns>enumrator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (_array == null)
                throw new NullReferenceException();

            return new CustomEnumerator(_array);
        }

        /// <summary>
        /// Returns enumerator for queue accessing from interface variable
        /// </summary>
        /// <returns>enumrator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (_array == null)
                throw new NullReferenceException();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Represents queue's enumrator abstraction and provides it's methods
        /// </summary>
        private class CustomEnumerator : IEnumerator<T>
        {
            private T[] values;
            private int pointer = -1;

            public CustomEnumerator(T[] array)
            {
                values = array;
            }

            public T Current
            {
                get
                {
                    if (pointer != -1)
                    {
                        return values[pointer];
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => (object)Current;
            
            public bool MoveNext()
            {
                if (pointer < values.Length - 1)
                {
                    pointer++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                pointer = -1;
            }

            public void Dispose() { }
        }
    }
}
