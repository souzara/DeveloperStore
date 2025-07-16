using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");
        builder.HasKey(si => si.Id);
        builder.Property(si => si.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        builder.Property(si => si.ProductId).IsRequired().HasColumnType("uuid");
        builder.Property(si => si.ProductName).IsRequired().HasMaxLength(200);
        builder.Property(si => si.Discount).HasColumnType("decimal(18,2)").HasDefaultValue(0);
        builder.Property(si => si.IsCancelled).IsRequired().HasDefaultValue(false);
        builder.Property(s => s.Total).IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(si => si.Quantity).IsRequired();
        builder.Property(si => si.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.CreatedAt).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(si => si.Sale)
            .WithMany(s => s.Items)
            .HasForeignKey(si => si.SaleId);

    }
}
