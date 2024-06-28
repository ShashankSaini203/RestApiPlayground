using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Application.Services;
using RestApiPlayground.Application.Commands;
using MediatR;
using RestApiPlayground.Application.Responses;

namespace RestApiPlayground.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, IMediator mediator) : base(mediator)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if(id < 0)
            {
                return BadRequest("ID is invalid. It cannot be negative.");
            }
            var employeeData= await _employeeService.GetByIdAsync(id);

            if(employeeData == null)
            {
                return NotFound("Could not find employee with provided ID");
            }
            return Ok(await _employeeService.GetByIdAsync(id));
        }

        [HttpGet("getAllEmployees")]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeService.GetAllAsync();
        }

        [HttpPost("createEmployee")]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand employee)
        {
            if (employee is null || !ModelState.IsValid)
            {
                return BadRequest("Invalid employee details.");
            }

            var result = await _mediator.Send(employee);
            return Ok(result);
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if(employee is null || !ModelState.IsValid)
            {
                return BadRequest("Invalid employee details.");
            }

            await _employeeService.UpdateAsync(employee);
            return Ok($"Employee with id {employee.Id} was updated successfully");
        }
    }
}