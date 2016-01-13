namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set;}

        public int Count
        {
            get { return this.Items.Count; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return BinarySearchProcedure(item, 0, this.Items.Count - 1);
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int middlePoint = startIndex + (endIndex - startIndex) / 2;
            if (this.Items[middlePoint].CompareTo(item) > 0)
            {
                return BinarySearchProcedure(item, startIndex, middlePoint - 1); 
            }

            if (this.Items[middlePoint].CompareTo(item) < 0)
            {
                return BinarySearchProcedure(item, middlePoint + 1, endIndex); 
            }

            return middlePoint;
        }

        public int InterpolationSearch(T item)
        {
            if (this.Items.Count == 0)
            {
                return -1;
            }

            int low = 0;
            int high = this.Items.Count - 1;

            while (this.Items[low].CompareTo(item) <= 0 && this.Items[high].CompareTo(item) >= 0)
            {
                int mid = low + (1 * (high - low)) / 2;
                if (this.Items[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (this.Items[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (this.Items[low].CompareTo(item) == 0)
            {
                return low;
            }
            else
            {
                return -1;
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            var count = this.Items.Count;
            for (var i = 0; i < count; i++)
            {
                int r = i + random.Next(0, count - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]" , string.Join(", ", this.Items));
        }        
    }
}