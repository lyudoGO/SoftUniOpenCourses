namespace ImplementIntervalTree
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;

    public class IntervalTree<T> where T : IComparable<T>
    {
        protected class Interval : IComparable
        {
            public T Start { get; set; }

            public T End { get; set; }

            public T Max { get; set; }

            public Interval(T start, T end)
            {
                if (start.CompareTo(end) >= 0)
                {
                    throw new ArgumentException("The start value should be smaller than end value");
                }
                this.Start = start;
                this.End = end;
                this.Max = end;
            }

            public bool OverlapWith(Interval other)
            {
                return (this.Start.CompareTo(other.End) <= 0) && (this.End.CompareTo(other.Start) >= 0);
            }

            public int CompareTo(object obj)
            {
                var other = (Interval)obj;
                if (this.Start.CompareTo(other.Start) == 0 && this.End.CompareTo(other.End) == 0)
                {
                    return 0;
                }
                else if ((this.Start.CompareTo(other.Start) < 0 && this.End.CompareTo(other.End) < 0) ||
                    this.Start.CompareTo(other.Start) < 0)
                {
                    return -1;
                }
                else if ((this.Start.CompareTo(other.Start) > 0 && this.End.CompareTo(other.End) > 0) ||
                    this.Start.CompareTo(other.Start) >= 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

                throw new ArgumentException("Cannot compare intervals!");
            }
        }

        private SortedSet<Interval> tree;

        public IntervalTree()
        {
            this.tree = new SortedSet<Interval>();
        }

        public int Count { get; private set; }

        public void Insert(T min, T max)
        {
            var interval = new Interval(min, max);
            this.tree.Add(interval);
            this.Count++;
       
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach(var item in this.tree)
            {
                result.AppendLine("[" + item.Start.ToString() + "..." + item.End.ToString() + "]");
            }
            return result.ToString();
        }

    }
}
