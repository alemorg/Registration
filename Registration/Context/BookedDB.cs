using Microsoft.EntityFrameworkCore;
using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context
{
    public class BookedDB : DbContext
    {
        public DbSet<RegistrationUser> UserInfo { get; set; }
        public DbSet<Room> RoomInfo { get; set; }

        public DbSet<Hotel> HotelInfo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=BookedDB; Trusted_Connection=true");
        }
    }
}
