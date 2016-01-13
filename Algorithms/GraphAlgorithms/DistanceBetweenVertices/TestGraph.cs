namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TestGraph
    {
        static List<int>[] firstNodes = new List<int>[10];
        static List<int>[] secondNodes = new List<int>[32];
    
        static void Main()
        {
            FillNodes();

            var graph = new Graph(firstNodes);
            Console.WriteLine("First graph: ");
            Console.WriteLine("({0}, {1}) -> {2}", 1, 6, graph.GetDistance(1, 6));
            Console.WriteLine("({0}, {1}) -> {2}", 1, 5, graph.GetDistance(1, 5));
            Console.WriteLine("({0}, {1}) -> {2}", 5, 6, graph.GetDistance(5, 6));
            Console.WriteLine("({0}, {1}) -> {2}", 5, 8, graph.GetDistance(5, 8));

            var secondGraph = new Graph(secondNodes);
            Console.WriteLine("\nSecond graph: ");
            Console.WriteLine("({0}, {1}) -> {2}", 11, 7, secondGraph.GetDistance(11, 7));
            Console.WriteLine("({0}, {1}) -> {2}", 11, 21, secondGraph.GetDistance(11, 21));
            Console.WriteLine("({0}, {1}) -> {2}", 21, 4, secondGraph.GetDistance(21, 4));
            Console.WriteLine("({0}, {1}) -> {2}", 19, 14, secondGraph.GetDistance(19, 14));
            Console.WriteLine("({0}, {1}) -> {2}", 1, 4, secondGraph.GetDistance(1, 4));
            Console.WriteLine("({0}, {1}) -> {2}", 1, 11, secondGraph.GetDistance(1, 11));
            Console.WriteLine("({0}, {1}) -> {2}", 31, 21, secondGraph.GetDistance(31, 21));
            Console.WriteLine("({0}, {1}) -> {2}", 11, 14, secondGraph.GetDistance(11, 14));
        }

        private static void FillNodes()
        {
            firstNodes[1] = new List<int> { 4 };
            firstNodes[2] = new List<int> { 4 };
            firstNodes[3] = new List<int> { 4, 5 };
            firstNodes[4] = new List<int> { 6 };
            firstNodes[5] = new List<int> { 3, 7, 8 };
            firstNodes[6] = new List<int> {  };
            firstNodes[7] = new List<int> { 8 };
            firstNodes[8] = new List<int> {  };

            secondNodes[11] = new List<int> { 4 };
            secondNodes[4] = new List<int> { 12, 1 };
            secondNodes[1] = new List<int> { 12, 21, 7 };
            secondNodes[7] = new List<int> { 21 };
            secondNodes[12] = new List<int> { 4, 19 };
            secondNodes[19] = new List<int> { 1, 21 };
            secondNodes[21] = new List<int> { 14, 31 };
            secondNodes[14] = new List<int> { 14 };
            secondNodes[31] = new List<int> {  };
        }
    }
}
