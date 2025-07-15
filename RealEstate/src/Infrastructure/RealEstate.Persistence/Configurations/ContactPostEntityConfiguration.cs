using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configurations
{
    internal class ContactPostEntityConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Fullname).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(70).IsRequired();
            builder.Property(m => m.Message).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Answer).HasColumnType("nvarchar(max)");
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            builder.Property(m => m.AnsweredBy).HasColumnType("int");
            builder.ConfigureAuditable();


            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }
}
