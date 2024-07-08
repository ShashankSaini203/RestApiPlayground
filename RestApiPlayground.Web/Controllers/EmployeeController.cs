using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Application.Commands;
using MediatR;
using RestApiPlayground.Application.Responses;
using RestApiPlayground.Application.Queries;
using System;
using FluentValidation;

namespace RestApiPlayground.API.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IValidator<CreateEmployeeCommand> _createEmployeeValidator;
        public EmployeeController(IMediator mediator, IValidator<CreateEmployeeCommand> createEmployeeValidator) : base(mediator)
        {
            _createEmployeeValidator = createEmployeeValidator;
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

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var query = new GetAllEmployeesQuery();

            return Ok(await _mediator.Send(query));
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand employee)
        {
            if (employee is not null)
            {
                var result = await _createEmployeeValidator.ValidateAsync(employee);

                if (!result.IsValid || !ModelState.IsValid)
                {
                    return BadRequest("Invalid employee details.");
                }
            }

            var employeeResult = await _mediator.Send(employee);
            return Ok(employeeResult);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<EmployeeResponse>> UpdateEmployee([FromBody] UpdateEmployeeCommand employee)
        {
            if (employee is null || !ModelState.IsValid)
            {
                return BadRequest("Invalid employee details.");
            }

            var updatedEmployeeResult = await _mediator.Send(employee);

            return Ok(updatedEmployeeResult);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<string>> DeleteEmployee(long id)
        {
            var deleteCommand = new DeleteEmployeeCommand(id);
            var result = await _mediator.Send(deleteCommand);

            return Ok(result);
        }

    }
}