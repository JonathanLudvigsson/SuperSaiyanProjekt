using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class ProjectController : Controller
    {
        private IRepository<Project> _api;
        public ProjectController(IRepository<Project> api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            return Ok(await _api.GetAll());
        }

        [HttpGet]
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

    }
}
