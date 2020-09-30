using MAQSTestSite.Core;
using MAQSTestSite.Core.Models;
using MAQSTestSite.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            await _unitOfWork.Employees.AddAsync(newEmployee);
            await _unitOfWork.CommitAsync();
            return newEmployee;
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _unitOfWork.Employees.Remove(employee);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithDepartment()
        {
            return await _unitOfWork.Employees
                .GetAllWithDepartmentAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _unitOfWork.Employees
                .GetWithDepartmentByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentId(int departmentId)
        {
            return await _unitOfWork.Employees
                .GetAllWithDepartmentByDepartmentIdAsync(departmentId);
        }

        public async Task UpdateEmployee(Employee employeeToBeUpdated, Employee employee)
        {
            employeeToBeUpdated.FirstName = employee.FirstName;
            employeeToBeUpdated.LastName = employee.LastName;
            employeeToBeUpdated.Address = employee.Address;
            employeeToBeUpdated.DepartmentId = employee.DepartmentId;

            await _unitOfWork.CommitAsync();
        }
    }
}
