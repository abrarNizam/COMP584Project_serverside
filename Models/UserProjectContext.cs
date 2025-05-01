using Microsoft.EntityFrameworkCore;

namespace Portfolio.Server.Models
{
    public class UserProjectContext : DbContext
    {
        public UserProjectContext(DbContextOptions<UserProjectContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfiles> UserProfiles { get; set; } 
        public DbSet<Projects> Projects { get; set; } 
    }
}
