using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configurations
{
    internal class AnnouncementMediaConfiguration : IEntityTypeConfiguration<AnnouncementMedia>
    {
        public void Configure(EntityTypeBuilder<AnnouncementMedia> builder)
        {

            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.AnnouncementId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Path).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.IsMain).HasColumnType("bit").IsRequired();
            builder.Property(m => m.Type).HasColumnType("int").IsRequired();
        
            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("AnnouncementMedias");

            builder.HasOne<Announcement>()
               .WithMany()
               .HasPrincipalKey(m => m.Id)
               .HasForeignKey(m => m.AnnouncementId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
