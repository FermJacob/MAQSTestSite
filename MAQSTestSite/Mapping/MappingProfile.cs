using AutoMapper;
using MAQSTestSite.Core.Models;
using MAQSTestSite.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAQSTestSite.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Employee, EmployeeResource>();
            CreateMap<Department, DepartmentResource>();

            // Resource to Domain
            CreateMap<EmployeeResource, Employee>();
            CreateMap<DepartmentResource, Department>();

            CreateMap<SaveEmployeeResource, Employee>();
            CreateMap<SaveDepartmentResource, Department>();
            CreateMap<Department, DepartmentWithEmployeesResource>().ConvertUsing(p => new DepartmentWithEmployeesResource()
            {
                Id = p.Id,
                Name = p.Name,
                Employees = p.Employees.Select(o => new DepartmentWithEmployeeResource()
                {
                    Id = o.Id,
                    Address = o.Address,
                    FirstName = o.FirstName,
                    LastName = o.LastName
                }).OrderBy(i => i.Id).ToList()
            });
        }
    }
}
