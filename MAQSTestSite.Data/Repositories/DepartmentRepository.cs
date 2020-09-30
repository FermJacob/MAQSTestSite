using MAQSTestSite.Core.Models;
using MAQSTestSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MyCompanyDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Department>> GetAllWithEmployeesAsync()
        {
            return await MyCompanyDbContext.Departments
                .Include(a => a.Employees)
                .ToListAsync();
        }

        public Task<Department> GetWithEmployeesByIdAsync(int id)
        {
            return MyCompanyDbContext.Departments
                .Include(a => a.Employees)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private MyCompanyDbContext MyCompanyDbContext
        {
            get { return Context as MyCompanyDbContext; }
        }
    }
}
