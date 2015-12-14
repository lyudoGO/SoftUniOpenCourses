namespace Dictionary
{
    using System;

    public class KeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public KeyValue(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override bool Equals(object other)
        {
            var element = (KeyValue<TKey, TValue>)other;
            bool equals = Object.Equals(this.Key, element.Key) && Object.Equals(this.Value, element.Value);

            return equals;
        }

        public override int GetHashCode()
        {
            return this.CombineHashCode(this.Key.GetHashCode(), this.Value.GetHashCode());
        }

        private int CombineHashCode(int p1, int p2)
        {
            return ((p1 << 5) + p1) ^ p2;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.Key, this.Value);
        }
    }
}
