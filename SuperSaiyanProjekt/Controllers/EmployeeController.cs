﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using SuperSaiyanProjekt.Dtos;
using SuperSaiyanProjekt.Services;
using Microsoft.EntityFrameworkCore;


namespace SuperSaiyanProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository<Employee> _api;
        private IMapper _mapper;

        public EmployeeController(IRepository<Employee> api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Employees = await _api.GetAll();

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(Employees));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var Employee = await _api.Get(id);
            if (Employee != null)
            {
                return Ok(_mapper.Map<EmployeeDto>(Employee));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDto empToAdd)
        {
            var EmployeeModel = _mapper.Map<Employee>(empToAdd);

            return Ok(await _api.Add(EmployeeModel));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, EmployeeDto updatedEmp)
        {
            var EmployeeModel = _mapper.Map<Employee>(updatedEmp);
            await _api.Update(id, EmployeeModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok(await _api.Remove(id));
        }

    }
}
