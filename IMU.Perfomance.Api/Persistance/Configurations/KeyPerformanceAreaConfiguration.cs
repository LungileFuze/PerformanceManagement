using IMU.Perfomance.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMU.Perfomance.Api.Persistance.Configurations
{
    public class KeyPerformanceAreaConfiguration : IEntityTypeConfiguration<KeyPerformanceArea>
    {
        public void Configure(EntityTypeBuilder<KeyPerformanceArea>builder)
        {
            builder.ToTable("KeyPerfomanceArea");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("bigint").IsRequired().UseIdentityColumn(1, 1);
            builder.Property(p => p.AgreementId).HasColumnType("bigint").IsRequired();
            builder.HasOne(p => p.Agreement).WithMany(a => a.KeyPerformanceAreas).HasForeignKey(a => a.AgreementId);
            builder.Property(p => p.Description).HasColumnType("nvarchar(2000)").IsRequired();
            builder.Property(p => p.ManagerComment).HasColumnType("nvarchar(2000)");
            builder.Property(p => p.ModeratorComment).HasColumnType("nvarchar(2000)");
            builder.Property(p => p.Weighting).HasColumnType("int").IsRequired();
            builder.Property(p => p.DateCreated).HasColumnType("datetime").IsRequired();
        }
    }
}
