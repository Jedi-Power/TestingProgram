﻿using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DB;
using Microsoft.Win32;

namespace TestingProgram1.App
{
    public partial class AdminWindow : Window
    {
        string theme = "";// в переменную сохраняется выбранная тема теста
        string imagePath = "";
        public AdminWindow()
        {
            InitializeComponent();

            
        }
        private async void AdminWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new RequestDb();
            await db.GetSubjectAsync();
            List<string> subj = new List<string>();

            for (int i = 0; i < db._subjects.Count; i++)
            {
                subj.Add(db._subjects[i].Name);
            };

            ListTest.ItemsSource = subj;
        }

        private void ListTest_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            theme = ListTest.SelectedItem.ToString();
        }

        private void MenuTop_DragAndDrop(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Close_Window(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Minimize_Window(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void ButtonAddTest_Click(object sender, RoutedEventArgs e)
        {
            string comand = $"INSERT INTO tab_Subjects(name, allotted_time) VALUES(N'{TextBoxSubject.Text}',{int.Parse(TextBoxTestTime.Text)})";
            RequestDb requestDb = new RequestDb();
            await requestDb.RequestExecuteNonQueryAsync(comand);
            MessageBox.Show("Новый тест добавлен!");
            TextBoxSubject.Text = "";
            TextBoxTestTime.Text = "";
        }

        //добавление вопроса
        private async void ButtonAddQuestionToTest_Click(object sender, RoutedEventArgs e)
        {

            int subjectId = 0;
            int questionId = 0;
            int answerId = 0;
            
            var db = new RequestDb();
            await db.GetSubjectAsync();
            for (int i = 0; i < db._subjects.Count; i++)
            {
                if (db._subjects[i].Name == theme)
                    subjectId = db._subjects[i].Id;
            }

            //позже прописать логику добавления вопроса с картинкой
            var comandAddQuestion = $"INSERT INTO tab_Questions(ask_question, question_number) VALUES(N'{TextBoxQuestion.Text}',{int.Parse(TextBoxQuestionNumber.Text)})";
            RequestDb requestDb = new RequestDb();
            await requestDb.RequestExecuteNonQueryAsync(comandAddQuestion);

            //получаем questionID
            var comand1 = $"SELECT id FROM tab_Questions WHERE ask_question = '{TextBoxQuestion.Text}'";
            ConnectionDb _connectDb1 = new ConnectionDb(comand1);
            await _connectDb1.ConnectionOpenAsynk();
            using (DbDataReader reader = await _connectDb1.GetCmd().ExecuteReaderAsync())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        questionId = reader.GetInt32(0);
                    }
                }
            }
            await _connectDb1.ConnectionCloseAsync();

            if (TextBoXAnswer1.Text != "Ответ 1")
            {
                var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{TextBoXAnswer1.Text}',{int.Parse(TextBoXAnswerGrade1.Text)})";
                RequestDb requestDb1 = new RequestDb();
                await requestDb1.RequestExecuteNonQueryAsync(comandAddAnsver);

                //получаем ansverID
                var comand = $"SELECT id FROM tab_Ansvers WHERE answer_option = '{TextBoXAnswer1.Text}'";
                ConnectionDb _connectDb = new ConnectionDb(comand);
                await _connectDb.ConnectionOpenAsynk();
                using (DbDataReader reader = await _connectDb.GetCmd().ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            answerId = reader.GetInt32(0);
                        }
                    }
                }
                await _connectDb.ConnectionCloseAsync();

                //добавляем запись в таблицу Tests
                var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({questionId},{answerId},{subjectId})";//(без изображения)
                requestDb = new RequestDb();
                await requestDb.RequestExecuteNonQueryAsync(comandAddTest);
            }

            if (TextBoXAnswer2.Text != "Ответ 2")
            {
                var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{TextBoXAnswer2.Text}',{int.Parse(TextBoXAnswerGrade2.Text)})";
                RequestDb requestDb1 = new RequestDb();
                await requestDb1.RequestExecuteNonQueryAsync(comandAddAnsver);

                //получаем ansverID
                var comand = $"SELECT id FROM tab_Ansvers WHERE answer_option = '{TextBoXAnswer2.Text}'";
                ConnectionDb _connectDb = new ConnectionDb(comand);
                await _connectDb.ConnectionOpenAsynk();
                using (DbDataReader reader = await _connectDb.GetCmd().ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            answerId = reader.GetInt32(0);
                        }
                    }
                }
                await _connectDb.ConnectionCloseAsync();


                //добавляем запись в таблицу Tests
                var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({questionId},{answerId},{subjectId})";//(без изображения)
                requestDb = new RequestDb();
                await requestDb.RequestExecuteNonQueryAsync(comandAddTest);
            }

            if (TextBoXAnswer3.Text != "Ответ 3")
            {
                var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{TextBoXAnswer3.Text}',{int.Parse(TextBoXAnswerGrade3.Text)})";
                RequestDb requestDb1 = new RequestDb();
                await requestDb1.RequestExecuteNonQueryAsync(comandAddAnsver);

                //получаем ansverID
                var comand = $"SELECT id FROM tab_Ansvers WHERE answer_option = '{TextBoXAnswer3.Text}'";
                ConnectionDb _connectDb = new ConnectionDb(comand);
                await _connectDb.ConnectionOpenAsynk();
                using (DbDataReader reader = await _connectDb.GetCmd().ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            answerId = reader.GetInt32(0);
                        }
                    }
                }
                await _connectDb.ConnectionCloseAsync();


                //добавляем запись в таблицу Tests
                var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({questionId},{answerId},{subjectId})";//(без изображения)
                requestDb = new RequestDb();
                await requestDb.RequestExecuteNonQueryAsync(comandAddTest);
            }

            if (TextBoXAnswer4.Text != "Ответ 4")
            {
                var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{TextBoXAnswer4.Text}',{int.Parse(TextBoXAnswerGrade4.Text)})";
                RequestDb requestDb1 = new RequestDb();
                await requestDb1.RequestExecuteNonQueryAsync(comandAddAnsver);

                //получаем ansverID
                var comand = $"SELECT id FROM tab_Ansvers WHERE answer_option = '{TextBoXAnswer4.Text}'";
                ConnectionDb _connectDb = new ConnectionDb(comand);
                await _connectDb.ConnectionOpenAsynk();
                using (DbDataReader reader = await _connectDb.GetCmd().ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            answerId = reader.GetInt32(0);
                        }
                    }
                }
                await _connectDb.ConnectionCloseAsync();


                //добавляем запись в таблицу Tests
                var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({questionId},{answerId},{subjectId})";//(без изображения)
                requestDb = new RequestDb();
                await requestDb.RequestExecuteNonQueryAsync(comandAddTest);
            }

            if (TextBoXAnswer5.Text != "Ответ 5")
            {
                var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{TextBoXAnswer5.Text}',{int.Parse(TextBoXAnswerGrade5.Text)})";
                RequestDb requestDb1 = new RequestDb();
                await requestDb1.RequestExecuteNonQueryAsync(comandAddAnsver);

                //получаем ansverID
                var comand = $"SELECT id FROM tab_Ansvers WHERE answer_option = '{TextBoXAnswer5.Text}'";
                ConnectionDb _connectDb = new ConnectionDb(comand);
                await _connectDb.ConnectionOpenAsynk();
                using (DbDataReader reader = await _connectDb.GetCmd().ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            answerId = reader.GetInt32(0);
                        }
                    }
                }
                await _connectDb.ConnectionCloseAsync();


                //добавляем запись в таблицу Tests
                var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({questionId},{answerId},{subjectId})";//(без изображения)
                requestDb = new RequestDb();
                await requestDb.RequestExecuteNonQueryAsync(comandAddTest);
            }
        }

        private void ButtonLoadImage_Click(object sender, RoutedEventArgs e)
        {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                imagePath = openFileDialog.FileName;

            MessageBox.Show(imagePath);
        }
    }
}