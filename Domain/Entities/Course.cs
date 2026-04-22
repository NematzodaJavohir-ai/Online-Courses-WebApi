using System;
using Domain.Enums;

namespace Domain.Entities;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? ThumbnailPath { get; set; }    // путь к загруженному файлу (FormFile)
    public decimal Price { get; set; }
    public CourseLevel Level { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Lesson> Lessons { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Review> Reviews { get; set; }
}
