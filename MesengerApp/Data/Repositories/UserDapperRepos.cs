using Dapper;
using Microsoft.Data.SqlClient;

namespace MesengerApp.Data.Repositories
{
    public class UserDapperRepos
    {
        private const string connectionString = $"Server=localhost;Database=MessengerAppDb;User Id=admin;Password=admin;TrustServerCertificate=True;";
        private SqlConnection connection;

        public UserDapperRepos()
        {
            this.connection = new SqlConnection(connectionString);
        }
        public string GetUsersCount()
        {
            var query = $@"select count(*)
                           from Users";
           var count =  this.connection.ExecuteScalar<int>(sql: query);
            return count.ToString();
        }
        public string GetMessagesCount()
        {
            var query = $@"select count(*)
                           from Chats";
            var count = this.connection.ExecuteScalar<int>(sql: query);
            return count.ToString();
        }
        public string GetGroupsCount()
        {
            var query = $@"select count(*)
                           from Groups";
            var count = this.connection.ExecuteScalar<int>(sql: query);
            return count.ToString();
        }
        public void UpdateUser(int id,string name, string password,string email,string surname)
        {
            var query = $@"UPDATE Users
                        SET Name = @name, Password = @password, Email = @email, Surname = @surname
                        WHERE Id=@id;";
            this.connection.Execute(sql: query, new { id, name, password,email,surname });

        }
    }
}
