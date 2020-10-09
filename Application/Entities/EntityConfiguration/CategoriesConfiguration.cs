using Application.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Application.Entities.EntityConfiguration
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.DateCreate).HasDefaultValueSql("GetUtcDate()");
           
        }
    }
}
