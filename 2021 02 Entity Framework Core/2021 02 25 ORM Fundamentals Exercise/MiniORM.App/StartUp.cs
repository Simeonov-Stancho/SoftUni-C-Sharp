using MiniORMCore.MiniORM.App.Data;
using MiniORMCore.MiniORM.App.Data.Entities;
using System.Linq;

namespace MiniORMCore
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connectionString = @"Server=.;Database=MiniORM;Integrated Security=true;";

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges(); ;
        }
    }
}
