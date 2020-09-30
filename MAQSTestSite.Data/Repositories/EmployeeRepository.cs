using MAQSTestSite.Core.Models;
using MAQSTestSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MyCompanyDbContext context)
            : base(context)
        { }
        public async Task<IEnumerable<Employee>> GetAllWithDepartmentAsync()
        {
            return await MyCompanyDbContext.Employees
                .Include(m => m.Department)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllWithDepartmentByDepartmentIdAsync(int departmentId)
        {
            return await MyCompanyDbContext.Employees
                .Include(m => m.Department)
                .Where(m => m.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<Employee> GetWithDepartmentByIdAsync(int id)
        {
            return await MyCompanyDbContext.Employees
                .Include(m => m.Department)
                .SingleOrDefaultAsync(m => m.Id == id); ;
        }

        private MyCompanyDbContext MyCompanyDbContext
        {
            get { return Context as MyCompanyDbContext; }
        }
    }
}
