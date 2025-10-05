using ClassesLibr;
using System.Windows;
using System.Windows.Controls;
using Data.Interfaces;

namespace UICourses
{
    public partial class EditCourseWindow : Window
    {
        private ICoursesRepository _repository;
        private Course _courseToEdit;

        public EditCourseWindow(ICoursesRepository repository, Course courseToEdit)
        {
            InitializeComponent();
            _repository = repository;
            _courseToEdit = courseToEdit;
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            if (_courseToEdit != null)
            {
                NameTextBox.Text = _courseToEdit.Name;
                DurationTextBox.Text = _courseToEdit.Duration.ToString();
                MaxTextBox.Text = _courseToEdit.MaxStudents.ToString();
                DescriptionTextBox.Text = _courseToEdit.Description;

                if (_courseToEdit.Teacher != null)
                {
                    foreach (ComboBoxItem item in TeacherComboBox.Items)
                    {
                        if (item.Content.ToString() == _courseToEdit.Teacher.FirstName)
                        {
                            TeacherComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
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

        private void SaveCourse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!FindErrors()) return;

                Teacher teacher = new Teacher();
                teacher.FirstName = (TeacherComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

                _courseToEdit.Name = NameTextBox.Text;
                _courseToEdit.Teacher = teacher;
                _courseToEdit.Duration = int.Parse(DurationTextBox.Text);
                _courseToEdit.MaxStudents = int.Parse(MaxTextBox.Text);
                _courseToEdit.Description = DescriptionTextBox.Text;

                if (_repository.Update(_courseToEdit))
                {
                    MessageBox.Show($"Курс {_courseToEdit.Name} успешно обновлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при обновлении курса!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании курса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}