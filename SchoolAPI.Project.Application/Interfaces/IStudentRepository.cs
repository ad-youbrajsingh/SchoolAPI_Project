using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Interfaces;

public interface IStudentRepository
{
    Task AddStudentAsync(Student student, CancellationToken cancellationToken);
    Task<Student?> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);
    Task UpdateStudentAsync(Student student, CancellationToken cancellationToken);
    Task<bool> DeleteStudentAsync(Student student, CancellationToken cancellationToken);
}
