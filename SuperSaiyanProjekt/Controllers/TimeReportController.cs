using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Dtos;
using SuperSaiyanProjekt.Services;

namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private ITimeReport _api;
        private IMapper _mapper;

        public TimeReportController(ITimeReport api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTimeReports()
        {
            var timeReports = await _api.GetAll();
            return Ok(_mapper.Map<IEnumerable<TimeReportDto>>(timeReports));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTimeReport(int id)
        {
            TimeReport timeRep = await _api.Get(id);
            return Ok(_mapper.Map<TimeReportDto>(timeRep));
        }

        [HttpPost]
        public async Task<IActionResult> AddTimeReport(TimeReportDto timeReportToAdd)
        {
            TimeReport timeRep = _mapper.Map<TimeReport>(timeReportToAdd);
            if (timeReportToAdd != null)
            {
                return Ok(await _api.Add(timeRep));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTimeReport(int id, TimeReportDto updatedTimeReport)
        {
            TimeReport timeRep = _mapper.Map<TimeReport>(updatedTimeReport);
            if (updatedTimeReport != null)
            {
                return Ok(await _api.Update(id, timeRep));
            }
            return StatusCode(StatusCodes.Status406NotAcceptable);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTimeReport(int id)
        {
            return Ok(await _api.Remove(id));
        }
        [HttpGet("{employeeid:int}/{week:int}")]
        public async Task<IActionResult> GetHoursInWeek(int employeeid, int week)
        {

            return Ok(await _api.GetHoursInWeek(employeeid, week));
        }
    }
}
