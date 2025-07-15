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
    public class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(500).IsRequired();
            builder.Property(m => m.Slug).HasColumnType("varchar").HasMaxLength(500).IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Body).HasColumnType("varchar(max)").IsRequired();
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");
            builder.Property(m => m.PublishedBy).HasColumnType("int");


            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("BlogPosts");
        }
    }
}
