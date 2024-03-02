using IMU.Perfomance.Api.Applications.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace IMU.Perfomance.Api.Persistance
{
    public static class PersistanceConfigurationExtentions
    {
        public static IServiceCollection ConfigurePesistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IPerformanceDbContext, PerformanceDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PerformanceConnection"));
            });
            return services;
        }
    }
}
