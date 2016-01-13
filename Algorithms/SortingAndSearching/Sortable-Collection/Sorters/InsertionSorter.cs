﻿namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InsertionSort(collection);
        }

        private void InsertionSort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int targetIndex = i;

                while (targetIndex > 0 && collection[targetIndex - 1].CompareTo(collection[targetIndex]) > 0)
                {
                    T temp = collection[targetIndex];
                    collection[targetIndex] = collection[targetIndex - 1];
                    collection[targetIndex - 1] = temp;

                    targetIndex--;
                }
            }
        }
    }
}
