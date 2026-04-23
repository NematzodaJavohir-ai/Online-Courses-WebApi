using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ILessonRepository
{
    Task<IEnumerable<Lesson>> GetAllLessonsAsync(CancellationToken ct = default);
    Task<Lesson?> GetLessonByIdAsync(int id, CancellationToken ct = default);
    Task<IEnumerable<Lesson>> GetLessonsByCourseIdAsync(int courseId, CancellationToken ct = default);
    Task<int> AddLessonAsync(Lesson lesson, CancellationToken ct = default);
    Task<bool> UpdateLesson(Lesson lesson);
    Task<bool> DeleteLesson(Lesson lesson);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}