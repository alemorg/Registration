using Microsoft.EntityFrameworkCore;
using Registration.Model.Hotels;
using Registration.Model.Users;
using System.Configuration;

namespace Registration.Context
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration configuration;

        //public AppDbContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseNpgsql(configuration.GetConnectionString("PostgreSqlServer"));
        //}

        public AppDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("MSSqlServer"));
        }

        public DbSet<AppUser> Users { get; set; }


        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Booked> Bookeds { get; set; }
    }
}
