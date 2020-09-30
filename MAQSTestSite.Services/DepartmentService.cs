using MAQSTestSite.Core;
using MAQSTestSite.Core.Models;
using MAQSTestSite.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Department> CreateDepartment(Department newDepartment)
        {
            await _unitOfWork.Departments
                .AddAsync(newDepartment);
            await _unitOfWork.CommitAsync();
            return newDepartment;
        }

        public async Task DeleteDepartment(Department department)
        {
            _unitOfWork.Departments.Remove(department);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _unitOfWork.Departments.GetAllAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _unitOfWork.Departments.GetByIdAsync(id);
        }

        public async Task UpdateDepartment(Department departmentToBeUpdated, Department department)
        {
            departmentToBeUpdated.Name = department.Name;

            await _unitOfWork.CommitAsync();
        }

        public async Task<Department> GetDepartmentByIdWithEmployees(int id)
        {
            return await _unitOfWork.Departments.GetWithEmployeesByIdAsync(id);
        }
    }
}
