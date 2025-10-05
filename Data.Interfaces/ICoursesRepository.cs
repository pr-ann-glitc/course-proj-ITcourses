using ClassesLibr;
namespace Data.Interfaces
{
    public interface ICoursesRepository
    {
        void AddNewCourse(Course course);
        Course GetByID(int id);
        List<Course> GetAll();
        bool Update(Course course);
        bool Delete(int id);
    }
}
