using ClassesLibr;
using Data.Interfaces;

namespace Data.InMemory
{
    public class InMemoryCourses : ICoursesRepository
    {
        private readonly List<Course> _courses;

        public InMemoryCourses() 
        {
            _courses = new List<Course>();
        }

        public void AddNewCourse(Course course)
        {
            if (course != null)
                _courses.Add(course);
        }

        public Course GetByID(int id)
        {
            return _courses.FirstOrDefault(c => c.ID == id);
        }

        public List<Course> GetAll()
        {
            return _courses;
        }

        public bool Update(Course course) 
        {
            if (course == null) return false;
            int index = _courses.FindIndex(c => c.ID == course.ID);
            if (index >= 0)
            {
                _courses[index].Name = course.Name;
                _courses[index].Teacher = course.Teacher;
                _courses[index].Duration = course.Duration;
                _courses[index].MaxStudents = course.MaxStudents;
                _courses[index].IsActivity = course.IsActivity;
                return true;
            }
            return false;
        }

        public bool Delete(int id) 
        {
            int index = _courses.FindIndex(c => c.ID == id);
            if (index >= 0)
            {
                _courses.RemoveAt(index);
                return true;
            }
            return false;
        }
    }
}
