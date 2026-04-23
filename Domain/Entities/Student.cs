// Domain/Entities/Student.cs
namespace Domain.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? AvatarUrl { get; set; }
        public virtual  User User { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
