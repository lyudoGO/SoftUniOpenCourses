namespace ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable
    {
        public Node(int id, int row, int col)
        {
            this.Id = id;
            this.Row = row;
            this.Col = col;
            this.Distance = int.MaxValue;
        }

        public int Id { get; set; }
        public int Row { get; set; }

        public int Col { get; set; }

        public int Distance { get; set; }

        public Node PreviousNode { get; set; }

        public int CompareTo(object otherNode)
        {
            return this.Distance.CompareTo((otherNode as Node).Distance);
        }
    }
}
