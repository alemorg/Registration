using Microsoft.EntityFrameworkCore;
using Registration.Model.Hotels;
using Registration.Model.Users;

namespace Registration.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<RegistrationUser> User { get; set; }


        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Booked> Booked { get; set; }
    }
}
