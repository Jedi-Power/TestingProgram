using Microsoft.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace DB
{
    public class ConnectionDb
    {
        private SqlConnection _connection;
        private SqlCommand _cmd;

        public ConnectionDb(string comand)
        {
            _connection = new SqlConnection(GetConnectionString());
            _cmd = new SqlCommand(comand, _connection);
        }
        private static string GetConnectionString()
        {
            using var file = new StreamReader("connection_db.ini");
            return file.ReadToEnd();
        }
        public SqlCommand GetCmd() => _cmd;
        public async Task ConnectionOpenAsynk() => await _connection.OpenAsync();
        public async Task ConnectionCloseAsync() => await _connection.CloseAsync();
    }
}

//string comand= "Select * from tab_Users";
//var comand = "Select * from tab_Authorizations";

//var comandAddUser = $"INSERT INTO tab_Users(firstName,lastName,middleName,groupId,authorizationId) VALUES(N'{firstName}',N'{lastName}',N'{middleName}',{groupId},{autorizId})";
//var comandAddGroups = $"INSERT INTO tab_Groups(name) VALUES(N'{_name}')";
//var comandAddAuthoriz = $"INSERT INTO tab_Authorizations(login,password,roleId) VALUES('{login}','{password}',{roleId})";
//var comandAddQuestion = $"INSERT INTO tab_Questions(ask_question, question_number) VALUES(N'{question}',{questionNumber})";
//var comandAddAnsver = $"INSERT INTO tab_Ansvers(answer_option, scores) VALUES(N'{ansver}',{score})";
//var comandAddSubject = $"INSERT INTO tab_Subjects(name, allotted_time) VALUES(N'{_name}',{_time})";
//var comandAddTest = $"INSERT INTO tab_Tests(questionId, ansverId,subjectId) VALUES({_questionId},{_ansverId},{_subjectId})";//(без изображения)
//var comandAddGroups = $"INSERT INTO tab_Results VALUES({_userId},{_date},{time},{_evalution},{TestId})";
//var comandDelete = $"DELETE FROM tab_Users Where id = _id";
//var comandUpdate = $"UPDATE tab_Users SET lastName = N'Пупкин' WHERE id = _id";