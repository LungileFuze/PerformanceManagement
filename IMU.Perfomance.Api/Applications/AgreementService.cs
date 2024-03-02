using IMU.Perfomance.Api.Applications.Contracts;
using IMU.Perfomance.Api.Domain.Entities;
using IMU.Perfomance.Api.Domain.Exceptions;
using IMU.Perfomance.Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace IMU.Perfomance.Api.Applications
{
    public class AgreementService : IAgreement
    {
        private readonly IPerformanceDbContext _context;

        public AgreementService(IPerformanceDbContext context)        {
            _context = context;
        }

        public async Task<IEnumerable<AgreementDTO>> Getagreements()
        {
            return await _context.Agreements.Select(a => new AgreementDTO
            {
                Id = a.Id,
                FinancialYear = a.FinancialYear,
                ManagerServiceNumber = a.ManagerServiceNumber,
                ServiceNumber = a.ServiceNumber,
                Status = (int)a.Status,
                KeyPerformanceAreas = a.KeyPerformanceAreas.Select(k => new KeyPerformanceAreaDTO
                {
                    Id= k.Id,
                    Description = k.Description,
                    Weighting = k.Weighting,
                    ManagerComment = k.ManagerComment,
                    ModeratorComment = k.ModeratorComment,
                }).
                ToList()
            }).
            ToListAsync();
        }

        public async Task CreateAgreement(AgreementDTO agreementDTO, CancellationToken cancellationToken = default) 
        { 
            if (agreementDTO == null) throw new ArgumentNullException(nameof(agreementDTO));
            Agreement? agreement = await _context.Agreements.FirstOrDefaultAsync(a => a.ServiceNumber == agreementDTO.ServiceNumber && a.FinancialYear == agreementDTO.FinancialYear);
            if (agreement != null) throw new InvalidActionException("Agreement already exists");
            agreement = new Agreement(agreementDTO.FinancialYear, agreementDTO.ServiceNumber, agreementDTO.ManagerServiceNumber);
            _context.Agreements.Add(agreement);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddKpa(KeyPerformanceAreaDTO keyPerformanceAreaDTO, CancellationToken cancellationToken = default)
        {
            if(keyPerformanceAreaDTO == null) throw new ArgumentNullException(nameof(keyPerformanceAreaDTO));
            Agreement? agreement = await _context.Agreements.FirstOrDefaultAsync(a => a.Id == keyPerformanceAreaDTO.AgreementId) ?? throw new NotFoundException("Could not find agreement");
            agreement.AddKeyPerfomanceArea(keyPerformanceAreaDTO.Description, keyPerformanceAreaDTO.Weighting);
            await _context.SaveChangesAsync(cancellationToken);
        }

       
    }
}
