using IMU.Perfomance.Api.DTO;

namespace IMU.Perfomance.Api.Applications.Contracts
{
    public interface IAgreement
    {
        Task<IEnumerable<AgreementDTO>> Getagreements();
        Task CreateAgreement(AgreementDTO agreementDTO, CancellationToken cancellationToken);

        Task AddKpa(KeyPerformanceAreaDTO keyPerfomanceAreaDTO, CancellationToken cancellationToken = default);
    }
}
