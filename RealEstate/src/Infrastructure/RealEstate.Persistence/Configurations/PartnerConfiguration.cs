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
    internal class PartnerConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.Name).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
            builder.Property(m => m.LogoPath).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.HasKey(m => m.Id);
            builder.ConfigureAuditable();
            builder.ToTable("Partners");
        }
    }
}
