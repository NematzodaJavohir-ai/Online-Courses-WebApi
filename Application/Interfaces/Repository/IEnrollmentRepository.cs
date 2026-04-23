using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IEnrollmentRepository
{
    Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync(CancellationToken ct = default);
    Task<Enrollment?> GetEnrollmentByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId, CancellationToken ct = default);
    Task<Enrollment?> GetByStudentAndCourseAsync(Guid studentId, int courseId, CancellationToken ct = default);
    Task<int> AddEnrollmentAsync(Enrollment enrollment, CancellationToken ct = default);
    Task<bool> UpdateEnrollment(Enrollment enrollment);
    Task<bool> DeleteEnrollment(Enrollment enrollment);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}