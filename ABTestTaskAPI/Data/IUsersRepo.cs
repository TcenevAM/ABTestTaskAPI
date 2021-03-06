using ABTestTaskAPI.Models;
using System.Collections.Generic;

namespace ABTestTaskAPI.Data
{
    public interface IUsersRepo
    {
        IEnumerable<User> GetAllUsers();
        bool SaveChanges();
        void AddOrUpdateUser(User users);
        User GetUserById(int id);
    }
}
