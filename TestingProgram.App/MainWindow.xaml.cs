using System.Security.Principal;
using System.Windows;

namespace TestingProgram.App
{
    public partial class MainWindow : Window
    {
        //публичное автосвойство из класса Account
        //public Account Account { get; set; }
        public MainWindow(/*Account account*/)
        {
            InitializeComponent();

            //var role = Account.Roles.First().RoleId;
            //TabControl_User.SelectedIndex = role - 1;
        }
    }
}