using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EnrolledAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        builder.Property(e => e.ProgressPercent).HasDefaultValue(0);
        builder.Property(e => e.Status).IsRequired();

        builder.HasOne(e => e.Course)
               .WithMany(c => c.Enrollments)
               .HasForeignKey(e => e.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

        
        builder.HasOne(e => e.Student)
               .WithMany()
               .HasForeignKey(e => e.StudentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}