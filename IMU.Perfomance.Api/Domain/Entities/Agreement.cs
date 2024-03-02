using IMU.Perfomance.Api.Domain.Enumeration;
using IMU.Perfomance.Api.Domain.Exceptions;

namespace IMU.Perfomance.Api.Domain.Entities
{
    public class Agreement : BaseEntity
    {
        public string FinancialYear { get; private set; } = null!;

        public string ServiceNumber { get; private set; } = null!;

        public string ManagerServiceNumber { get; private set; } = null!;

        public AgreementStatus Status { get; private set; }

        public List<KeyPerformanceArea> KeyPerformanceAreas { get; private set; } = new();

        public Agreement(string financialYear, string serviceNumber, string managerServiceNumber) 
        {
            FinancialYear = financialYear;
            ServiceNumber = serviceNumber;
            ManagerServiceNumber = managerServiceNumber;
            DateCreated = DateTime.Now;
            Status = AgreementStatus.Created;
        }

        private Agreement()
        {
            
        }

        public void SendForApproval()
        {
            if (Status != AgreementStatus.Approved) throw new InvalidActionException("Invalid status.");
            Status = AgreementStatus.SentForApproval;
        }

        //shortcut
        //public void SendForApproval() => Status = AgreementStatus.SendForApproval;

        public void Approve()
        {
            if(Status != AgreementStatus.SentForApproval) throw new InvalidActionException("Invalid status.");
            Status = AgreementStatus.Approved;
        }

        public void Reject()
        {
            if (Status != AgreementStatus.SentForApproval) throw new InvalidActionException("Invalid status.");
            Status = AgreementStatus.Rejected;
        }

        public void AddKeyPerfomanceArea(string description, int weighting)
        {
            if (KeyPerformanceAreas.Count > 5) throw new BusinessRuleException("An agreement should not have more than 5 key perfomance areas.");
            var kpa = new KeyPerformanceArea(Id, description, weighting);
            KeyPerformanceAreas.Add(kpa);

        }
    }
}
