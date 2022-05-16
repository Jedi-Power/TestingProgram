using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
<<<<<<< Updated upstream
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramForTesting.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
=======
using DB;

namespace ProgramForTesting.App
{
>>>>>>> Stashed changes
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
<<<<<<< Updated upstream
=======

            Loaded += (sender, args) =>
            {
                MainWindow_Loaded(sender, args);
            };
        }
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new RequestDb();
            await db.GetSubjectAsync();
            
            var subject = db._subjects.Select(subj => subj.Name).ToList();

            ListBoxTestList.ItemsSource = subject;
>>>>>>> Stashed changes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream
            new Window1().Show();
            this.Close();
        }
=======
            ForAll.theme1 = ListBoxTestList.SelectedItem.ToString();

            var db = new RequestDb();
            await db.GetSubjectAsync();
            for (int i = 0; i < db._subjects.Count; i++)
            {
                if (db._subjects[i].Name == ForAll.theme1)
                {
                    ForAll.time = db._subjects[i].Allotted_time;
                    ForAll.subjectID = db._subjects[i].Id;
                }
            }
        }

        private void ButtonSelectTest_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
            Close();
        }
        
        private void MenuTop_DragAndDrop(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Minimize_Window(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    static class ForAll
    {
        public static string theme1 { get; set; }
        public static int time { get; set; }
        public static int subjectID { get; set; }
>>>>>>> Stashed changes
    }
}

