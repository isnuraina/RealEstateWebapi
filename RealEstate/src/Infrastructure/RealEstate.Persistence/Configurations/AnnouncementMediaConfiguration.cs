using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
