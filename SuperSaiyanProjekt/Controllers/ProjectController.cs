using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private IProject _api;
        public ProjectController(IProject api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            return Ok(await _api.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleProject(int id)
        {
            return Ok(await _api.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project projectToAdd)
        {
            if (projectToAdd != null)
            {
                return Ok(await _api.Add(projectToAdd));
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
        public async Task<IActionResult> UpdateProject(int id, Project updatedProject)
        {
            if (updatedProject != null)
            {
                return Ok(await _api.Update(id, updatedProject));
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
