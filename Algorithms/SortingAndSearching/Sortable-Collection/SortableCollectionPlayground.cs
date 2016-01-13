namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            const int NumberOfElementsToSort = 10;
            const int MaxValue = 150;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine(collectionToSort);

            var collection = new SortableCollection<int>(2, -1, 5, 0, -3);
            Console.WriteLine(collection);

            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);

            var shuffleArrayOne = new SortableCollection<int>(array);
            shuffleArrayOne.Shuffle();
            Console.WriteLine(shuffleArrayOne);

            shuffleArrayOne.Shuffle();
            Console.WriteLine(shuffleArrayOne);

            var shuffleArrayTwo = new SortableCollection<int>(2, 5, 12, 35, 56, 567, 788, 3440, 56565, 5454545, 66666666);
            shuffleArrayTwo.Shuffle();
            Console.WriteLine(shuffleArrayTwo);

            shuffleArrayTwo.Shuffle();
            Console.WriteLine(shuffleArrayTwo);
        }
    }
}
