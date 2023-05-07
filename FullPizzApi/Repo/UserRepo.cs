using FullPizzApi.Data;
using FullPizzApi.Interfaces;
using FullPizzApi.Models;

namespace FullPizzApi.Repo
{
    public class UserRepo : IUser
    {
        private readonly AppDbContext db;
        public UserRepo(AppDbContext db) 
        {
            this.db = db;
        }

        public IList<User> GetUsers()
        {
           return db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return db.Users.SingleOrDefault(a => a.Id == id);
        }

        public User GetUserByName(string FullName)
        {
            return db.Users.SingleOrDefault(a => a.FullName == FullName);
        }
        public User AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
            return user;
        }

        public User DeleteUser(int id)
        {
            var delete = db.Users.FirstOrDefault(a => a.Id == id);
            db.Users.Remove(delete);
            db.SaveChanges();
            return delete;

        }

    }
}
