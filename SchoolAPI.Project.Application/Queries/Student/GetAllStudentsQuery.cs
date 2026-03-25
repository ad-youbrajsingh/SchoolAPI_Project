using MediatR;
using SchoolAPI.Project.Application.Dtos.Common;
using SchoolAPI.Project.Application.Dtos.student;

namespace SchoolAPI.Project.Application.Queries.Student;

public class GetAllStudentsQuery : IRequest<PaginatedResponse<StudentResponseDTO>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}