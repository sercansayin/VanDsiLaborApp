using AutoMapper;
using VanDsi.Core.DTOs;
using VanDsi.Core.Models;

namespace VanDsi.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Labor, LaborDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
