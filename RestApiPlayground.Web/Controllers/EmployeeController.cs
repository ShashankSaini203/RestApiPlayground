using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Application.Services;
using RestApiPlayground.Application.Commands;
using MediatR;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Application.Queries;

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
        public async Task<ActionResult<EmployeeResponse>> GetById(long id)
        {
            //It wraps the data in an ActionResult and uses the Ok method to return a 200 OK response along with the data. This method allows more flexibility in returning different HTTP status codes.
            if (id <= 0)
            {
                return BadRequest("Invalid Id provided. It cannot be negative or zero.");
            }

            var getEmployeeByIdQuery = new GetEmployeeByIdQuery(id);
            var employeeData = await _mediator.Send(getEmployeeByIdQuery);

            if (employeeData is null)
            {
                return NotFound("Could not find employee with provided ID");
            }

            return Ok(employeeData);
        }

        [HttpGet("getAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpPost("createEmployee")]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand employee)
        {
            if (employee is null || !ModelState.IsValid)
            {
                return BadRequest("Invalid employee details.");
            }

            var employeeResult = await _mediator.Send(employee);
            return Ok(employeeResult);
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (employee is null || !ModelState.IsValid)
            {
                return BadRequest("Invalid employee details.");
            }

            await _employeeService.UpdateAsync(employee);
            return Ok($"Employee with id {employee.Id} was updated successfully");
        }
    }
}