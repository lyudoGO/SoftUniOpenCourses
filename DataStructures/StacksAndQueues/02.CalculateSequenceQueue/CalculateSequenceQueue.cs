namespace _02.CalculateSequenceQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CalculateSequenceQueue
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter a number");
            double number = Int32.Parse(Console.ReadLine());
            int index = 0;

            Queue<double> numbers = new Queue<double>();

            numbers.Enqueue(number);

            while (index < 50)
            {
                index++;
                double currentNum = numbers.Dequeue();
                Console.Write(currentNum + ", ");

                numbers.Enqueue(currentNum + 1);
                numbers.Enqueue(2 * currentNum + 1);
                numbers.Enqueue(currentNum + 2);
            }
        }
    }
}
