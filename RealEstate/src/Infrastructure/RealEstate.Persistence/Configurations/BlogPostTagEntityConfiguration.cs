using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Extensions;

namespace RealEstate.Persistence.Configurations
{
    internal class BlogPostTagEntityConfiguration : IEntityTypeConfiguration<BlogPostTag>
    {
        public void Configure(EntityTypeBuilder<BlogPostTag> builder)
        {
            builder.Property(m => m.BlogPostId).HasColumnType("int");
            builder.Property(m => m.TagId).HasColumnType("int");
            builder.ConfigureAuditable();
            builder.HasKey(m => new { m.BlogPostId, m.TagId });
            builder.ToTable("BlogPostTags");


            builder.HasOne<BlogPost>()
                .WithMany()
                .HasForeignKey(m => m.BlogPostId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);



            builder.HasOne<Tag>()
                .WithMany()
                .HasForeignKey(m => m.TagId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
