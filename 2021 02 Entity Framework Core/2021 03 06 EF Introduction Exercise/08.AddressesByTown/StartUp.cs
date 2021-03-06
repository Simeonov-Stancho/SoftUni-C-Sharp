using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            using (context)
            {
                //08.Addresses by Town
                Console.WriteLine(GetAddressesByTown(context));

                //07. Employees and Projects
                //Console.WriteLine(GetEmployeesInPeriod(context));

                //06. Adding a New Address and Updating Employee
                //Console.WriteLine(AddNewAddressToEmployee(context));

                //05. Employees from Research and Development
                //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

                //04.Employees with Salary Over 50 000
                //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

                //03.Employees Full Information
                //Console.WriteLine(GetEmployeesFullInformation(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employyes = context.Employees
                .OrderBy(x => x.EmployeeId).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in employyes)
            {
                sb.AppendLine($"{emploee.FirstName} {emploee.LastName} {emploee.MiddleName} {emploee.JobTitle} {emploee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employyes = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    Salary = e.Salary
                })
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in employyes)
            {
                sb.AppendLine($"{emploee.FirstName} - {emploee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employyes = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                })
                .OrderBy(x => x.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in employyes)
            {
                sb.AppendLine($"{emploee.FirstName} {emploee.LastName} from {emploee.DepartmentName} - ${emploee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var emploee = context.Employees
                 .FirstOrDefault(e => e.LastName == "Nakov");

            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            emploee.Address = newAddress;
            context.SaveChanges();

            var addresesOf10Emploee = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var empl in addresesOf10Emploee)
            {
                sb.AppendLine(empl);
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var emploees = context.Employees
                 .Where(e => e.EmployeesProjects
                    .Any(p => p.Project.StartDate.Year >= 2001 &&
                            p.Project.StartDate.Year <= 2003))
                 .Take(10)
                 .Select(e => new
                 {
                     EmploeeName = e.FirstName + " " + e.LastName,
                     ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                     Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = p.Project.EndDate.HasValue ?
                                                p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                                : "not finished"
                    })
                    .ToList()
                 })
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in emploees)
            {
                sb.AppendLine($"{emploee.EmploeeName} - Manager: {emploee.ManagerName}");

                foreach (var project in emploee.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmplCount = a.Employees.Count
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmplCount} employees");
            }

            return sb.ToString().Trim();
        }


    }
}
