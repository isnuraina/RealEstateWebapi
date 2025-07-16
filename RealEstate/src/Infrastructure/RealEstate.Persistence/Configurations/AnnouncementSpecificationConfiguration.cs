using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configurations
{
    internal class AnnouncementSpecificationConfiguration : IEntityTypeConfiguration<AnnouncementSpecification>
    {
        public void Configure(EntityTypeBuilder<AnnouncementSpecification> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.IsActive).HasColumnType("bit").IsRequired();
           
            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("AnnouncementSpecifications");
        }
    }
}
