using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MAQSTestSite.Core.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new Collection<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Collection<Employee> Employees { get; set; }
    }
}
