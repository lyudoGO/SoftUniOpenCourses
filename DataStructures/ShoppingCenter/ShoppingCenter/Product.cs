namespace ShoppingCenter
{
    using System;

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string  Producer { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            int comparator = this.Name.CompareTo(other.Name);
            if (comparator == 0)
            {
                comparator = this.Producer.CompareTo(other.Producer);
            }
            if (comparator == 0)
            {
                comparator = this.Price.CompareTo(other.Price);
            }

            return comparator;
        }

        public override string ToString()
        {
            return "{" + Name +";" + Producer + ";" + Price.ToString("0.00") + "}";
        }
    }
}
