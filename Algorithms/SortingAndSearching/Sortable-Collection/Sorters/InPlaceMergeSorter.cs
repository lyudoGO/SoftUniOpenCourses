namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeInPlace(collection, 0, collection.Count - 1);
        }

        private void MergeInPlace(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeInPlace(collection, start, middle);
                MergeInPlace(collection, middle + 1, end);

                Merge(collection, start, middle, end);
            }
         }

        // The merge method combines the two sorted portions of collection
        private void Merge(List<T> collection, int start, int middle, int end)
        {
            int index = start;
            while (index <= middle)
            {
                if (collection[index].CompareTo(collection[middle + 1]) > 0)
                {
                    Swap(collection, index, middle + 1);
                    Push(collection, middle + 1, end);
                }
                index++;
            }
        }

        // Puts the largest value at the end of the array. Used in the merge method after a swap of sorted array portions.
        private void Push(List<T> collection, int middle, int end)
        {
            for (int i = middle; i < end; i++)
            {
                if (collection[i].CompareTo(collection[i + 1]) > 0)
                {
                    Swap(collection, i, i + 1);
                }
            }
        }

        private void Swap(List<T> collection, int first, int second)
        {
            T temp = collection[first];
            collection[first] = collection[second];
            collection[second] = temp;
        }
    }
}



// Not working solution
//private void MergeInPlace(List<T> collection, int start, int middle, int end)
//{
//    int lengthOne = middle - start + 1;
//    int lengthTwo = end - middle;
//    if (lengthOne >= lengthTwo)
//    {
//        if (lengthTwo <= 0) // if the smaller segment has zero elements, then nothing to merge. 
//        {
//            return;
//        }
//        int q1 = (start + middle) / 2; // q1 is mid-point of the larger segment. length1 >= length2 > 0
//        int q2 = BinarySearch(collection[q1], collection, middle + 1, end);  // q2 is q1 partitioning element within the smaller sub-array (and q2 itself is part of the sub-array that does not move)
//        int q3 = q1 + (q2 - middle - 1);
//        EexchangeSubArrays(collection, q1, middle, q2 - 1);
//        MergeInPlace(collection, start, q1 - 1, q3 - 1);     // note that q3 is now in its final place and no longer participates in further processing
//        MergeInPlace(collection, q3 + 1, q2 - 1, end);
//    }
//    else
//    {
//        if (lengthOne <= 0) // if the smaller segment has zero elements, then nothing to merge
//        {
//            return;
//        }
//        int q1 = (middle + 1 + end) / 2; // q1 is mid-point of the larger segment.  length2 > length1 > 0
//        int q2 = BinarySearch(collection[q1], collection, start, middle); // q2 is q1 partitioning element within the smaller sub-array (and q2 itself is part of the sub-array that does not move)
//        int q3 = q2 + (q1 - middle - 1);
//        EexchangeSubArrays(collection, q2, middle, q1);
//        MergeInPlace(collection, start, q2 - 1, q3 - 1); // note that q3 is now in its final place and no longer participates in further processing
//        MergeInPlace(collection, q3 + 1, q1, end);
//    }
//}

//// Swaps two sequential sub-arrays ranges [ start .. middle ] and [ middle + 1 .. end ]
//private void EexchangeSubArrays(List<T> collection, int start, int middle, int end)
//{
//    Reversal(collection, start, middle);
//    Reversal(collection, middle + 1, end);
//    Reversal(collection, start, end);
//}

//// reverse a range from start to end, inclusively, in-place
//private void Reversal(List<T> collection, int start, int end)
//{
//    while (start < end)
//    {
//        T temp = collection[start];
//        collection[start] = collection[end];
//        collection[end] = temp;
//        start++;
//        end--;
//    }
//}

//private int BinarySearch(T value, List<T> collection, int left, int right)
//{
//    int lowIndex = left;
//    int highIndex = Math.Max(left, right + 1);
//    while (lowIndex < highIndex)
//    {
//        int middle = (lowIndex + highIndex) / 2;
//        if (value.CompareTo(collection[middle]) <= 0)
//        {
//            highIndex = middle;
//        }
//        else
//        {
//            lowIndex = middle + 1;
//        }
//    }

//    return highIndex;
//}