using MediatR;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Commands.Student;

public class DeleteStudentCommand(DeleteStudentRequestDTO dto) : IRequest<bool>
{
    public DeleteStudentRequestDTO DeleteStudentDto { get; set; } = dto;
}