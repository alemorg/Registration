using Microsoft.EntityFrameworkCore;
using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context
{
    public class BookedDB : DbContext
    {
        public DbSet<RegistrationUser> User { get; set; }
        

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<BookedRoom> BookedRoom { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BookedDB; Trusted_Connection=true");
        }
    }
}
