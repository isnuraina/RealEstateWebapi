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
    internal class BlogPostCommentConfiguration : IEntityTypeConfiguration<BlogPostComment>
    {
        public void Configure(EntityTypeBuilder<BlogPostComment> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Text).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.BlogPostId).HasColumnType("int").IsRequired();
            builder.Property(m => m.ParentId).HasColumnType("int");
            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("BlogPostComments");

        
            builder.HasOne<BlogPost>()
              .WithMany()
              .HasPrincipalKey(m => m.Id)
              .HasForeignKey(m => m.BlogPostId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<BlogPostComment>()
               .WithMany()
               .HasPrincipalKey(m => m.Id)
               .HasForeignKey(m => m.ParentId)
               .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
