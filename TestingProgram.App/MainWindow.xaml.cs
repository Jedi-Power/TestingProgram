using System.Security.Principal;
using System.Windows;
using System.Windows.Media;

namespace TestingProgram.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Reg_OnClick(object sender, RoutedEventArgs e)
        {
            string login = TextBox_Login.Text.Trim();
            string password = PassBox_Pass.Password.Trim();
            string password2 = PassBox_Pass2.Password.Trim();
            string email = TextBox_Email.Text.Trim().ToLower();

            if (login.Length < 3)
            {
                TextBox_Login.ToolTip = "Не менее 3-х символов!";
                TextBox_Login.Background = Brushes.Red;
            }
            else
            {
                TextBox_Login.ToolTip = "";
                TextBox_Login.Background = Brushes.Transparent;
            }
            
            if (password.Length < 5)
            {
                PassBox_Pass.ToolTip = "Не менее 5-х символов!";
                PassBox_Pass.Background = Brushes.Red;
            }
            else
            {
                PassBox_Pass.ToolTip = "";
                PassBox_Pass.Background = Brushes.Transparent;
            }
            
            if (password != password2)
            {
                PassBox_Pass2.ToolTip = "Пароли не совпадают!";
                PassBox_Pass2.Background = Brushes.Red;
            }
            else
            {
                PassBox_Pass2.ToolTip = "";
                PassBox_Pass2.Background = Brushes.Transparent;
            }
            
            if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBox_Email.ToolTip = "Некорректный Email!";
                TextBox_Email.Background = Brushes.Red;
            }
            else
            {
                TextBox_Email.ToolTip = "";
                TextBox_Email.Background = Brushes.Transparent;

                MessageBox.Show("Вы зарегистрированы!");
            }
        }
    }
}