namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;

    interface IProductCollection
    {
        void Add(string title, string supplier, decimal price, uint? id = null);

        int Count { get; }

        IEnumerable<Product> Find(decimal start, decimal end);

        IEnumerable<Product> Find(string name, decimal price);

        IEnumerable<Product> Find(string name, decimal start, decimal end);

        IEnumerable<Product> Find(string title);

        bool Remove(uint id);
    }
}
