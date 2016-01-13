namespace FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FractionalKnapsack
    {
        static void Main()
        {
            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Items: ");
            int count = int.Parse(Console.ReadLine());

            List<Item> items = ReadAndFillItems(count);
            FractionalKnapsackSolve(items, capacity);
        }

        private static void FractionalKnapsackSolve(List<Item> items, int capacity)
        {
            double totalPrice = 0;
            items.Sort();
            foreach (var item in items)
            {
                if (capacity <= 0)
                {
                    break;
                }
                double precents = 1;
                if (item.Weight > capacity)
                {
                    precents = capacity / (double)item.Weight;
                    totalPrice += item.Price * precents;
                    capacity -= (int)(item.Weight * precents);
                }
                if (item.Weight <= capacity)
                {
                    totalPrice += item.Price;
                    capacity -= item.Weight;
                }

                Console.WriteLine("Take {0:0.00}% of item with price {1:0.00} and weight {2:0.00}", precents * 100, item.Price, item.Weight);
            }

            Console.WriteLine("Total price: {0:0.00}", totalPrice);
        }

        private static List<Item> ReadAndFillItems(int count)
        {
            var items = new List<Item>();
            while (count > 0)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int price = int.Parse(parameters[0]);
                int weight = int.Parse(parameters[1]);
                items.Add(new Item(price, weight));
                count--;
            }
            return items;
        }
    }
}
