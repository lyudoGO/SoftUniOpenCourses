namespace ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ProcessorScheduling
    {
        static void Main()
        {
            Console.Write("Tasks: ");
            int tasksCount = int.Parse(Console.ReadLine());
            int maxDeadline;

            List<Task> tasks = ReadAndFillTasks(tasksCount, out maxDeadline);
            List<Task> result = FindSolution(maxDeadline, tasks);

            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", result.Select(e => e.TaskNumber)));
            Console.WriteLine("Total value: {0}", result.Sum(e => e.Value));
        }

        private static List<Task> FindSolution(int maxDeadline, List<Task> tasks)
        {
            List<Task> result = new List<Task>();
            int steps = maxDeadline;
            foreach (var task in tasks)
            {
                if (steps == 0)
                {
                    break;
                }
                if (task.Deadline <= maxDeadline)
                {
                    result.Add(task);
                }
                steps--;
            }

            result.Sort((a, b) => (a.Deadline.CompareTo(b.Deadline)));
            return result;
        }

        private static List<Task> ReadAndFillTasks(int tasksCount, out int maxDeadline)
        {
            var tasks = new List<Task>(); 
            maxDeadline = int.MinValue;
            int taskNumber = 1;
            while (tasksCount > 0)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                int value = int.Parse(parameters[0]);
                int deadline = int.Parse(parameters[1]);
                if (deadline > maxDeadline)
                {
                    maxDeadline = deadline;
                }
                tasks.Add(new Task(taskNumber, value, deadline));
                taskNumber++;
                tasksCount--;
            }
            tasks.Sort();
            return tasks;
        }
    }
}