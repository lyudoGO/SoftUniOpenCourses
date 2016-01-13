namespace FractionalKnapsackProblem
{
    using System;

    class Item : IComparable<Item>
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public int Price { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Item other)
        {
            double bestCurrent = this.Price / (double)this.Weight;
            double bestOther = other.Price / (double)other.Weight;
  
            return bestOther.CompareTo(bestCurrent); ;
        }
    }
}
