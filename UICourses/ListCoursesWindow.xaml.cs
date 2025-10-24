using ClassesLibr;
using Data.InMemory;
using Data.Interfaces;
using System.Windows;
namespace UICourses
{
    /// <summary>
    /// Логика взаимодействия для ListCoursesWindow.xaml
    /// </summary>
    public partial class ListCoursesWindow : Window
    {
        private readonly ICoursesRepository _repository;
        public ListCoursesWindow(ICoursesRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            UpdateCourseRepository();
        }

        private void UpdateCourseRepository()
        {
            ListOfCourses.ItemsSource = _repository.GetAll();
        }


        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow addCourseWindow = new AddCourseWindow(_repository);
            if (addCourseWindow.ShowDialog() == true)
                UpdateCourseRepository();
        }

        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfCourses.SelectedItem is Course selectedCourse)
            {
                EditCourseWindow editWindow = new EditCourseWindow(_repository, selectedCourse);
                if (editWindow.ShowDialog() == true)
                    UpdateCourseRepository();
            }
            else
            {
                MessageBox.Show("Выберите курс для редактирования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfCourses.SelectedItem is Course selectedCourse)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить курс '{selectedCourse.Name}'?",
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (_repository.Delete(selectedCourse.ID))
                    {
                        UpdateCourseRepository();
                        MessageBox.Show("Курс успешно удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите курс для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainMenu mainWindow)
                {
                    mainWindow.Show();
                    break;
                }
            }
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainMenu mainWindow)
                {
                    mainWindow.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}
