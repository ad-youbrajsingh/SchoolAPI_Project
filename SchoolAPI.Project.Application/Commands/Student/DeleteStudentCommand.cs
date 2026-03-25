using MediatR;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Commands.Student;

public class DeleteStudentCommand() : IRequest<bool>
{
    public Guid Id { get; set; }
}