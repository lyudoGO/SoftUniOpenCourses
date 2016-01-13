namespace BestLecturesSchedule
{
    using System;

    class Lecture : IComparable<Lecture>
    {
        public Lecture(string name, int start, int finish)
        {
            this.Name = name;
            this.Start = start;
            this.Finish = finish;
            this.IsTaken = false;
        }

        public int Start { get; set; }

        public int Finish { get; set; }

        public string Name { get; set; }

        public bool IsTaken { get; set; }

        public int CompareTo(Lecture other)
        {
            return this.Finish.CompareTo(other.Finish);
        }
    }
}
