namespace ProcessorScheduling
{
    using System;

    class Task : IComparable<Task>
    {
        public Task(int taskNumber, int value, int deadline)
        {
            this.TaskNumber = taskNumber;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int TaskNumber { get; set; }

        public int Value { get; set; }

        public int Deadline { get; set; }

        public int CompareTo(Task other)
        {
            int comparer = other.Value.CompareTo(this.Value);
            if (comparer == 0)
            {
                comparer = this.Deadline.CompareTo(other.Deadline);
            }
            return comparer;
        }
    }
}