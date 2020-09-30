using MAQSTestSite.Core;
using MAQSTestSite.Core.Repositories;
using MAQSTestSite.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyCompanyDbContext _context;
        private EmployeeRepository _employeeRepository;
        private DepartmentRepository _departmentRepository;

        public UnitOfWork(MyCompanyDbContext context)
        {
            this._context = context;
        }

        public IEmployeeRepository Employees => _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);

        public IDepartmentRepository Departments => _departmentRepository = _departmentRepository ?? new DepartmentRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
