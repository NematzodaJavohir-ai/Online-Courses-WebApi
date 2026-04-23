using Domain.Entities;
using Application.Results;
using Application.DTOs.CourseDTOs;

namespace Application.Interfaces.Repositories;

public interface ICourseRepository
{
    Task<PagedResult<Course>> GetCoursesAsync(CourseFilterDto filter, CancellationToken ct = default);
    Task<Course?> GetCourseByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Course>> GetCoursesByUserIdAsync(int userId, CancellationToken ct = default);
    Task<IEnumerable<Course>> GetCoursesByCategoryIdAsync(int categoryId, CancellationToken ct = default);
    Task<int> AddCourseAsync(Course course, CancellationToken ct = default);
    Task<bool> UpdateCourse(Course course);
    Task<bool> DeleteCourse(Course course);
    Task<bool> CourseExistsAsync(int id, CancellationToken ct = default);
}