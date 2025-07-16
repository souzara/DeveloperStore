using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;
public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");
        builder.Property(s => s.SaleNumber).HasMaxLength(15).IsRequired();
        builder.Property(s => s.Date)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        builder.Property(s => s.CustomerId).IsRequired();
        builder.Property(s => s.CustomerName)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(s => s.BranchId).IsRequired();
        builder.Property(s => s.BranchName)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(s => s.TotalAmount).IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(s => s.IsCancelled).IsRequired().HasDefaultValue(false);
        builder.Property(s => s.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(s => s.UpdatedAt);
    }
}
