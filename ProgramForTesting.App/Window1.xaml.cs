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
using System.Windows.Shapes;



namespace ProgramForTesting.App
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        const int MaxTimerCounter = 3600;//сюда присвоить время прохождения теста


        public Window1()
        {
            InitializeComponent();
            TextBlockSubjectName.Text = ForAll.theme1.ToString();
            if ((MaxTimerCounter % 60) == 0)
            {
                InfoTextBlock.Text = $"{(MaxTimerCounter / 60).ToString()}:{(MaxTimerCounter % 60).ToString()}0";
            }
            else
            {
                InfoTextBlock.Text = $"{(MaxTimerCounter / 60).ToString()}:{(MaxTimerCounter % 60).ToString()}";
            }

        }



        private void ButtonSelectTest_Click(object sender, RoutedEventArgs e)
        {
            new Window2().Show();
            this.Close();


        }
    }
}
