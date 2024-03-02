using IMU.Perfomance.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMU.Perfomance.Api.Applications.Contracts
{
    public interface IPerformanceDbContext
    {
        DbSet<Agreement> Agreements { get; }

        DbSet<KeyPerformanceArea> KeyPerfomanceAreas { get;}

        DbSet<KeyPerformanceIndicator> KeyPerformanceIndicators { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
