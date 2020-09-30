using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MAQSTestSite.Core.Models;
using MAQSTestSite.Core.Services;
using MAQSTestSite.Resources;
using MAQSTestSite.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAQSTestSite.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        private readonly IDepartmentService departmentService;

        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IMapper mapper)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            var employees = await employeeService.GetAllWithDepartment();
            var employeeResource = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employees);

            return Ok(employeeResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResource>> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetEmployeeById(id);
            var employeeResource = mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(employeeResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<EmployeeResource>> CreateEmployee([FromBody] SaveEmployeeResource saveEmployeeResource)
        {
            var validator = new SaveEmployeeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveEmployeeResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var department = await departmentService.GetDepartmentById(saveEmployeeResource.DepartmentId);
            if (department == null)
            {
                return NotFound("Department ID not found");
            }

            var employeeToCreate = mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);

            var newEmployee = await employeeService.CreateEmployee(employeeToCreate);

            var employee = await employeeService.GetEmployeeById(newEmployee.Id);

            var employeeResource = mapper.Map<Employee, EmployeeResource>(employee);

            return Ok(employeeResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeResource>> UpdateEmployee(int id, [FromBody] SaveEmployeeResource saveEmployeeResource)
        {
            var validator = new SaveEmployeeResourceValidator();
            var validationResult = await validator.ValidateAsync(saveEmployeeResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var employeeToBeUpdated = await employeeService.GetEmployeeById(id);

            if (employeeToBeUpdated == null)
                return NotFound();

            var employee = mapper.Map<SaveEmployeeResource, Employee>(saveEmployeeResource);

            await employeeService.UpdateEmployee(employeeToBeUpdated, employee);

            var updatedEmployee = await employeeService.GetEmployeeById(id);
            var updatedEmployeeResource = mapper.Map<Employee, EmployeeResource>(updatedEmployee);

            return Ok(updatedEmployeeResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id == 0)
                return BadRequest();

            var employee = await employeeService.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            await employeeService.DeleteEmployee(employee);

            return NoContent();
        }
    }
}
