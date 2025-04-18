using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
    {
        public void Configure(EntityTypeBuilder<SaleItem> builder)
        {
            builder.ToTable("SaleItems");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.ProductName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Discount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Relations with Sale (via shadow property "SaleId")
            builder.Property<Guid>("SaleId"); // Shadow property to FK (if not in class)
        }
    }
}
