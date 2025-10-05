using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibr
{
    public class Teacher
    {
        public int ID;
        public string FirstName { get; set; } //имя
        public Course Course { get; set; }
        public double Workload { get; set; }

        public Teacher(string first, Course course)
        {
            FirstName = first;
            Course = course;
        }

        public Teacher() 
        {
            
        }
    }
}
