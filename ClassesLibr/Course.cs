namespace ClassesLibr
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public int Duration { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public int MaxStudents { get; set; }
        public bool IsActivity { get; set; } = true;
        public string Description { get; set; }


        public Course() 
        {
            Students = new List<Student>();
        }

        public Course(string name, Teacher teacher, int duration, int maxStudents, string description)
        {
            Name = name;
            Teacher = teacher;
            Duration = duration;
            MaxStudents = maxStudents;
            Students = new List<Student>();
            IsActivity = true;
            Description = description;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nНазвание: {Name}\nПреподаватель: {Teacher.FirstName}\nДлительность обучения (в месяцах): {Duration}\nМаксимальное число студентов: {MaxStudents}";
        }
    }
}
