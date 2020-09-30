using MAQSTestSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllWithDepartmentAsync();
        Task<Employee> GetWithDepartmentByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllWithDepartmentByDepartmentIdAsync(int departmentId);
    }
}
