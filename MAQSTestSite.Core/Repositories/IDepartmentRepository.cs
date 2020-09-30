using MAQSTestSite.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Core.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithEmployeesAsync();
        Task<Department> GetWithEmployeesByIdAsync(int id);
    }
}
