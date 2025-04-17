using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SaleNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.CustomerId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.CustomerName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.BranchId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.BranchName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.SaleDate)
                .IsRequired();

            builder.Property(s => s.IsCanceled)
                .IsRequired();

            // Relations:: 1 Sale -> N SaleItems
            builder.HasMany(s => s.Items)
                .WithOne() // No reverse navigation property
                .HasForeignKey("SaleId")
                .OnDelete(DeleteBehavior.Cascade); // When the sale is deleted, the items are also deleted.
        }
    }
}
