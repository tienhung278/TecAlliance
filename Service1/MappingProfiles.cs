using AutoMapper;
using Service1.Entities;
using Service1.Models.Dtos;

namespace Service1;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, EmployeeReadDto>();
        CreateMap<EmployeeWriteDto, Employee>();
    }
}