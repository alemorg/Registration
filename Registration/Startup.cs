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