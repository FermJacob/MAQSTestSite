using MAQSTestSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAQSTestSite.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        Task<int> CommitAsync();
    }
}
