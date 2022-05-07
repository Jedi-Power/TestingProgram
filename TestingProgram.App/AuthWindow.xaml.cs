using System.Windows;
using System.Windows.Media;

namespace TestingProgram.App
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
                TextBox_Login.ToolTip = "";
                TextBox_Login.Background = Brushes.Transparent;
                PassBox_Pass.ToolTip = "";
                PassBox_Pass.Background = Brushes.Transparent;

                MessageBox.Show("Вы авторизовались!");

                /*AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                Hide();*/
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