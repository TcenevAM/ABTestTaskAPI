using ABTestTaskAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ABTestTaskAPI.Data
{
    public class SqlUsersRepo : IUsersRepo
    {
        private readonly UserContext context;
        public SqlUsersRepo(UserContext context)
        {
            this.context = context;
        }
        public void CreateNewUser(User user)
        {
            context.Users.Add(user);
        }

        public void CreateNewUsers(IEnumerable<User> users)
        {
            context.Users.AddRange(users);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.Users;
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}
