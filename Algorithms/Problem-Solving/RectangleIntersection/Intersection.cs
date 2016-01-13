namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Intersection
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Rectangle[] rectangles = ReadAndFillRecyangles(number);
            var coordinatesX = ExtractXCoord(rectangles);
            var coordinatrsY = ExtractYCoord(rectangles);

            double sum = FindSumOverlapingRect(rectangles, coordinatesX, coordinatrsY);
            Console.WriteLine(sum);
        }

        private static double FindSumOverlapingRect(Rectangle[] rectangles, List<int> coordinatesX, List<int> coordinatrsY)
        {
            double sum = 0;
            for (int i = 0; i < coordinatesX.Count - 1; i++)
            {
                for (int j = 0; j < coordinatrsY.Count - 1; j++)
                {
                    int rectCount = 0;
                    foreach (var rect in rectangles)
                    {
                        if (coordinatesX[i] < rect.MaxX && coordinatesX[i + 1] > rect.MinX &&
                            coordinatrsY[j] < rect.MaxY && coordinatrsY[j + 1] > rect.MinY)
                        {
                            rectCount++;
                        }
                    }
                    if (rectCount >= 2)
                    {
                        int deltaX = coordinatesX[i + 1] - coordinatesX[i];
                        int deltaY = coordinatrsY[j + 1] - coordinatrsY[j];
                        sum += Math.Abs(deltaX * deltaY); ;                        
                    }
                }    
            }

            return sum;
        }

        private static List<int> ExtractYCoord(Rectangle[] rectangles)
        {
            var coordinatesY = new List<int>();
            foreach (var rect in rectangles)
            {
                coordinatesY.Add(rect.MinY);
                coordinatesY.Add(rect.MaxY);
            }
            coordinatesY.Sort();

            return coordinatesY;
        }

        private static List<int> ExtractXCoord(Rectangle[] rectangles)
        {
            var coordinatesX = new List<int>();
            foreach (var rect in rectangles)
            {
                coordinatesX.Add(rect.MinX);
                coordinatesX.Add(rect.MaxX);
            }
            coordinatesX.Sort();

            return coordinatesX;
        }

        private static Rectangle[] ReadAndFillRecyangles(int number)
        {
            var rectangles = new Rectangle[number];
            int index = 0;
            while (index < number)
            {
                int[] parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                rectangles[index] = new Rectangle(parameters[0], parameters[1], parameters[2], parameters[3]);
                index++;
            }

            return rectangles;
        }
    }
}