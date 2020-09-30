using MAQSTestSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Core.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> CreateDepartment(Department newDepartment);
        Task UpdateDepartment(Department departmentToBeUpdated, Department department);
        Task DeleteDepartment(Department department);

        Task<Department> GetDepartmentByIdWithEmployees(int id);
    }
}
