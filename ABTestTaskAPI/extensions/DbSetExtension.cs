using ABTestTaskAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ABTestTaskAPI.extensions
{
    public static class DbSetExtension
    {
        public static void AddOrUpdate(this DbSet<User> dbSet, User record)
        {
            var exists = dbSet.AsNoTracking().Any(x => x.Id == record.Id);
            if (exists)
            {
                dbSet.Update(record);
                return;
            }
            dbSet.Add(record);
        }
    }
}