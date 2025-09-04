using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Registration.Context;
using Registration.Context.Repository.BookedRepository;
using Registration.Context.Repository.HomeRepository;
using Registration.Context.Repository.HotelRepository;
using Registration.Context.Repository.RoomRepository;
using Registration.Context.Repository.UserRepository;
using Registration.Controllers;
using Registration.Model.Hotels;
using Registration.Model.Users;
using System.Globalization;

namespace Registration
{
    public class Startup
    {
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc ();

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql("WebApiDatabase"));

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer("MSSqlServer"));

            services.AddScoped<HotelService>();
            services.AddScoped<IHotelRepository<Hotel>, HotelRepository>();

            services.AddScoped<RoomService>();
            services.AddScoped<IRoomRepository<Room>, RoomRepository>();

            services.AddScoped<BookedService>();
            services.AddScoped<IBookedRepository<Booked>, BookedRepository>();

            services.AddScoped<UserService>();
            services.AddScoped<IUserRepository<AppUser>, UserRepository>();

            services.AddScoped<HomeService>();
            services.AddScoped<IHomeRepository, HomeRepository>();

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //настройки пароля
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                //настройки блокировки
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //настройки пользователя
                options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890-._@+";
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("Managers", policy =>
                    policy.RequireRole("Admin", "Manager"));

                options.AddPolicy("Users", policy =>
                    policy.RequireRole("Admin", "User", "Manager"));
            });
            
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{action=HomePage}/{id?}");

                endpoints.MapControllerRoute(
                    name: "RoomPage",
                    pattern: "hotel/{hotelId}/room/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "BookedPage",
                    pattern: "hotel/{hotelId}/room/{roomId}/booked/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "BookedPageCreateDate",
                    pattern: "hotel/{hotelId}/room/{roomId}/booked/{action}/{id}/{dateStartBooked}/{dateEndBooked}");
            });
        }
    }
}


// описание API

// пользователь без авторизации:
// => Home/HomePage => Find/List => Booked/Create => Complete
//                                                => Account/Registration => Account/Successful
// => Home/HomePage => Account/Login
//                  => Account/Login => Account/Registration => Account/Successful

// пользователь с авторизацией (AppUser)
// => Home/HomePage => Find/List => Booked/Create => Complete
// => Account/Profile => Account/Correct
//                    => Account/Delete
// => Booked/MyList 
//                  => Booked/Delete
//                  => Booked/Correct

// пользователь с авторизацией (Manager)
// => Home/HomePage => Find/List => Booked/Create => Complete
// => Account/Profile => Account/Correct
// => Hotel/Profile => Hotel/Correct
// => Room/HotelList => Room/Create
//                   => Room/Correct
//                   => Room/Delete
// => Booked/HotelList => Booked/Create
//                     => Booked/Correct
//                     => Booked/Delete

// пользователь с авторизацией (Admin)
// (...)
// => Account/List
// => Hotel/List => Hotel/Create
//               => Hotel/Correct
//               => Hotel/Delete
// => Room/ListAll => Room/Create
//                 => Room/Correct
//                 => Room/Delete
// => Booked/ListAll => Booked/Create
//                   => Booked/Correct
//                   => Booked/Delete


// Задачи
//- добавить проверки во все сервисы!