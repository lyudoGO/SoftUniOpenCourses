namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] temporaryArray;

        public void Sort(List<T> collection)
        {
            temporaryArray = new T[collection.Count];
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;
                MergeSort(collection, start, middle);
                MergeSort(collection, middle + 1, end);

                Merge(collection, start, middle, end);
            }
        }

        private void Merge(List<T> collection, int start, int middle, int end)
        {
            int leftMinIndex = start;
            int rightMinIndex = middle + 1;
            int tempIndex = start;

            while (leftMinIndex <= middle && rightMinIndex <= end)
            {
                if (collection[leftMinIndex].CompareTo(collection[rightMinIndex]) < 0)
                {
                    this.temporaryArray[tempIndex] = collection[leftMinIndex];
                    tempIndex++;
                    leftMinIndex++;
                }
                else
                {
                    this.temporaryArray[tempIndex] = collection[rightMinIndex];
                    tempIndex++;
                    rightMinIndex++;
                }
            }

            while (leftMinIndex <= middle)
            {
                this.temporaryArray[tempIndex] = collection[leftMinIndex];
                tempIndex++;
                leftMinIndex++;
            }

            while (rightMinIndex <= end)
            {
                this.temporaryArray[tempIndex] = collection[rightMinIndex];
                tempIndex++;
                rightMinIndex++;
            }

            for (int i = start; i <= end; i++)
            {
                collection[i] = this.temporaryArray[i];
            }
        }
    }
}
