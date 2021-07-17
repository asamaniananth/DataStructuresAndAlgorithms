using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class StackArray<T> : IEnumerable<T>
    {
        T[] arr = new T[0];
        private int _size;
        public void Push(T item)
        {
            if (_size == arr.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] newArr = new T[newLength];
                arr.CopyTo(newArr, 0);
                arr = newArr;
            }
            arr[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            _size--;
            return arr[_size];
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return arr[_size - 1];
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
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
