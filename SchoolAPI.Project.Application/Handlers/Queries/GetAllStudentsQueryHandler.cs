using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAPI.Project.Application.Dtos.Common;
using SchoolAPI.Project.Application.Dtos.student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Application.Queries.Student;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Queries;

public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, PaginatedResponse<StudentResponseDTO>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllStudentsQueryHandler> _logger;

    public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<GetAllStudentsQueryHandler> logger)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<PaginatedResponse<StudentResponseDTO>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all students");

        List<Student> students = await _studentRepository.GetAllStudentsAsync(cancellationToken);
        int totalCount = students.Count;

        var pagedStudents = students.Skip((query.PageNumber - 1) * query.PageSize)
                                    .Take(query.PageSize)
                                    .ToList();

        var mappedStudents = _mapper.Map<List<StudentResponseDTO>>(pagedStudents);

        _logger.LogInformation("Fetched {Count} students", students.Count);

        return new PaginatedResponse<StudentResponseDTO>(
            mappedStudents,
            query.PageNumber,
            query.PageSize,
            totalCount
        );
    }
}