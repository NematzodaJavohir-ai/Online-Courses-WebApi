using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Rating).IsRequired();
        builder.Property(r => r.Comment).IsRequired().HasMaxLength(1000);
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne<Course>()
               .WithMany(c => c.Reviews)
               .HasForeignKey(r => r.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Student>()
               .WithMany()
               .HasForeignKey(r => r.StudentId)
               .OnDelete(DeleteBehavior.NoAction); 
    }
}