using AutoMapper;
using SuperSaiyanProjekt.Dtos;
using Models;

namespace SuperSaiyanProjekt.Profiles
{
    public class ProjectsProfiles : Profile
    {
        public ProjectsProfiles()
        {
            CreateMap<Project, ProjectDto>();
        }
    }
}
