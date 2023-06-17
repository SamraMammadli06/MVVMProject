using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace MesengerApp.Data.Repositories
{
    public class UserDapperRepos
    {
        private const string connectionString = $"Server=localhost;Database=MesengerAppDb;Trusted_Connection=True;TrustServerCertificate=True;"; 
        private SqlConnection connection;
        userRepository userRepository =new userRepository();
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
        public void UpdateUser(int id,string name, string password,string email,string surname)
        {
            var query = $@"UPDATE Users
                        SET Name = @name, Password = @password, Email = @email, Surname = @surname
                        WHERE Id=@id;";
            this.connection.Execute(sql: query, new { id, name, password,email,surname });

        }
        public void SendChat(int id, string name, string tittle, string message)
        {
            if (name != null )
            {
                var users = userRepository.GetUsers(id);
                if(users.Any(u=>u.Name==name) ) {
                    var query = @$"DECLARE @ReceiverId AS INT
                                SELECT @ReceiverId = id
                                FROM Users
                                WHERE Name = @name
                                print @ReceiverId
                                insert into Chats(Message,Title,SenderId,RecieverId)
                                values (@message,@tittle,@id,@ReceiverId)";

                    this.connection.Execute(sql: query, new { id, name, message, tittle});
                }
            }
        }
    }
}
