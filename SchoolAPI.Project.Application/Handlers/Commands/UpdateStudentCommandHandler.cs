using MediatR;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Unit> Handle(UpdateStudentCommand updateStudentCommand, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetStudentByIdAsync(updateStudentCommand.StudentRequestDTO.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException("No Such Student Exist!");
        }
        student.FirstName = updateStudentCommand.StudentRequestDTO.FirstName;
        student.LastName = updateStudentCommand.StudentRequestDTO.LastName;
        student.DateOfBirth = updateStudentCommand.StudentRequestDTO.DateOfBirth;
        student.Email = updateStudentCommand.StudentRequestDTO.Email;

        await _studentRepository.UpdateStudentAsync(student, cancellationToken);
        return Unit.Value;
    }
}