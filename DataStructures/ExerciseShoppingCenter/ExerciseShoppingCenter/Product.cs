namespace ExerciseShoppingCenter
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            int comparer = this.Name.CompareTo(other.Name);
            if (comparer == 0)
            {
                comparer = this.Producer.CompareTo(other.Producer);
            }
            if (comparer == 0)
            {
                comparer = this.Price.CompareTo(other.Price);
            }

            return comparer;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("0.00"));
        }
    }
}
