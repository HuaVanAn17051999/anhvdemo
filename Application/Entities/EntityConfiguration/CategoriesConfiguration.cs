using Application.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Text;

namespace Application.Entities.EntityConfiguration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.DateCreate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            

            builder.HasOne(x => x.Parents)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.ParentId);




           


        }
    }
}
