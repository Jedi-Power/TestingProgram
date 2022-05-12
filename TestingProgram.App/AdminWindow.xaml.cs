using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Data_Model;
using Db_Lib;

namespace TestingProgram.App
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            //var db = new DB();
            //ListTest.ItemsSource = db.GetAllTests();
        }
        
        private void ListTest_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var test = (sender as ListBox)?.SelectedItem as Test;
            TextBoxSubject.Text = test?.Id.ToString();
            TextBoxAnsver.Text = test?.SubjectId.ToString();
        }
        
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            var test = new Test
            {
                Id = int.Parse(TextBoxSubject.Text),
                QuestionId = int.Parse(TextBoxSubject.Text),
                AnsverId = int.Parse(TextBoxAnsver.Text),
                SubjectId = int.Parse(TextBoxSubject.Text),
            };
            
            

            var db = new DB();
            var res = db.UpdateTest(test);

            MessageBox.Show(res.ToString());

            ListTest.ItemsSource = db.GetAllTests();
        }

        private void MenuTop_DragAndDrop(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Minimize_Window(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}