namespace ShoppingCenter
{
    public interface IShoppingCenter
    {
        string Add(string name, string producer, decimal price);
        string Delete(string producer, string name);
        string FindProductsByName(string name);
        string FindProductsByPriceRange(decimal start, decimal end);
        string FindProductsByProducer(string producer);
    }
}
