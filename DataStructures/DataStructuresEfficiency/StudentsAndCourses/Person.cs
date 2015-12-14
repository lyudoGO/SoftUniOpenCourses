namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (this.LastName.CompareTo(other.LastName) > 0)
            {
                return 1;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 && this.FirstName.CompareTo(other.FirstName) > 0)
            {
                return 1;
            }
            else if (this.LastName.CompareTo(other.LastName) == 0 && this.FirstName.CompareTo(other.FirstName) < 0)
            {
                return -1;
            }
            else if (this.LastName.CompareTo(other.LastName) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
