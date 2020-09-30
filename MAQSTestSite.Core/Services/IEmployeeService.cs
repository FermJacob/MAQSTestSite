using MAQSTestSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllWithDepartment();
        Task<Employee> GetEmployeeById(int id);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(int departmentId);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task UpdateEmployee(Employee employeeToBeUpdated, Employee employee);
        Task DeleteEmployee(Employee employee);
    }
}
