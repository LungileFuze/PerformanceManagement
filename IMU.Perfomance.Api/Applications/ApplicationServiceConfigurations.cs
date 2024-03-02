using IMU.Perfomance.Api.Applications.Contracts;

namespace IMU.Perfomance.Api.Applications
{
    public static class ApplicationServiceConfigurations
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IAgreement, AgreementService>();
        }
    }
}
