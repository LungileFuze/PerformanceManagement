using IMU.Perfomance.Api.Applications.Contracts;
using IMU.Perfomance.Api.Domain.Entities;
using IMU.Perfomance.Api.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMU.Perfomance.Api.Controllers
{
    [Route("agreements")]
    public class AgreementsController : ApiBaseController
    {
        private readonly IAgreement _agreement;
        public AgreementsController(IAgreement agreement) 
        { 
            _agreement = agreement;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgreementDTO>>> GetAgreements()
        {
            IEnumerable<AgreementDTO> agreements = await _agreement.Getagreements();
            return Ok(agreements);  
        }
        [HttpPost]
        public async Task<ActionResult> CreateAgreement(AgreementDTO agreementDTO)
        {
            if (agreementDTO == null) return BadRequest();
            await _agreement.CreateAgreement(agreementDTO, _cancellationTokenSource.Token);
            return Ok();
        }
        [HttpPost("{agreementId:long}/keyperformanceareas")]

        public async Task<ActionResult> AddKpa(long agreementId, KeyPerformanceAreaDTO keyPerfomanceAreaDTO)
        {
            if(keyPerfomanceAreaDTO == null) return BadRequest();   
            keyPerfomanceAreaDTO.AgreementId = agreementId;
            await _agreement.AddKpa(keyPerfomanceAreaDTO, _cancellationTokenSource.Token);
            return Ok();
        }

        //[HttpPut("{agreementId:long}")]
        //public async Task<ActionResult> SendForApproval(long agreementId)
        //{
        //    Agreement? agreement = await _performanceDbContext.Agreements.FirstOrDefaultAsync(a => a.Id == agreementId);
        //    if(agreement == null) return NotFound();
        //    agreement.SendForApproval();
        //    await _performanceDbContext.SaveChangesAsync(_cancellationTokenSource.Token);
        //    return Ok();
        //}
    }
}
