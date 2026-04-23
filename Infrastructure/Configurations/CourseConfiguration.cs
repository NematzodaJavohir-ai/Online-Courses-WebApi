using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Description).IsRequired().HasMaxLength(2000);
        builder.Property(c => c.Price).HasPrecision(18, 2);
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(c => c.Category)
               .WithMany(cat => cat.Courses)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasOne(c => c.User)
               .WithMany() 
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}