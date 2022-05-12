using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TestingProgram1.App;


namespace TestingProgram.App.Authtorization.App
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
                //var db = new DB();

                /*MySqlCommand command = new MySqlCommand("SELECT * FROM 'users' WHERE 'login' = @_ul AND 'pass' = @_up");
                command.Parameters.Add("@ul", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@up", MySqlDbType.VarChar).Value = password;*/

                if (true)
                {
                    MessageBox.Show("Вы авторизовались!");
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
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

        /*private void Button_Window_Reg_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }*/
    }
}
