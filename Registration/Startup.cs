using Microsoft.AspNetCore.Builder;

namespace Registration
{
    public class Startup
    {
        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc ();
        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting ();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern:"{controller=Home}/{action=HomePage}");

                endpoints.MapControllerRoute(
                    name: "AllPage",
                    pattern: "{hotel}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "RoomPage",
                    pattern: "hotel/{hotelId}/room/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "BookedPage",
                    pattern: "hotel/{hotelId}/room/{roomid}/booked/{action}/{id?}");
            });
        }
    }
}
