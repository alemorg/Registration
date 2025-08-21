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
                endpoints.MapControllerRoute("Default",
                    "{controller=Home}/{action=HomePage}");

                endpoints.MapControllerRoute("AllPage",
                    "{hotel}/{action}/{id?}");

                endpoints.MapControllerRoute("RoomPage",
                    "hotel/{hotelid}/room/{action}/{id?}");

                endpoints.MapControllerRoute("BookedPage",
                    "hotel/{hotelid}/room/{roomid}/booked/{action}/{id?}");
            });
        }
    }
}
