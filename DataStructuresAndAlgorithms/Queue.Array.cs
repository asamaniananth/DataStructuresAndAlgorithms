using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class QueueArray<T> : IEnumerable<T>
    {
        T[] arr = new T[0];
        int _size = 0;
        int _head = 0; // Used for dequeue and copying to new array.
        int _tail = -1; // Used for dequeue and copying to new array.

        public void Enqueue(T item)
        {
            if (arr.Length == _size)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] newArr = new T[newLength];
                // arr.CopyTo(newArr, 0);
                if (_size > 0)
                {
                    int targetIndex = 0;
                    if (_tail < _head)
                    {                        
                        for(int index = _head; _head < arr.Length; _head++)
                        {
                            newArr[targetIndex] = arr[index];
                            targetIndex++;
                        }
                        for(int index = 0; index <= _tail; index++)
                        {
                            newArr[targetIndex] = arr[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for(int index = _head; index <= _tail; index++)
                        {
                            newArr[targetIndex] = arr[index];
                            targetIndex++;
                        }
                    }

                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                arr = newArr;
            }

            if (_tail == arr.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }

            arr[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T value = arr[_head];
            if (_head == arr.Length - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }
            _size--;
            return value;
        }

        public T Peek(T item)
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return arr[_head];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (int index = _head; index < arr.Length; index++)
                    {
                        yield return arr[index];
                    }
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return arr[index];
                    }
                }
                else
                {
                    for(int index = _head; index <= _tail; index++)
                    {
                        yield return arr[index];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
