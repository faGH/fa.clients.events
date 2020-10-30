using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FrostAura.Clients.Events.Data.Factories.DesignTime
{
    /// <summary>
    /// DB context factory for running migrations in design time.
    /// This allows for running migrations in the .Data project independently.
    /// </summary>
    public class EventsDbContextDesignTimeFactory : IDesignTimeDbContextFactory<EventsDbContext>
    {
        /// <summary>
        /// Factory method for producing the design time db context
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Database context.</returns>
        public EventsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Migrations.json")
                .Build();
            var builder = new DbContextOptionsBuilder<EventsDbContext>();
            var connectionString = configuration
                .GetConnectionString("EventsDbConnection");

            builder.UseSqlServer(connectionString);

            Console.WriteLine($"Used connection string for configuration db: {connectionString}");

            return new EventsDbContext(builder.Options);
        }
    }
}
