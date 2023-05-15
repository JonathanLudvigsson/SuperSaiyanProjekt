using AutoMapper;
using Models;
using SuperSaiyanProjekt.Dtos;

namespace SuperSaiyanProjekt.Profiles
{
    public class TimereportProfiles : Profile
    {
        public TimereportProfiles()
        {
            CreateMap<TimeReport, TimeReportDto>().ReverseMap();
        }
    }
}
