using AutoMapper;
using RestApiPlayground.Application.Commands;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Domain.Contracts;

namespace RestApiPlayground.Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
