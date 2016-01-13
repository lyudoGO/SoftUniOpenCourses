namespace ConnectedAreasInMatrix
{
    using System;

    public class Area : IComparable<Area>
    {
        public int Size { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public int CompareTo(Area other)
        {
            int comparer = other.Size.CompareTo(this.Size);
            if (comparer == 0)
            {
                comparer = this.Row.CompareTo(other.Row);
            }
            if (comparer == 0)
            {
                comparer = this.Col.CompareTo(other.Col);
            }

            return comparer;
        }
    }
}
