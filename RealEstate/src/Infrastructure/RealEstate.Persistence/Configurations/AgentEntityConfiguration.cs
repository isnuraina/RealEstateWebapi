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
    internal class AgentEntityConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Surname).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Phone).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.ImagePath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.Rate).HasColumnType("decimal").HasPrecision(3,2).IsRequired();
            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Agents");
        }
    }
}
