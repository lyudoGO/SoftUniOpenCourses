namespace ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value) 
        {
            AddToFirstDictionary(key1, value);

            AddToSecondDictionary(key2, value);

            AddToTupleDictionary(key1, key2, value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2) 
        {
            Tuple<K1, K2> tuple = new Tuple<K1, K2>(key1, key2);
            List<T> values;
            if (this.valuesByBothKeys.TryGetValue(tuple, out values))
            {
                return values;
            }

            return new List<T>();
        }

        public IEnumerable<T> FindByKey1(K1 key1) 
        {
            List<T> values;
            if (this.valuesByFirstKey.TryGetValue(key1, out values))
            {
                return values;
            }

            return new List<T>();
        }

        public IEnumerable<T> FindByKey2(K2 key2) 
        {
            List<T> values;
            if (this.valuesBySecondKey.TryGetValue(key2, out values))
            {
                return values;
            }

            return new List<T>();
        }

        public bool Remove(K1 key1, K2 key2)
        {
            if (this.valuesByFirstKey.ContainsKey(key1) &&
                this.valuesBySecondKey.ContainsKey(key2))
            {
                var itemsBySecondKey = this.valuesBySecondKey[key2];
                foreach (var item in itemsBySecondKey)
                {
                    if (this.valuesByFirstKey[key1].Contains(item))
                    {
                        this.valuesByFirstKey[key1].Remove(item);
                    }
                }
                //this.valuesByFirstKey.Remove(key1);
                this.valuesBySecondKey.Remove(key2);
                this.valuesByBothKeys.Remove(new Tuple<K1, K2>(key1, key2));
                return true;
            }

            return false;
        }

        private void AddToTupleDictionary(K1 key1, K2 key2, T value)
        {
            Tuple<K1, K2> tuples = new Tuple<K1, K2>(key1, key2);
            List<T> listByKey1AndKey2;
            if (!this.valuesByBothKeys.TryGetValue(tuples, out listByKey1AndKey2))
            {
                this.valuesByBothKeys.Add(tuples, listByKey1AndKey2 = new List<T>());
            }
            listByKey1AndKey2.Add(value);
        }

        private void AddToSecondDictionary(K2 key2, T value)
        {
            List<T> listByKey2;
            if (!this.valuesBySecondKey.TryGetValue(key2, out listByKey2))
            {
                this.valuesBySecondKey.Add(key2, listByKey2 = new List<T>());
            }
            listByKey2.Add(value);
        }

        private void AddToFirstDictionary(K1 key1, T value)
        {
            List<T> listByKey1;
            if (!this.valuesByFirstKey.TryGetValue(key1, out listByKey1))
            {
                this.valuesByFirstKey.Add(key1, listByKey1 = new List<T>());
            }
            listByKey1.Add(value);
        }

    }
}
