using System;
using Domain.Enums;

namespace Domain.Entities;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }=null!;
    public string Description { get; set; }=null!;
    public string? ThumbnailPath { get; set; }  
    public decimal Price { get; set; }
    public CourseLevel Level { get; set; }
    public bool IsPublished { get; set; }
    public DateTime CreatedAt { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }=null!;

    public int UserId { get; set; }
    public User User { get; set; }=null!;

    
    public ICollection<Lesson> Lessons { get; set; }=null!;
    public ICollection<Enrollment> Enrollments { get; set; }=null!;
    public ICollection<Review> Reviews { get; set; }=null!;
}
