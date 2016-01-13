namespace ShortestPathInMatrix
{
    public class Edge
    {
        public Edge (Node node, int distance)
	    {
            this.Node = node;
            this.Distance = distance;
	    }

        public int Distance { get; set; }

        public Node Node { get; set; }
    }
}
