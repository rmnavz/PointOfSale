using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.IO;

namespace PointOfSale.Persistence.Infrastructure
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = "DatabaseConnection";
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
        private string DbProvider = "MSSQL";

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}..{0}Presentation{0}PointOfSale.WinFormUI", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
            //return Create(@"Server=.\SQLEXPRESS;Database=Database;Trusted_Connection=True;");
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);
            DbProvider = configuration.GetSection("AppSettings").GetSection("DbProvider").Value;

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }

            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            switch (DbProvider)
            {
                case "MSSQL":
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                case "MYSQL":
                    optionsBuilder.UseMySql(connectionString, mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(10, 4, 8), ServerType.MariaDb);
                    });
                    break;
                default:
                    optionsBuilder.UseInMemoryDatabase($"PointOfSale_{Guid.NewGuid()}");
                    break;
            }

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
