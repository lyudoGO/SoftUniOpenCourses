namespace BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LecturesSchedule
    {
        static void Main()
        {
            Console.Write("Lectures: ");
            int count = int.Parse(Console.ReadLine());

            List<Lecture> lectures = ReadLecturesFromConsole(count);
            var last = lectures[0];
            last.IsTaken = true;
            for (int i = 1; i < lectures.Count; i++)
            {
                if (lectures[i].Start >= last.Finish)
                {
                    last = lectures[i];
                    last.IsTaken = true;
                }
            }

            Console.WriteLine("\nLectures ({0}):", lectures.Count(l => l.IsTaken == true));
            foreach (var lecture in lectures)
	        {
                if (lecture.IsTaken == true)
                {
		            Console.WriteLine("{0}-{1} -> {2}", lecture.Start, lecture.Finish, lecture.Name);
                }
	        }
        }

        private static List<Lecture> ReadLecturesFromConsole(int count)
        {
            var lectures = new List<Lecture>();
            while (count > 0)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string name = parameters[0];
                int start = int.Parse(parameters[1]);
                int finish = int.Parse(parameters[2]);
                lectures.Add(new Lecture(name, start, finish));
                count--;
            }
            lectures.Sort();
            return lectures;
        }
    }
}
