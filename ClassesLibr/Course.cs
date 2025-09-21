using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibr
{
    public class Course
    {
        public int ID;
        public string Name;
        public Teacher Teacher;
        public DateTime DateTime;
        public List<Student> Students = new List<Student>();
        public int MaxStudents;

        public Course(string name, Teacher teacher, DateTime date, int max)
        {
            Name = name;
            Teacher = teacher;
            DateTime = date;
            MaxStudents = max;
        }

        public Course() { }
    }
}
