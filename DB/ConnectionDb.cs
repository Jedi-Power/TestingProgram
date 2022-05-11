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
