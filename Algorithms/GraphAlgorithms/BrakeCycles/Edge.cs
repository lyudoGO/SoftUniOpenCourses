namespace BreakCycles
{
    using System;

    public class Edge : IComparable<Edge>
    {
        public char EdgeFrom { get; set; }

        public char EdgeTo { get; set; }

        public bool IsRemoved { get; set; }

        public Edge(char edgeFrom, char edgeTo)
        {
            this.EdgeFrom = edgeFrom;
            this.EdgeTo = edgeTo;
            this.IsRemoved = false;
        }

        public int CompareTo(Edge other)
        {
            int compaper = this.EdgeFrom.CompareTo(other.EdgeFrom);
            if (compaper == 0)
            {
                compaper = this.EdgeTo.CompareTo(other.EdgeTo);
            }

            return compaper;
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1}", this.EdgeFrom, this.EdgeTo);
        }
    }
}
