using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Registration.Controllers;

namespace Registration
{
    public class Startup
    {
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc ();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    //options.ExpireTimeSpan = TimeSpan.FromMinutes(5); //раскоментировать когда понядобится больше времени на аутентификацию
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
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
            app.UseRouting ();

            app.UseAuthentication ();
            app.UseAuthorization ();


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
