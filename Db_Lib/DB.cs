using System.Collections.Generic;
using System.IO;
using Data_Model;
using MySql.Data.MySqlClient;

namespace Db_Lib
{
    public class DB
    {
        private MySqlConnection _db;
        private MySqlCommand _command;

        public DB()
        {
            _db = new MySqlConnection(GetConnectionString());
            _command = new MySqlCommand {Connection = _db};
        }

        private static string GetConnectionString()
        {
            using var file = new StreamReader("connection_to_db.ini");
            return file.ReadToEnd();
        }

        public List<Test> GetAllTests()
        {
            var tests = new List<Test>();
            
            _db.Open();
            _command.CommandText = "SELECT id, questionId, ansverId, subjectId FROM testingdb.tab_tests";
            var result = _command.ExecuteReader();
            while (result.Read())
            {
                var test = new Test
                {
                    Id = result.GetInt32("id"),
                    QuestionId = result.GetInt32("questionId"),
                    AnsverId = result.GetInt32("ansverId"),
                    SubjectId = result.GetInt32("subjectId")
                };
                tests.Add(test);
            }
            
            _db.Close();

            return tests;
        }

        public bool UpdateTest(Test test)
        {
            _db.Open();
            _command.CommandText = $@"UPDATE testingdb.tab_tests
                            SET questionId = '{test.QuestionId}',
                                ansverId = '{test.AnsverId}',
                                subjectId = '{test.SubjectId}'
                                WHERE id = {test.Id}";
            var res = _command.ExecuteNonQuery();
            
            _db.Close();
            
            return res == 1;
        }
    }
}