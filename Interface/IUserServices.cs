using DapperCrudApi.Mdels;

namespace DapperCrudApi.Interface
{
    public interface IUserServices
    {
        List<users> AllUsers();
        users GetUser(int id);
        bool createUser(users user);
        bool updateUser(users user);
        bool deleteUser(int id);
    }
}
