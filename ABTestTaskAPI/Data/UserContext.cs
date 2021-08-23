using ABTestTaskAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ABTestTaskAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
