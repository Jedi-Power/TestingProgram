namespace TestingProgram.App
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public User() { }
        public User(string _login, string _password, string _email)
        {
            login = _login;
            password = _password;
            email = _email;
        }
    }
}