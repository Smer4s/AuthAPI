using AuthAPI.Controllers;
using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            builder.Services.AddScoped<Repository>();

            var serviceProvider = builder.Services.BuildServiceProvider();
            var repository = serviceProvider.GetRequiredService<Repository>();
            DBValidator.Initialize(repository);

            // Add services to the container.
            builder.Services.AddControllers(); // Register controllers

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controllers to endpoints
            });

            app.Run();
        }
    }
}
