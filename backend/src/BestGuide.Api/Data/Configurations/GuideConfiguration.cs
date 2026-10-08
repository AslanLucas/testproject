using BestGuide.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestGuide.Api.Data.Configurations;

public class GuideConfiguration : IEntityTypeConfiguration<Guide>
{
    public void Configure(EntityTypeBuilder<Guide> builder)
    {
        builder.Property(g => g.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.HasOne(g => g.Tenant)
               .WithMany(t => t.Guides)
               .HasForeignKey(g => g.TenantId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}