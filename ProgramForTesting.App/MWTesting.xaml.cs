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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DB;

namespace ProgramForTesting.App
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
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new RequestDb();
            await db.GetSubjectAsync();
            List<string> subj = new List<string>();

            for (int i = 0; i < db._subjects.Count; i++)
            {
                subj.Add(db._subjects[i].Name);
            };

            ListBoxTestList.ItemsSource = subj;
        }

        private void ListBoxTestList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ForAll.theme1 = ListBoxTestList.SelectedItem.ToString();
        }

        private void ButtonSelectTest_Click(object sender, RoutedEventArgs e)
        {

            new Window1().Show();
            this.Hide();
        }
    }

    static class ForAll
    {
        public static string theme1 { get; set; }
    }
}

