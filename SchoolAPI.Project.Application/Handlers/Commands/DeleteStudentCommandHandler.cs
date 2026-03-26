using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILogger<DeleteStudentCommandHandler> _logger;
    public DeleteStudentCommandHandler(IStudentRepository studentRepository, ILogger<DeleteStudentCommandHandler> logger)
    {
        _studentRepository = studentRepository;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteStudentCommand deleteStudentCommand, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting student with Id: {Id}", deleteStudentCommand.Id);
        Student? student = await _studentRepository.GetStudentByIdAsync(deleteStudentCommand.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException("No such Student Exist!");
        }
        bool result = await _studentRepository.DeleteStudentAsync(student, cancellationToken);
        _logger.LogInformation("Student deleted successfully: {Id}", deleteStudentCommand.Id);
        return result;
    }
}