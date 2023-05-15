using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Dtos;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private IProject _api;
        private IMapper _mapper;

        public ProjectController(IProject api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            var projects = await _api.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProjectDto>>(projects));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleProject(int id)
        {
            Project proj = await _api.Get(id);

            return Ok(_mapper.Map<ProjectDto>(proj));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectDto projectToAdd)
        {
            Project proj = _mapper.Map<Project>(projectToAdd);

            if (projectToAdd != null)
            {
                return Ok(await _api.Add(proj));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetEmployeesForProject(int id)
        {
            var employees = await _api.GetEmployeesForProject(id);
            return Ok(employees);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProject(int id, ProjectDto updatedProject)
        {
            Project proj = _mapper.Map<Project>(updatedProject);
            if (updatedProject != null)
            {
                return Ok(await _api.Update(id, proj));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            return Ok(await _api.Remove(id));
        }

        [HttpPut("{projectid:int}, {employeeid:int}")]
        public async Task<IActionResult> AddEmployeeToProject(int projectid, int employeeid)
        {
            return Ok(await _api.AddEmployeeToProject(projectid, employeeid));
        }

    }
}
