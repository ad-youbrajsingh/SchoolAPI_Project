using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<UpdateStudentCommandHandler> _logger;

    public UpdateStudentCommandHandler(IStudentRepository studentRepository, ILogger<UpdateStudentCommandHandler> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateStudentCommand updateStudentCommand, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating student with Id: {Id}", updateStudentCommand.Id);

        Student? student = await _studentRepository.GetStudentByIdAsync(updateStudentCommand.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException("No Such Student Exist!");
        }
        student.FirstName = updateStudentCommand.FirstName;
        student.LastName = updateStudentCommand.LastName;
        student.DateOfBirth = updateStudentCommand.DateOfBirth.ToDateTime(TimeOnly.MinValue);
        student.Email = updateStudentCommand.Email;
        student.UpdatedAt = DateTime.UtcNow;

        await _studentRepository.UpdateStudentAsync(student, cancellationToken);
        _logger.LogInformation("Student updated successfully: {Id}", updateStudentCommand.Id);
        return Unit.Value;
    }
}