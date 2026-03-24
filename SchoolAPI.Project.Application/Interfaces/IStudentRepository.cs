using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Interfaces;

public interface IStudentRepository
{
    Task AddStudentAsync(Student student);
    Task<Student?> GetStudentByIdAsync(int id);
    Task<List<Student>> GetAllStudentsAsync();
    Task UpdateStudentAsync(Student student);
    Task DeleteStudentAsync(Student student);
}
