using Dapper;
using DapperCrudApi.Helpers;
using DapperCrudApi.Interface;
using DapperCrudApi.Mdels;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DapperCrudApi.Repository
{
    public class UserServices : IUserServices
    {
        private readonly IConfiguration _configuration;
        public UserServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<users> AllUsers()
        {
                using var connection = new SqlConnection(_configuration.GetConnectionString("Defaultconn"));
                var users = connection.Query<users>("select * from users where Delflag = 'false'");
                return users.ToList();
           
        }

        public bool createUser(users user)
        {

            string Hashpassword = PasswordHash.HashPass(user.Password);
            using var connection = new SqlConnection(_configuration.GetConnectionString("Defaultconn"));
            //var user = connection.Execute(" insert into users (Username, Password, DateCreated, Delflag, Address, Role) values " +
                //"('" + NewUser.Username + "', '" + Hpassword + "', '" + NewUser.DateCreated + "', '" + NewUser.Delflag + "', '" + NewUser.Address + "', '" + NewUser.role + "')");
            var NewUser = connection.Execute(" insert into users (Username, Password, DateCreated, Delflag, Address, Role) values" +
                "(@Username, @Password, @DateCreated, @Delflag, @Address, @Role)", new
                {
                    Username = user.Username,
                    Password = Hashpassword,
                    DateCreated = user.DateCreated,
                    Delflag = user.Delflag,
                    Address = user.Address,
                    Role = user.role
                });
            return true;
        }

        public bool deleteUser(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Defaultconn"));
            //var user = connection.Execute("update users set delflag = 'true' where id = @Id", new { Id = userId });// for soft deleting
            var user = connection.Execute("delete from users where id = @Id", new { Id = id });// for total deleting
            
            return true;
        }

        public users GetUser(int id)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Defaultconn"));

            var user = connection.QueryFirstOrDefault<users>("select * from users where id in (@Id) and Delflag = 'false'", new { Id = id });
            return user;

        }
        public bool updateUser(users user)
        {
            string password = PasswordHash.HashPass(user.Password);
            using var connection = new SqlConnection(_configuration.GetConnectionString("Defaultconn"));
            //var user = connection.Execute(" update users set username = '" + userDetails.Username + "', password = '" + password + "', datecreated='" + userDetails.DateCreated + "', delflag = '" + userDetails.Delflag + "', address = '" + userDetails.Address + "', role='" + userDetails.role + "' where id = '" + userDetails.Id + "' ");
            var Edituser = connection.Execute("update users set Username = @Username, Password = @Password, " +
                "DateCreated = @DateCreated, Delflag = @Delflag, Address = @Address, Role = @Role where id in (@Id)", new
                {
                    Username = user.Username,
                    Password = password,
                    DateCreated = user.DateCreated,
                    Delflag = user.Delflag,
                    Address = user.Address,
                    Role = user.role,
                    Id = user.Id
                });

            return true;
        }
    }
}
