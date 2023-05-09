using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllController : Controller
    {
        private readonly IRepository<Employee> _employee;
        private readonly IRepository<TimeReport> _timereport;

        [HttpGet("{id}/timereport")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var timereport = await _employee.Get(id);
            if (timereport == null)
            {
                return NotFound();
            }
            return Ok(timereport);
        }
    }
}
