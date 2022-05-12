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
using System.Windows.Threading;

namespace ProgramForTesting.App
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        const int MaxTimerCounter = 3600;//сюда присвоить время прохождения теста
        const int MinTimerCounter = 0;

        DispatcherTimer _dispTimer;
        int _dispTimerCounter;
        public Window2()
        {
            InitializeComponent();
            _dispTimerCounter = MaxTimerCounter;
            _dispTimer = new DispatcherTimer();
            _dispTimer.Interval = TimeSpan.FromMilliseconds(1000);
            _dispTimer.Tick += new EventHandler(dispTimer_Tick);
            _dispTimer.Start();
        }
        void dispTimer_Tick(object sender, EventArgs e)
        {
            //сначала выводится значение, потом инкрементируется
            //меняем цвет таймера на красный когда остается мало времени
            if (_dispTimerCounter <= (0.998 * MaxTimerCounter))//вместо 0.998 ввести значение в долях когда время станет красным
            {
                InfoTextBlock.Foreground = Brushes.Red;
            }

            if ((_dispTimerCounter % 60) == 0)
            {
                InfoTextBlock.Text = $"{(_dispTimerCounter / 60).ToString()}:{(_dispTimerCounter % 60).ToString()}0";
            }
            else
            {
                InfoTextBlock.Text = $"{(_dispTimerCounter / 60).ToString()}:{(_dispTimerCounter % 60).ToString()}";
            }
            _dispTimerCounter--;

            if (_dispTimerCounter < MinTimerCounter)
            {
                _dispTimer.Stop();
                new Window3().Show();
                this.Close();
            }
        }

        private void ButtonEndTest_Click(object sender, RoutedEventArgs e)
        {
            _dispTimer.Stop();
            new Window3().Show();
            this.Close();
        }
    }
}
