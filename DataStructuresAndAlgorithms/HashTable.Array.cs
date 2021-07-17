using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class HashTableArray<TKey, TValue>
    {
        HashTableListNode<TKey, TValue>[] _array;

        public HashTableArray(int capacity)
        {
            _array = new HashTableListNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _array[i] = new HashTableListNode<TKey, TValue>();
            }
        }

        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        public void Clear()
        {
            foreach (HashTableListNode<TKey, TValue> node in _array)
            {
                node.Clear();
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach(HashTableListNode<TKey, TValue> pair in _array)
                {
                    foreach(TValue node in pair.Values)
                    {
                        yield return node;
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach(HashTableListNode<TKey, TValue> pair in _array)
                {
                    foreach(TKey node in pair.Keys)
                    {
                        yield return node;
                    }
                }
            }
        }

        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                foreach(HashTableListNode<TKey, TValue> node in _array)
                {
                    foreach(HashTableNodePair<TKey,TValue> pair in node.List)
                    {
                        yield return pair;
                    }
                }
            }
        }

        public int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode() % Capacity);
        }

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }
    }
}
