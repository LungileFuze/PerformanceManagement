using IMU.Perfomance.Api.Domain.Exceptions;

namespace IMU.Perfomance.Api.Domain.Entities
{
    public class KeyPerformanceArea : BaseEntity
    {
        //private for muting properties, properties to be accessable only within this class
        //null! mean the property doesnt take null values
        public string Description { get; private set; } = null!;

        public int Weighting { get; set; }
        public string? ManagerComment { get; set; }
        public string?  ModeratorComment { get; set; }

        //foreign key or navigation key
        public long AgreementId { get; private set; }
        public List<KeyPerformanceIndicator> KeyPerformanceIndicators { get; private set; } = new();
        //Reference table for the above primary key
        public Agreement Agreement { get; private set; } = null!;

        //constructors. this creates a keyperfomancearea
        public KeyPerformanceArea(long agreementId, string description, int weighting)
        {
            if (weighting > 90 || weighting < 0) throw new DataValidationException("The weight should be between 1 and 90 inclusive.");
            AgreementId = agreementId;
            Description = description;
            Weighting = weighting;
            DateCreated = DateTime.Now;
        }
        //Empty contructor to create a complete model. This incase the user sent without filling the KPA
        private KeyPerformanceArea()
        {
            
        }
    }
}