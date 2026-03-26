using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SchoolAPI.Project.Application.Dtos.student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Application.Queries.Student;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Queries;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponseDTO>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetStudentByIdQueryHandler> _logger;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<GetStudentByIdQueryHandler> logger)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<StudentResponseDTO> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching student with {id}",query.Id);
        Student? student = await _studentRepository.GetStudentByIdAsync(query.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException($"No Student with id:{query.Id} exists!");
        }

        var mappedStudent = _mapper.Map<StudentResponseDTO>(student);
        _logger.LogInformation("Fetched student with {id}",query.Id);
        return mappedStudent;
    }

}