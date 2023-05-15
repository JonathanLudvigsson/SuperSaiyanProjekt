using AutoMapper;
using Models;
using SuperSaiyanProjekt.Dtos;

namespace SuperSaiyanProjekt.Profiles
{
    public class EmployeesProfiles : Profile
    {
        public EmployeesProfiles()
        {
            CreateMap<Task<Employee>, Task<EmployeeDto>>();
            CreateMap<List<Employee>, IEnumerable<EmployeeDto>>();
        }
    }
}
