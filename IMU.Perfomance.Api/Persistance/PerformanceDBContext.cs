using IMU.Perfomance.Api.Applications.Contracts;
using IMU.Perfomance.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMU.Perfomance.Api.Persistance
{
    public class PerformanceDBContext : DbContext, IPerformanceDbContext
    {
        public PerformanceDBContext(DbContextOptions<PerformanceDBContext> options) :base(options)
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PerformanceDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Agreement> Agreements => Set<Agreement>();
        public DbSet<KeyPerformanceArea> KeyPerfomanceAreas => Set<KeyPerformanceArea>();
        public DbSet<KeyPerformanceIndicator> KeyPerformanceIndicators => Set<KeyPerformanceIndicator>();
    }
}
