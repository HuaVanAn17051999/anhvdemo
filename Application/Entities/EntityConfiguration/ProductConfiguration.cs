using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Application.Entities.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.DateCreated).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Caption).IsRequired();
            builder.Property(x => x.ViewCount).HasDefaultValue(0);

            builder.HasOne(x => x.Categories)
                .WithMany(ur => ur.Products)
                .HasForeignKey(ur => ur.CategoryId)
                .IsRequired();

            builder.HasMany(x => x.ImageProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .IsRequired();
        }
    }
}
