using MediatR;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Queries.Student;

public class GetStudentByIdQuery : IRequest<StudentResponseDTO>
{
    public Guid Id { get; set; }
}