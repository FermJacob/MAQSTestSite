using MAQSTestSite.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAQSTestSite.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasOne(m => m.Department)
                .WithMany(a => a.Employees)
                .HasForeignKey(m => m.DepartmentId);

            builder
                .ToTable("Empployees");
        }
    }
}
