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
    internal class AnnouncementCommentConfiguration : IEntityTypeConfiguration<AnnouncementComment>
    {
        public void Configure(EntityTypeBuilder<AnnouncementComment> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.AnnouncementId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ParentId).HasColumnType("int");
            builder.Property(m => m.Text).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();




            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("AnnouncementComments");


            builder.HasOne<Announcement>()
               .WithMany()
               .HasPrincipalKey(m => m.Id)
               .HasForeignKey(m => m.AnnouncementId)
               .OnDelete(DeleteBehavior.NoAction);



            builder.HasOne<AnnouncementComment>()
             .WithMany()
             .HasPrincipalKey(m => m.Id)
             .HasForeignKey(m => m.ParentId)
             .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
