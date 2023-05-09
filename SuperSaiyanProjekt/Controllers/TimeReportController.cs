using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private IRepository<TimeReport> _api;
        public TimeReportController(IRepository<TimeReport> api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReports()
        {
            return Ok(await _api.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTimeReport(int id)
        {
            return Ok(await _api.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeReport(TimeReport empToAdd)
        {
            if (empToAdd != null)
            {
                return Ok(await _api.Add(empToAdd));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTimeReport(int id, TimeReport updatedEmp)
        {
            if (updatedEmp != null)
            {
                return Ok(await _api.Update(id, updatedEmp));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTimeReport(int id)
        {
            return Ok(await _api.Remove(id));
        }
    }
}
