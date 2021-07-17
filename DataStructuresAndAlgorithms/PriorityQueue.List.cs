using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class PriorityQueueList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private System.Collections.Generic.LinkedList<T> _list = new System.Collections.Generic.LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_list.Count == 0)
            {
                _list.AddLast(item);
            }
            else
            {
                var current = _list.First;
                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    _list.AddLast(item);
                }
                else
                {
                    _list.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            T value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek(T item)
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _list.First.Value;
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
