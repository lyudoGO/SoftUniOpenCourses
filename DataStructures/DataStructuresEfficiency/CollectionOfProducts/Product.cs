namespace CollectionOfProducts
{
    using System;
    using System.Text;

    public class Product: IComparable<Product>
    {
        public Product()
        {
        }

        public Product(string title, string supplier, decimal price, uint? id)
            :this(title, supplier, price)
        {
            this.Id = id;
        }

        public Product(string title, string supplier, decimal price)
        {
            this.Title = title;
            this.Supplier = supplier;
            this.Price = price;
        }

        public uint? Id { get; set; }

        public string Title { get; set; }

        public string Supplier { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(Product other)
        {
            if (this.Id > other.Id)
            {
                return 1;
            }
            else if (this.Id < other.Id)
	        {
                return -1;
	        }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("Id:" + this.Id);
            result.AppendLine("Title:" + this.Title);
            result.AppendLine("Supplier:" + this.Supplier);
            result.AppendLine("Price:" + this.Price);

            return result.ToString();
        }
    }
}
