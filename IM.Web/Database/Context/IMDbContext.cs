using IM.Web.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace IM.Web.Database.Context
{
    public class IMDbContext : DbContext
    {

        public virtual DbSet<AssetEntity> Assets { get; set; }

        public virtual DbSet<BatchEntity> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("IMDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
