using MAQSTestSite.Core.Models;
using MAQSTestSite.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAQSTestSite.Data
{
    public class MyCompanyDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public MyCompanyDbContext(DbContextOptions<MyCompanyDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new EmployeeConfiguration());

            builder
                .ApplyConfiguration(new DepartmentConfiguration());
        }
    }
}
