using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<CreateStudentCommandHandler> _logger;
    public CreateStudentCommandHandler(IStudentRepository studentRepository, ILogger<CreateStudentCommandHandler> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating student with email: {Email}", request.Email);

        var student = new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth.ToDateTime(TimeOnly.MinValue)
        };

        await _studentRepository.AddStudentAsync(student, cancellationToken);
        _logger.LogInformation("Student created successfully with Id: {StudentId}", student.Id);
        return student.Id;
    }
}