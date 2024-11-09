using servicefirst.Models;

using System;
using Microsoft.EntityFrameworkCore; // For general EF Core functionality
using MySql.EntityFrameworkCore.Extensions;

namespace servicefirst.Data
{
    public class ContextClass:DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> options) : base(options)
        {
        }

        public DbSet<product> Products { get; set; }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                // Execute a simple query to test the connection
                await Database.OpenConnectionAsync();
                await Database.GetDbConnection().CloseAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
