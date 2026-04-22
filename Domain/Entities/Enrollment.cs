using System;
using Domain.Enums;

namespace Domain.Entities;

public class Enrollment
{
   public Guid Id { get; set; }
    public DateTime EnrolledAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public EnrollmentStatus Status { get; set; }
    public int ProgressPercent { get; set; }     

    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public string StudentId { get; set; }
    
}
