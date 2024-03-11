using HackatonApp.Models.Tables;
using HackatonApp.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

namespace HackatonApp.Services.Core
{
    public class MyContext(IOptions<DatabaseSettings> databaseSettings, ILogger<MyContext> logger) : DbContext
    {
        private readonly DatabaseSettings _databaseSettings = databaseSettings.Value;
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            logger.LogDebug("Configuring database connection");
            var connectionString = Encoding.UTF8.GetString(Convert.FromBase64String(_databaseSettings.ConnectionString));
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        #region Tables
        
        public DbSet<Users> Users { get; set; } = null!;
        
        #endregion
        
    }
}
