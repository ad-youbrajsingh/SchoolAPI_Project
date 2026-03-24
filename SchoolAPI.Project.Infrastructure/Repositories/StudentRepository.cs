using Microsoft.EntityFrameworkCore;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;
using SchoolAPI.Project.Infrastructure.Persistence;
namespace SchoolAPI.Project.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolDBContext _dbContext;
    public StudentRepository(SchoolDBContext context)
    {
        _dbContext = context;
    }

    public async Task AddStudentAsync(Student student, CancellationToken cancellationToken)
    {
        await _dbContext.Students.AddAsync(student, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student?> GetStudentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Student? student = await _dbContext.Students.FindAsync([id], cancellationToken);
        return student;
    }

    public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
    {
        List<Student> students = await _dbContext.Students.ToListAsync(cancellationToken);
        return students;
    }

    public async Task UpdateStudentAsync(Student student, CancellationToken cancellationToken)
    {
        _dbContext.Students.Update(student);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteStudentAsync(Student student, CancellationToken cancellationToken)
    {
        Student? existingStudent = await _dbContext.Students.FindAsync([student.Id], cancellationToken);
        if (existingStudent == null)
        {
            throw new KeyNotFoundException("No Such Student Found!");
        }
        _dbContext.Students.Remove(existingStudent);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;

    }


}
