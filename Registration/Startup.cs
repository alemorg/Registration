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

                endpoints.MapControllerRoute("HotelPage",
                    "{controller}/{action}/{id?}");
            });
        }
    }
}
