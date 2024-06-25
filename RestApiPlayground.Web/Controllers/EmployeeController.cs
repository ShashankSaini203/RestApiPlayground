using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Service.Services;

namespace RestApiPlayground.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
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
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee is null)
            {
                return BadRequest("Invalid employee details.");
            }

            await _employeeService.AddAsync(employee);
            return Ok();
        }
    }
}