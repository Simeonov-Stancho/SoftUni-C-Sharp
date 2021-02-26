using MiniORMCore.MiniORM.App.Data.Entities;
using System;

namespace MiniORMCore.MiniORM.App.Data
{
    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeeProject> EmployeesProjects { get; }
    }
}
