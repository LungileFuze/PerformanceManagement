namespace IMU.Perfomance.Api.Domain.Entities
{
    public class KeyPerformanceIndicator : BaseEntity
    {
        public string Description { get; private set; } = null!;
        public int Weighting { get; set; }

        public int? MidtermScore { get; private set; }

        public int? MidTermWeightedScore { get; private set; }

        public int? FinalScore { get; private set; }

        public int? FinalWeightedScore { get; private set; }

        //foreign key
        public long KeyPerformanceAreaId { get; private set; }
        public KeyPerformanceArea KeyPerfomanceArea { get; private set; } = null!;
        private KeyPerformanceIndicator() 
        { 

        }
    }
}
