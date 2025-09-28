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
        public int Duration;
        public List<Student> Students = new List<Student>();
        public int MaxStudents;

        
        public Course() { }

        public Course( string name, Teacher teacher, int duration, int maxStudents)
        {
            Name = name;
            Teacher = teacher;
            Duration = duration;
            MaxStudents = maxStudents;
        }

        public override string ToString()
        {
            return $"Название: {Name}\nПреподаватель: {Teacher.FirstName}\nДлительность обучения: {Duration} месяцев\nМаксимальное число студентов: {MaxStudents}";
        }
    }
}
