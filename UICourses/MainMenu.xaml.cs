using Data.InMemory;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UICourses
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private readonly ICoursesRepository _repository;

        public MainMenu()
        {
            InitializeComponent();
            _repository = new InMemoryCourses();
        }

        private void OpenListCoursesButton_Click(object sender, RoutedEventArgs e)
        {
            ListCoursesWindow listCoursesWindow = new ListCoursesWindow(_repository);
            listCoursesWindow.Show();
            this.Hide();
        }
    }
}
