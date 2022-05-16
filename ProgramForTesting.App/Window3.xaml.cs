using System;
using System.Windows;

namespace ProgramForTesting.App
{
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void ButtonBackToSubjects_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
