using System;
using System.Collections.Generic;
using System.IO;
using Data_Model;
using Db_Lib;

namespace Users.ConsoleTest
{
    class Program
    {
        static void Main()
        {
            var db = new DB();
            var tests = db.GetAllTests();
            ShowUsers(tests);
        }

        private static void ShowUsers(List<Test> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.QuestionId}, {user.AnsverId}, {user.SubjectId}");
            }
        }
    }
}