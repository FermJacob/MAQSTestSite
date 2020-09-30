using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAQSTestSite.Resources
{
    public class DepartmentWithEmployeesResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DepartmentWithEmployeeResource> Employees { get; set; }
    }

    public class DepartmentWithEmployeeResource
    {
        public int Id { get; set; }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }
    }
}
