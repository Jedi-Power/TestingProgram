using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TestingProgram1.App;
using ProgramForTesting.App;
using DB;


namespace TestingProgram.App.Authtorization.App
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private async void Button_Auth_OnClick(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text;
            string password = PassBox_Pass.Password;

            if (login.Length < 3)
            {
                TextBox_Login.ToolTip = "Не менее 3-х символов!";
                TextBox_Login.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                PassBox_Pass.ToolTip = "Не менее 5-х символов!";
                PassBox_Pass.Background = Brushes.Red;
            }
            else
            {
                string comand = "Select * from tab_Authorizations";
                RequestDb requestDb = new RequestDb();
                var res = await requestDb.QueryAuthorizationAsync(comand, login, password);

                if (res.ToString() == "teacher")
                {
                    MessageBox.Show("Вы авторизовались как преподаватель!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                }
                else if (res.ToString() == "admin")
                {
                    MessageBox.Show("Вы авторизовались как администратор!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Close();
                }
                else if (res.ToString() == "student")
                {
                    MessageBox.Show("Вы авторизовались как студент!");
                    new MainWindow().Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("ERROR!!!");
                }
            }
        }

        
    }
}
