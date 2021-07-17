using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }
    }
    public class DoublyLinkedList<T> : ICollection<T>
    {
        DoublyLinkedListNode<T> Head { get; set; }
        DoublyLinkedListNode<T> Tail { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #region ADD
        public void AddFirst(T item)
        {
            AddFirst(new DoublyLinkedListNode<T>(item));
        }

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            if (Count == 0)
            {
                Tail = Head;
            }
            else
            {
                temp.Previous = Head;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            AddLast(new DoublyLinkedListNode<T>(item));
        }

        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }

        public void Add(T item)
        {
            AddLast(item);
        }
        #endregion

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex] = current.Value;
                arrayIndex++;
                current = current.Next;
            }
        }

        #region REMOVE
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                {
                    Tail = null;
                }
                else
                {
                    Head.Previous = null;
                }
            }
        }

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
                    Tail.Previous.Next = Tail.Next;
                    Tail = Tail.Previous;
                }
                Count--;
            }
        }

        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            DoublyLinkedListNode<T> previous = null;
            while (current != null) // if there are no nodes
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) //removing last node
                        {
                            Tail = previous;
                        }
                        else //removing middle node
                        {
                            current.Next.Previous = current.Previous;
                        }
                        Count--;
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

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((System.Collections.Generic.IEnumerable<T>)this).GetEnumerator();
        }
    }
}
