using AutoMapper;
using Models;
using SuperSaiyanProjekt.Dtos;

namespace SuperSaiyanProjekt.Profiles
{
    public class EmployeesProfiles : Profile
    {
        public EmployeesProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
