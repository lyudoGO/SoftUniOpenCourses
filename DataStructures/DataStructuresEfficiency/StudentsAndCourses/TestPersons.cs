namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class TestPersons
    {
        private static SortedDictionary<string, SortedSet<Person>> courses = new SortedDictionary<string,SortedSet<Person>>();
        private static SortedSet<Person> students;

        static void Main()
        {
            string pathFile = @"..\..\input.txt";
            StreamReader reader = new StreamReader(pathFile);

            ProcessInputReader(reader);

            PrintCourses();
        }

        private static void ProcessInputReader(StreamReader reader)
        {
            string currentLine = reader.ReadLine();
            while (currentLine != null)
            {
                string[] components = currentLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Person student = new Person();
                student.FirstName = components[0].Trim();
                student.LastName = components[1].Trim();
                string course = components[2].Trim();

                if (!courses.TryGetValue(course, out students))
                {
                    courses.Add(course, students = new SortedSet<Person>());
                }
                students.Add(student);

                currentLine = reader.ReadLine();
            }

            reader.Dispose();
        }

        private static void PrintCourses()
        {
            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
            }
        }
    }
}