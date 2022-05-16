<<<<<<< Updated upstream:TestingProgram.App/WindowAutharization/AuthWindow.xaml.cs
using System.Windows;
using System.Windows.Media;
using Db_Lib;
using MySql.Data.MySqlClient;

namespace TestingProgram.App.WindowAutharization
=======
﻿using System.Windows;
using System.Windows.Media;
using DB;
using ProgramForTesting.App;
using TestingProgram1.App;

namespace Authtorization.App
>>>>>>> Stashed changes:Authtorization.App/AuthWindow.xaml.cs
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_OnClick(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text.Trim();
            string password = PassBox_Pass.Password.Trim();

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
<<<<<<< Updated upstream:TestingProgram.App/WindowAutharization/AuthWindow.xaml.cs
                //var db = new DB();

                /*MySqlCommand command = new MySqlCommand("SELECT * FROM 'users' WHERE 'login' = @_ul AND 'pass' = @_up");
                command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@up", MySqlDbType.VarChar).Value = password;*/

                if (true)
                {
                    MessageBox.Show("Вы авторизовались!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
=======
                string comand = "Select * from tab_Authorizations";
                var requestDb = new RequestDb();
                var res = await requestDb.QueryAuthorizationAsync(comand, login, password);

                if (res.ToString() == "teacher")
                {
                    MessageBox.Show("Вы авторизовались как преподаватель!");
                    new AdminWindow().Show();
                    Close();
                }
                else if (res.ToString() == "admin")
                {
                    MessageBox.Show("Вы авторизовались как администратор!");
                    new AdminWindow().Show();
>>>>>>> Stashed changes:Authtorization.App/AuthWindow.xaml.cs
                    Close();
                }
                else
                {
                    MessageBox.Show("ERROR!!!");
                }

                /*TextBox_Login.ToolTip = "";
                TextBox_Login.Background = Brushes.Transparent;
                PassBox_Pass.ToolTip = "";
                PassBox_Pass.Background = Brushes.Transparent;*/
            }
        }
<<<<<<< Updated upstream:TestingProgram.App/WindowAutharization/AuthWindow.xaml.cs

        /*private void Button_Window_Reg_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }*/
=======
>>>>>>> Stashed changes:Authtorization.App/AuthWindow.xaml.cs
    }
}