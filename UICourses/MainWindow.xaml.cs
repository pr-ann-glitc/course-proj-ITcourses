using ClassesLibr;
using System.Windows;
using System.Windows.Controls;
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
        public List<Course> courses = new List<Course>();

        private void CreateCourse(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text?.Trim() ?? "";

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show($"Вы не ввели название курса!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                    NameTextBox.Focus();
                    return;
                }

                if (TeacherComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Вы не выбрали учителя!", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                    TeacherComboBox.Focus();
                    return;
                }

                Teacher teacher = new Teacher();
                teacher.FirstName = TeacherComboBox.SelectionBoxItem.ToString();

                if (!int.TryParse(DurationTextBox.Text, out int dur) || dur <= 0)
                {
                    MessageBox.Show("Неверный ввод длительности курса!\nВведите положительное число", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                    DurationTextBox.Clear();
                    DurationTextBox.Focus();
                    return;
                }

                if (!int.TryParse(MaxTextBox.Text, out int max) || max <= 0)
                {
                    MessageBox.Show("Неверный ввод количества учеников на курс!\nВведите положительное число", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                    MaxTextBox.Clear();
                    MaxTextBox.Focus();
                    return;
                }
                
                Course c = new Course(name, teacher, dur, max);
                courses.Add(c);
                MessageBox.Show($"Курс {c.Name} успешно создан!\n{c.ToString()}", "INFO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                info.Text += "\n" + c.ToString() + "\n";
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла непредвиденная ошибка: {ex.Message}", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            NameTextBox.Clear();
            TeacherComboBox.SelectedIndex = -1;
            MaxTextBox.Clear();
            DurationTextBox.Clear();
        }
    }
}