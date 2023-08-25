using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebService // Projenizin namespace'i ile değiştirin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(); // Razor Pages servislerini ekleyin

            // Diğer servisleri eklemeye devam edebilirsiniz
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages(); // Razor Pages endpoint'ini ekle
            });
        }
    }
}