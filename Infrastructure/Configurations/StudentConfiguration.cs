using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.FullName).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Bio).HasMaxLength(1000);
        builder.Property(s => s.AvatarUrl).HasMaxLength(500);

    
        builder.HasOne(s => s.User)
               .WithOne() 
               .HasPrincipalKey<User>(u => u.Id) 
               .OnDelete(DeleteBehavior.Cascade);
    }
}