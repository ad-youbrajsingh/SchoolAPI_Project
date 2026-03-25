using MediatR;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Commands.Student;

public class CreateStudentCommand : CreateStudentRequestDTO, IRequest<Guid>
{
}