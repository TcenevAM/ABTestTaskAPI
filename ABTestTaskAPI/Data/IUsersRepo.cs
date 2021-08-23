using ABTestTaskAPI.Models;
using System.Collections.Generic;

namespace ABTestTaskAPI.Data
{
    public interface IUsersRepo
    {
        IEnumerable<User> GetAllUsers();
        bool SaveChanges();
        void CreateNewUsers(IEnumerable<User> users);
        void CreateNewUser(User user);
        User GetUserById(int id);
    }
}
