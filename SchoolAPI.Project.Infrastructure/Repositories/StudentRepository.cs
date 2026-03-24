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

    public async Task AddStudentAsync(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        Student? student = await _dbContext.Students.FindAsync(id);
        return student;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        List<Student> students = await _dbContext.Students.ToListAsync();
        return students;
    }

    public async Task UpdateStudentAsync(Student student)
    {
        Student? existingStudent = await _dbContext.Students.FindAsync(student.Id);
        if (existingStudent == null)
        {
            throw new KeyNotFoundException("No Such Student Found!");
        }

        existingStudent.FirstName = student.FirstName;
        existingStudent.LastName = student.LastName;
        existingStudent.DateOfBirth = student.DateOfBirth;
        existingStudent.Email = student.Email;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Student student)
    {
        Student? existingStudent = await _dbContext.Students.FindAsync(student.Id);
        if (existingStudent == null)
        {
            throw new KeyNotFoundException("No Such Student Found!");
        }

        _dbContext.Students.Remove(existingStudent);
        await _dbContext.SaveChangesAsync();
    }


}
