using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartdataSecurity.Model;
using SmartdataSecurityService.Interfaces;
using SmartdataSecurityService.Repositories;

namespace SmartdataSecurityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IConfiguration config, IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _configuration = config;
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                if (employees == null || !employees.Any())
                {
                    return NotFound("No employees found.");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching employees: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("test")]
        public IActionResult GetData()
        {
            return Ok("Success");
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching employee with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/employee/tenant/{tenantId}
        [HttpGet("tenant/{tenantId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByTenantId(int tenantId)
        {
            try
            {
                var employees = await _employeeRepository.GetEmployeesByTenantIdAsync(tenantId);
                if (employees == null || !employees.Any())
                {
                    return NotFound($"No employees found for Tenant ID {tenantId}.");
                }
                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching employees for Tenant ID {tenantId}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        // POST: api/employee
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest("Employee data is null.");
                }

                await _employeeRepository.AddAsync(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating employee: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Employee ID mismatch.");
                }

                var existingEmployee = await _employeeRepository.GetByIdAsync(id);
                if (existingEmployee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                await _employeeRepository.UpdateAsync(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating employee with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {id} not found.");
                }

                await _employeeRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting employee with ID {id}: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
