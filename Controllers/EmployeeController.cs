using Azure;
using EmployeePortal_Angular_CoreWebApi.Models;
using EmployeePortal_Angular_CoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeePortal_Angular_CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await this.employeeRepository.GetEmployeesAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)

        {
            await this.employeeRepository.SaveEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody]Employee employee)
        {
                    await this.employeeRepository.UpdateEmployee(id, employee);
                    return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await this.employeeRepository.DeleteEmployee(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmployee(int id, 
                                                      [FromBody] JsonPatchDocument<Employee> employeePatchDoc)
        {
            await this.employeeRepository.PatchEmployee(id, employeePatchDoc);
            return Ok();
            
        }
    }
}
