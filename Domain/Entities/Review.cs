using System;

namespace Domain.Entities;

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }              
    public string Comment { get; set; }=null!;
    public DateTime CreatedAt { get; set; }

    public int CourseId { get; set; }
    public int StudentId { get; set; }
}
