using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace IMU.Perfomance.Api.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; private set; }

        public DateTime DateCreated { get; protected set; }
    }
}
