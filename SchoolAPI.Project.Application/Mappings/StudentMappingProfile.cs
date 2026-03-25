using AutoMapper;
using SchoolAPI.Project.Application.Dtos.student;
using SchoolAPI.Project.Domain.Entities;

namespace SchoolAPI.Project.Application.Mappings;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<Student, StudentResponseDTO>();
    }
}