using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title).IsRequired().HasMaxLength(250);
        builder.Property(l => l.Description).HasMaxLength(1500);
        builder.Property(l => l.VideoUrl).HasMaxLength(500);
        builder.Property(l => l.MaterialPath).HasMaxLength(500);
        
        builder.Property(l => l.Order).IsRequired(); 

        builder.HasOne(l => l.Course)
               .WithMany(c => c.Lessons)
               .HasForeignKey(l => l.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
