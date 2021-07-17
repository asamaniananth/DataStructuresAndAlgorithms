using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    public class HashTable<TKey, TValue>
    {
        const double _fillFactor = 0.75;
        int _maxItemsAtCurrentSize;
        int _count;
        HashTableArray<TKey, TValue> _array;

        public HashTable() : this(1000)
        {

        }

        public HashTable(int initialCapacity)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentOutOfRangeException("initialCapacity");
            }
            _array = new HashTableArray<TKey, TValue>(initialCapacity);
            _maxItemsAtCurrentSize = (int)(initialCapacity * _fillFactor) + 1;
        }

        public void Add(TKey key, TValue value)
        {
            if (_count >= _maxItemsAtCurrentSize)
            {
                HashTableArray<TKey, TValue> largeArray = new HashTableArray<TKey, TValue>(_array.Capacity * 2);
                foreach(HashTableNodePair<TKey, TValue> pair in _array.Items)
                {
                    largeArray.Add(pair.Key, pair.Value);
                }
                _array = largeArray;
                _maxItemsAtCurrentSize = (int)(_array.Capacity * _fillFactor) + 1;
            }
            _array.Add(key, value);
            _count++;
        }

        public bool Remove(TKey key)
        {
            bool removed = _array.Remove(key);
            if (removed)
            {
                _count--;
            }
            return removed;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {            
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsKey(TKey key)
        {
            TValue value;
            return _array.TryGetValue(key, out value);
        }

        public bool ContainsValue(TValue value)
        {
            foreach(TValue val in _array.Values)
            {
                if (value.Equals(val))
                {
                    return true;
                }                
            }
            return false;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach(TKey key in _array.Keys)
                {
                    yield return key;
                }
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                foreach(TValue value in _array.Values)
                {
                    yield return value;
                }
            }
        }

        public void Clear()
        {
            _array.Clear();
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
    }
}
