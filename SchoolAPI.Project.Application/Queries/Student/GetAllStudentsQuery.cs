using MediatR;
using SchoolAPI.Project.Application.Dtos.Common;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Queries.Student;

class GetAllStudentsQuery : IRequest<PaginatedResponse<Domain.Entities.Student>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}