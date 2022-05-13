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


namespace TestingProgram1.App
{
    public partial class AdminWindow : Window
    {
        string theme = "";
        public AdminWindow()
        {
            InitializeComponent();

            
        }
        private async void AdminWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new RequestDb();
            await db.GetSubjectAsync();
            List<string> subj = new List<string>();

            for (int i = 0; i < db._subjects.Count; i++)
            {
                subj.Add(db._subjects[i].Name);
            };

            ListTest.ItemsSource = subj;
        }

        private void ListTest_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            theme = ListTest.SelectedItem.ToString();
        }

        
        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            //var test = new Test
            //{
            //    Id = int.Parse(TextBoxSubject.Text),
            //    QuestionId = int.Parse(TextBoxSubject.Text),
            //    AnsverId = int.Parse(TextBoxAnsver.Text),
            //    SubjectId = int.Parse(TextBoxSubject.Text),
            //};



            //var db = new RequestDb();
            //var res = db.UpdateTest(test);

            //MessageBox.Show(res.ToString());

            //ListTest.ItemsSource = db.GetAllTests();
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

        

        private async void ButtonAddTest_Click(object sender, RoutedEventArgs e)
        {
            string comand = $"INSERT INTO tab_Subjects(name, allotted_time) VALUES(N'{TextBoxSubject.Text}',{int.Parse(TextBoxTestTime.Text)})";
            RequestDb requestDb = new RequestDb();
            await requestDb.RequestExecuteNonQueryAsync(comand);
            MessageBox.Show("Новый тест добавлен!");
            TextBoxSubject.Text = "";
            TextBoxTestTime.Text = "";
        }

        private async void ButtonDelTest_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonAddQuestions_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(theme);
        }
    }
}