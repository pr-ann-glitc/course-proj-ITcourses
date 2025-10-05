using ClassesLibr;
using System.Windows;
using System.Windows.Controls;
using Data.InMemory;
using Data.Interfaces;

namespace UICourses
{
    /// <summary>
    /// I
    /// </summary>
    public partial class AddCourseWindow : Window
    {
        private ICoursesRepository _repository;

        public AddCourseWindow(ICoursesRepository repository)
        {
            InitializeComponent();
            _repository = repository;
        }

        private bool FindErrors()
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show($"Вы не ввели название курса!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                NameTextBox.Focus();
                return false;
            }

            if (TeacherComboBox.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали учителя!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                TeacherComboBox.Focus();
                return false;
            }

            if (!int.TryParse(DurationTextBox.Text, out int dur) || dur <= 0)
            {
                MessageBox.Show("Неверный ввод длительности курса!\nВведите положительное число", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                DurationTextBox.Clear();
                DurationTextBox.Focus();
                return false;
            }

            if (!int.TryParse(MaxTextBox.Text, out int max) || max <= 0)
            {
                MessageBox.Show("Неверный ввод количества учеников на курс!\nВведите положительное число", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                MaxTextBox.Clear();
                MaxTextBox.Focus();
                return false;
            }
            return true;
        }

        private void CreateCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!FindErrors()) return;

                Teacher teacher = new Teacher();
                teacher.FirstName = TeacherComboBox.SelectionBoxItem.ToString();

                Course course = new Course
                (
                    NameTextBox.Text,
                    teacher,
                    int.Parse(DurationTextBox.Text),
                    int.Parse(MaxTextBox.Text),
                    DescriptionTextBox.Text
                );

                _repository.AddNewCourse(course);
                MessageBox.Show($"Курс {course.Name} успешно создан!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании курса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}