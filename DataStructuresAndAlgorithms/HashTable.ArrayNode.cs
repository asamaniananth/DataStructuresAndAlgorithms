using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    public class HashTableListNode<TKey, TValue>
    {
        System.Collections.Generic.LinkedList<HashTableNodePair<TKey, TValue>> _list;

        public void Add(TKey key, TValue value)
        {
            if (_list == null)
            {
                _list = new System.Collections.Generic.LinkedList<HashTableNodePair<TKey, TValue>>();
            }
            else
            {
                foreach (HashTableNodePair<TKey, TValue> pair in _list)
                {
                    if (pair.Key.Equals(key))
                    {
                        throw new ArgumentException("List already has the key");
                    }
                }
            }
            _list.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
        }

        public void Update(TKey key, TValue value)
        {
            bool updated = false;
            if (_list != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in _list)
                {
                    if (pair.Key.Equals(key))
                    {
                        pair.Value = value;
                        updated = true;
                        break;
                    }
                }
            }
            if (!updated)
            {
                throw new ArgumentException("List is empty.");
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default;
            bool found = false;
            if (_list != null)
            {
                foreach (HashTableNodePair<TKey, TValue> pair in _list)
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        found = true;
                    }
                }
            }
            return found;
        }

        public bool Remove(TKey key)
        {
            bool removed = false;
            if (_list != null)
            {                
                System.Collections.Generic.LinkedListNode<HashTableNodePair<TKey, TValue>> current = _list.First;
                while (current != null)
                {
                    if (current.Value.Key.Equals(key))
                    {
                        _list.Remove(current);
                        removed = true;
                        break;
                    }
                    current = current.Next;
                }                
            }
            return removed;
        }

        public void Clear()
        {
            if (_list != null)
            {
                _list.Clear();
            }
        }

        public IEnumerable<HashTableNodePair<TKey,TValue>> List
        {
            get
            {
                foreach(HashTableNodePair<TKey,TValue> pair in _list)
                {
                    yield return pair;
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach(HashTableNodePair<TKey,TValue> pair in _list)
                {
                    yield return pair.Key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach(HashTableNodePair<TKey, TValue> pair in _list)
                {
                    yield return pair.Value;
                }
            }
        }
    }
}
