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

        public void AddOrUpdateUsers(IEnumerable<User> users)
        {
            foreach(var user in users)
            {
                AddOrUpdate(user);
            }
        }

        private void AddOrUpdate(User user)
        {

            context.Users.AddOrUpdate(user);

            //switch (entry.State)
            //{
            //    case EntityState.Detached:
            //        context.Set<User>().Add(user);
            //        break;
            //    case EntityState.Modified:
            //        context.Set<User>().Update(user);
            //        break;
            //    case EntityState.Added:
            //        context.Set<User>().Add(user);
            //        break;
            //    case EntityState.Unchanged:
            //        //item already in db no need to do anything  
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
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
