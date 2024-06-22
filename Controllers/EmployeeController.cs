using Microsoft.AspNetCore.Mvc;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Service.Services;

namespace RestApiPlayground.Controllers
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
        public async Task<Employee> GetById(int id)
        {
            return await _employeeService.GetByIdAsync(id);
        }

        [HttpGet("getAllEmployees")]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeService.GetAllAsync();
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            await _employeeService.AddAsync(employee);
            return Ok();
        }
    }
}