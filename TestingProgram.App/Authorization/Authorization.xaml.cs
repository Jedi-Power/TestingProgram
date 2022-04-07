using System;
using System.Data.Common;
using System.Windows;
using System.Linq;
//using TestingProgram.DB_Lib;

namespace TestingProgram.App.Authorization
{
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void ButtonAuth_OnClick(object sender, RoutedEventArgs e)
        {
            var login = InputLogin.Text;
            var password = InputPassword.Password;

            //var db = new Testingdb();
            //var account = db.Authorizations.FirstOrDefault(a => a.Login == login && a.Password == password);

            if (false/*account is null*/)
            {
                MessageBox.Show("Неправильно ввели логин или пароль!", "EROR!");
            }
            else
            {
                MessageBox.Show("Добро пожаловать!");
                var main = new MainWindow(/*account*/);
                main.Show();
                Close();
            }
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {
            InputLogin.Clear();
            InputPassword.Clear();
        }
    }
}