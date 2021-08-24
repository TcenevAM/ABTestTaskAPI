using ABTestTaskAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ABTestTaskAPI.extensions;
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

        public void AddOrUpdateUser(User user)
        {
            context.Users.AddOrUpdate(user);
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
