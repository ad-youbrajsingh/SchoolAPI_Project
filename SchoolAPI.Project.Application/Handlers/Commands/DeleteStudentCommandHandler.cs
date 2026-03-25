using MediatR;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly IStudentRepository _studentRepository;
    public DeleteStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<bool> Handle(DeleteStudentCommand deleteStudentCommand, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetStudentByIdAsync(deleteStudentCommand.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException("No such Student Exist!");
        }
        bool result = await _studentRepository.DeleteStudentAsync(student, cancellationToken);
        return result;
    }
}