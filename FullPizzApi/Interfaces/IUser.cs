using FullPizzApi.Models;

namespace FullPizzApi.Interfaces
{
    public interface IUser
    {
        IList<User> GetUsers();
        User GetUserById(int id);
        User GetUserByName(string FullName);
        User AddUser(User user);
        User UpdateUser(User user);
        User DeleteUser(int id);


    }
}
