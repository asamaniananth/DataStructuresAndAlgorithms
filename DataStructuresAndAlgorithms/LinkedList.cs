using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
    public class LinkedList<T> : ICollection<T>
    {
        LinkedListNode<T> Head { get; set; }
        LinkedListNode<T> Tail { get; set; }        

        #region
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            var temp = Head;
            Head = node;
            node.Next = temp; // check this node.next;
            Count++;
            if (Count == 1) { Tail = Head; }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }                
            else
            {
                Tail.Next = node;
            }
            Tail = node;
            Count++;
        }

        public void Add(T item)
        {
            AddLast(item);
        }

        #endregion

        #region

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    var current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }
                Count--;
            }
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head.Next = Head;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> current = Head;
            LinkedListNode<T> previous = null;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        #endregion

        #region ICollection
        
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int Count { get; private set; }        

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if(current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion        
    }
}
