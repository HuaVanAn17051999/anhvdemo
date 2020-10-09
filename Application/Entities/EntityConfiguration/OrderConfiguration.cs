using Application.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Entities.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ShipName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.ShipAddress).HasMaxLength(500).IsRequired();
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(OrderStatus.InProgress);

            builder.HasOne(x => x.User)
                .WithMany(ur => ur.Orders)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
