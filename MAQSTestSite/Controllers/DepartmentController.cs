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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IMapper mapper;
        
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            this.departmentService = departmentService;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DepartmentResource>>> GetAllDepartments()
        {
            var departments = await departmentService.GetAllDepartments();
            var departmentsResources = mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(departments);

            return Ok(departmentsResources);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult<DepartmentResource>> GetDepartmentById(int id)
        {
            var department = await departmentService.GetDepartmentById(id);
            if(department == null)
            {
                return NotFound();
            }
            var departmentResource = mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }

        [HttpGet("{id}/AllEmployees")]
        public async Task<ActionResult<DepartmentWithEmployeesResource>> GetAllEmployeesByDepartmentId(int id)
        {
            var department = await departmentService.GetDepartmentByIdWithEmployees(id);
            var departmentResource = mapper.Map<Department, DepartmentWithEmployeesResource>(department);
            return Ok(departmentResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<DepartmentResource>> CreateDepartment([FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDepartmentResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var departmentToCreate = mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);

            var newDepartment = await departmentService.CreateDepartment(departmentToCreate);

            var department = await departmentService.GetDepartmentById(newDepartment.Id);

            var departmentResource = mapper.Map<Department, DepartmentResource>(department);

            return Ok(departmentResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentResource>> UpdateDepartment(int id, [FromBody] SaveDepartmentResource saveDepartmentResource)
        {
            var validator = new SaveDepartmentResourceValidator();
            var validationResult = await validator.ValidateAsync(saveDepartmentResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var departmentToBeUpdated = await departmentService.GetDepartmentById(id);

            if (departmentToBeUpdated == null)
                return NotFound();

            var department = mapper.Map<SaveDepartmentResource, Department>(saveDepartmentResource);

            await departmentService.UpdateDepartment(departmentToBeUpdated, department);

            var updatedDepartment = await departmentService.GetDepartmentById(id);

            var updatedDepartmentResource = mapper.Map<Department, DepartmentResource>(updatedDepartment);

            return Ok(updatedDepartmentResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            await departmentService.DeleteDepartment(department);

            return NoContent();
        }

    }
}
