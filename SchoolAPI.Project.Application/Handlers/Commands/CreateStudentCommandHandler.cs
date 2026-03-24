using MediatR;
using SchoolAPI.Project.Application.Commands.Student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Commands;

class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _studentRepository;
    public CreateStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = new Student
        {
            FirstName = request.CreateStudentDto.FirstName,
            LastName = request.CreateStudentDto.LastName,
            Email = request.CreateStudentDto.Email,
            DateOfBirth = request.CreateStudentDto.DateOfBirth
        };

        await _studentRepository.AddStudentAsync(student);
        return student.Id;
    }
}