using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviewsByCourseIdAsync(int courseId, CancellationToken ct = default);
    Task<Review?> GetReviewByIdAsync(int id, CancellationToken ct = default);
    Task<bool> HasStudentReviewedCourseAsync(Guid studentId, int courseId, CancellationToken ct = default);
    Task<int> AddReviewAsync(Review review, CancellationToken ct = default);
    Task<bool> UpdateReview(Review review);
    Task<bool> DeleteReview(Review review);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}