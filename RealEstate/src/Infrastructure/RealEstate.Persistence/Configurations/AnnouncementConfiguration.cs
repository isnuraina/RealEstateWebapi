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
    internal class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            builder.Property(m => m.Type).HasColumnType("int").IsRequired();
            builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(m => m.CityId).HasColumnType("int").IsRequired();
            builder.Property(m => m.Address).HasColumnType("nvarchar").HasMaxLength(1000).IsRequired();
            builder.Property(m => m.Description).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Phone).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal").HasPrecision(18,2).IsRequired();
            builder.Property(m => m.PriceUnit).HasColumnType("int").IsRequired();
            builder.Property(m => m.FromAgent).HasColumnType("int").IsRequired();


            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Announcements");

            builder.HasOne<City>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.CityId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne<Category>()
                .WithMany()
                .HasPrincipalKey(m => m.Id)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
