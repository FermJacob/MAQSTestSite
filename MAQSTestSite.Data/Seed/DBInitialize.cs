using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MAQSTestSite.Core.Models;

namespace MAQSTestSite.Data.Seed
{
    public static class DBInitialize
    {

        public static void SeedData(MyCompanyDbContext myCompanyDbContext)
        {
            myCompanyDbContext.Database.EnsureCreated();
            if (!myCompanyDbContext.Departments.Any())
            {
                // Add departments data

                myCompanyDbContext.Departments.AddRange(
                    new Department()
                    {
                        Id = 1,
                        Name = "QA"
                    },
                    new Department()
                    {
                        Id = 2,
                        Name = "DEV"
                    },
                    new Department()
                    {
                        Id = 3,
                        Name = "HR"
                    },
                    new Department()
                    {
                        Id = 4,
                        Name = "Sales"
                    }
                );
                myCompanyDbContext.SaveChanges();

                if (!myCompanyDbContext.Employees.Any())
                {
                    myCompanyDbContext.Employees.AddRange(
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 1,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 1
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 2,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 1
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 3,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 1
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 4,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 1
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 5,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 2
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 6,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 2
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 7,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 2
                        },
                        new Employee
                        {
                            FirstName = Faker.Name.FirstName(),
                            LastName = Faker.Name.LastName(),
                            Id = 8,
                            Address = $"{Faker.Number.RandomNumber(0, 99999)} {Faker.Address.StreetName()} {Faker.Address.USCity()},{Faker.Address.StateAbbreviation()} {Faker.Address.USZipCode()}",
                            DepartmentId = 3
                        }
                    );
                    myCompanyDbContext.SaveChanges();
                }

            }
        }
    }
}
