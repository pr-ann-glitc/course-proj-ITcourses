using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibr
{
    public class Student
    {
        public int ID;
        public string LastName; //фамилия
        public string FirstName; //имя
        public string MiddleName; //отчество
        public List<Course> Courses = new List<Course>();

        public Student(string last, string first, string middle)
        {
            LastName = last;
            FirstName = first;
            MiddleName = middle;
        }
    }
}
