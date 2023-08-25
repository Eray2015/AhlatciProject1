using WebService.Business;
using WebService.WebAPI;
using WebService.WebAPI.Middlewares;

namespace WebService.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddApiService(builder.Configuration);
            builder.Services.AddBusinessServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();

            app.Run();
        }
    }
}