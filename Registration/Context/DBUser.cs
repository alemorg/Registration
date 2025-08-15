using Microsoft.EntityFrameworkCore;
using Registration.Model;

namespace Registration.Context
{
    public class DBUser : DbContext
    {
        public DbSet<RegistrationUser> UserInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Users; Trusted_Connection=true");
        }
    }
}
