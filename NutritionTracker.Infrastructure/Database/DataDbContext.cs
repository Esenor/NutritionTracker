using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NutritionTracker.Domain.Entities;
using NutritionTracker.Infrastructure.Database.EntityConfigurations;

namespace NutritionTracker.Data
{
    public class DataDbContext(DbContextOptions<DataDbContext> options, IConfiguration config): DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbConnection = config.GetSection("Values").GetSection("DBConnection").Value ?? "";
            optionsBuilder.UseNpgsql(dbConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
