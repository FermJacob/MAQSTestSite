using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAQSTestSite.Resources
{
    public class EmployeeResource
    {
        public int Id { get; set; }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address { get; set; }
        public DepartmentResource Department { get; set; }
    }
}
