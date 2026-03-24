using MediatR;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Commands.Student;

class CreateStudentCommand(CreateStudentRequestDTO createStudent) : IRequest<Guid>
{
    public CreateStudentRequestDTO CreateStudentDto { get; set; } = createStudent;
}