using servicefirst.Data;
using System;
using Microsoft.EntityFrameworkCore; // For EF Core
using MySql.EntityFrameworkCore.Extensions;
using servicefirst.Services;
using servicefirst.serviceimp; // For MySQL-specific EF Core extensions


namespace servicefirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Retrieve the connection string from the configuration
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string 'DefaultConnection' is not configured correctly.");
            }

            // Configure DbContext with MySQL
            builder.Services.AddDbContext<ContextClass>(options =>
            {
                // Use the connection string to set up MySQL
                options.UseMySQL(connectionString);
            });

            builder.Services.AddScoped<Iproduct, productserviceimp>();
            

            // Add services to the container
            builder.Services.AddControllers();

            // Swagger setup for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
