namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> collection, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            T pivot = collection[start];
            int storeIndex = start + 1;

            for (int i = start + 1; i <= end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    Swap(collection, storeIndex, i);
                    storeIndex++;
                }
            }

            storeIndex--;

            T temp = collection[start];
            collection[start] = collection[storeIndex];
            collection[storeIndex] = temp;

            QuickSort(collection, start, storeIndex - 1);
            QuickSort(collection, storeIndex + 1, end);
        }

        private static void Swap(List<T> collection, int storeIndex, int i)
        {
            T temp = collection[i];
            collection[i] = collection[storeIndex];
            collection[storeIndex] = temp;
        }

    }
}
