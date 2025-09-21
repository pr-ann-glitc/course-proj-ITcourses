using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassesLibr;
namespace UICourses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateCourse(object sender, RoutedEventArgs e)
        {
            string name = NameOfCourseTextBox.Text;
            Teacher teacher = new Teacher();
            teacher.FirstName = TeacherComboBox.SelectionBoxItem.ToString();
            DateTime dt = (DateTime)DateTimeOfCourse.SelectedDate;
            int max = int.Parse(MaxTextBox.Text);
            Course c = new Course(name, teacher, dt, max);

            InfoOfCourse.Text = $"{c.Name}\n{c.Teacher.FirstName}\n{c.DateTime.Date}\n{c.MaxStudents}";
        }

        private void AddTeacher(object sender, RoutedEventArgs e)
        {
            string name = TeacherNameTextBox.Text;
            Course c = new Course();
            c.Name = TeacherCourseComboBox.SelectionBoxItem.ToString();

            Teacher teacher = new Teacher(name, c);

            InfoOfTeacher.Text = $"{teacher.FirstName}\n{teacher.Course.Name}";
        }

        private void GoToStudentWindow(object sender, RoutedEventArgs e)
        {
            StudentWindow st = new StudentWindow();
            st.Show();
        }
    }
}