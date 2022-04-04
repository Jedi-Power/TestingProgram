using System.Windows;

namespace TestingProgram.App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, args) =>
            {
                var auth = new Authorization.Authorization();
                auth.Show();
            };
        }
    }
}