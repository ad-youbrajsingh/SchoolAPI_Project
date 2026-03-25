using AutoMapper;
using MediatR;
using SchoolAPI.Project.Application.Dtos.student;
using SchoolAPI.Project.Application.Interfaces;
using SchoolAPI.Project.Application.Queries.Student;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Handlers.Queries;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponseDTO>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentResponseDTO> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetStudentByIdAsync(query.Id, cancellationToken);

        if (student == null)
        {
            throw new KeyNotFoundException($"No Student with id:{query.Id} exists!");
        }

        var mappedStudent = _mapper.Map<StudentResponseDTO>(student);

        return mappedStudent;
    }

}