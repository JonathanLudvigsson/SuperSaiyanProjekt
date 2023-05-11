using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository<Employee> _api;
        public EmployeeController(IRepository<Employee> api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _api.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            return Ok(await _api.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee empToAdd)
        {
            if (empToAdd != null)
            {
                return Ok(await _api.Add(empToAdd));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, Employee updatedEmp)
        {
            if (updatedEmp != null)
            {
                return Ok(await _api.Update(id, updatedEmp));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            return Ok(await _api.Remove(id));
        }

    }
}
