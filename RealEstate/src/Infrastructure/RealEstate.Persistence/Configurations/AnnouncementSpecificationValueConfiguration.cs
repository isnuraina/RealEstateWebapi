using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configurations
{
    internal class AnnouncementSpecificationValueConfiguration : IEntityTypeConfiguration<AnnouncementSpecificationValue>
    {
        public void Configure(EntityTypeBuilder<AnnouncementSpecificationValue> builder)
        {
            builder.Property(m => m.SpecificationId).HasColumnType("int");
            builder.Property(m => m.AnnouncementId).HasColumnType("int");
            builder.Property(m => m.Value).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();


            builder.ConfigureAuditable();

            builder.HasKey(m => new {m.SpecificationId,m.AnnouncementId});
            builder.ToTable("AnnouncementSpecificationValues");
        }
    }
}
