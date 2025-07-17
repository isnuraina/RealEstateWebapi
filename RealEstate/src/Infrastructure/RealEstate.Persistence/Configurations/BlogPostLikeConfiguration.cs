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
    internal class BlogPostLikeConfiguration : IEntityTypeConfiguration<BlogPostLike>
    {
        public void Configure(EntityTypeBuilder<BlogPostLike> builder)
        {
            builder.Property(m => m.BlogPostId).HasColumnType("int");
            builder.ConfigureAuditable();
            builder.HasKey(m => new { m.BlogPostId, m.CreatedBy });
            builder.ToTable("BlogPostLikes");

            builder.HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey(m => m.BlogPostId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
