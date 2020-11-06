using System;

namespace AlgPlayGroundApp.DataStructures
{
    public class HashTable
    {
        public class Entry<TKey,TVal>
        {
            public Entry(TKey key, TVal val)
            {
                Key = key;
                Value = val;
            }
            public TKey Key { get; set; }
            public TVal Value { get; set; }
        }
        //Key of type int
        //Value of type string
        //collision solved by using chaining
        private const int DefaultCapacity = 10;
        private readonly int _capacity;
        private readonly LinkedList<Entry<int, string>>[] _data;

        public HashTable(int capacity)
        {
            if(capacity <= 1)
                throw new ArgumentException("capacity should be positive value", nameof(capacity));
            _capacity = capacity;
            _data = new LinkedList<Entry<int, string>>[capacity];
        }

        public HashTable() : this(DefaultCapacity)
        {}

        private int CalculateIndex(int key)
        {
            return Math.Abs(key) % _capacity;
        }

        public void Put(int key, string value)
        {
            var pair = new Entry<int,string>(key,value);
            var index = CalculateIndex(key);
            var list = _data[index];

            if (list == null)
            {
                list = new LinkedList<Entry<int, string>>();
                list.AddLast(pair);
                _data[index] = list;
                return;
            }

            foreach (var valuePair in list)
            {
                if (valuePair.Key == pair.Key)
                {
                    //if key exists in list then update value & return
                    valuePair.Value = pair.Value;
                    return;
                }   
            }
            //if key does not exist then add new entry
            list.AddLast(pair);
        }

        public string Get(int key)
        {
            var index = CalculateIndex(key);
            var list = _data[index];
            if (list == null || list.Size == 0)
            {
                throw new InvalidOperationException($"'{key}' does not exist");
            }

            foreach (var valuePair in list)
            {
                if (valuePair.Key == key)
                {
                    //if key exists in list then update value & return
                    return valuePair.Value;
                }
            }

            throw new InvalidOperationException($"'{key}' does not exist");
        }

        public void Remove(int key)
        {
            var index = CalculateIndex(key);
            var list = _data[index];
            if (list == null || list.Size == 0)
            {
                throw new InvalidOperationException($"'{key}' does not exist");
            }

            if (list.Size == 1)
            {
                _data[index] = null;
                return;
            }

            
            foreach (var entry in list)
            {
                if (entry.Key == key)
                {
                    list.Remove(entry);
                    if (list.Size == 0)
                    {
                        _data[index] = null;
                    }
                    return;
                }
            }

            throw new InvalidOperationException($"'{key}' does not exist");
        }
    }
}