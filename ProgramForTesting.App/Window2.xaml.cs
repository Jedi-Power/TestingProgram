using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
<<<<<<< Updated upstream
=======
using DB;
using Models.lib;
>>>>>>> Stashed changes

namespace ProgramForTesting.App
{
    public partial class Window2 : Window
    {
        const int MaxTimerCounter = 3600;//сюда присвоить время прохождения теста
        const int MinTimerCounter = 0;
<<<<<<< Updated upstream

=======
        
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

        //
        private async void GetQuestions()
        {
            //получение questionid answerid по известному subjectid
            var db = new RequestDb();
            await db.GetTestAsync();
            List<Test> currentTest = new List<Test>();
            for (int i = 0; i < db._tests.Count; i++)
            {
                if (db._tests[i].SubjectId == ForAll.subjectID)
                {
                    currentTest.Add(new Test
                    {
                        Id = db._tests[i].Id,
                        QuestionId = db._tests[i].QuestionId,
                        AnsverId = db._tests[i].AnsverId
                    });
                }
            }
        }
        
>>>>>>> Stashed changes
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
                Close();
            }
        }

        private void ButtonEndTest_Click(object sender, RoutedEventArgs e)
        {
            _dispTimer.Stop();
            new Window3().Show();
            Close();
        }
    }
}
