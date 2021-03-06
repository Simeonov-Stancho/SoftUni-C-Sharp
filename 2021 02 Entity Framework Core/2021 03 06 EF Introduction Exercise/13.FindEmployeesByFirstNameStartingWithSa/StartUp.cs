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
                //13. Find Employees by First Name Starting With Sa
                Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

                //12. Increase Salaries
                //Console.WriteLine(IncreaseSalaries(context));

                //11. Find Latest 10 Projects
                //Console.WriteLine(GetLatestProjects(context));

                //10. Departments with More Than 5 Employees
                //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

                //09. Employee 147
                //Console.WriteLine(GetEmployee147(context));

                //08.Addresses by Town
                //Console.WriteLine(GetAddressesByTown(context));

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

        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeWithId = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    EmploeeName = e.FirstName + " " + e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects.OrderBy(p => p.Project.Name)
                        .Select(p => new
                        {
                            ProjectName = p.Project.Name,
                        })
                });

            StringBuilder sb = new StringBuilder();

            foreach (var e in employeeWithId)
            {
                sb.AppendLine($"{e.EmploeeName} - {e.JobTitle}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine(p.ProjectName);
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsInfo = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    EmploeeInDepartment = d.Employees
                    .Select(e => new
                    {
                        EmploeeFirstName = e.FirstName,
                        EmploeeLastName = e.LastName,
                        EmploeeJobTitle = e.JobTitle
                    })
                    .OrderBy(e => e.EmploeeFirstName)
                    .ThenBy(e => e.EmploeeLastName)
                    .ToList()
                })
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var d in departmentsInfo)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.EmploeeInDepartment)
                {
                    sb.AppendLine($"{e.EmploeeFirstName} {e.EmploeeLastName} - {e.EmploeeJobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    Discription = p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var p in lastProjects)
            {
                sb.AppendLine(p.ProjectName);
                sb.AppendLine(p.Discription);
                sb.AppendLine(p.StartDate);
            }

            return sb.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var emploeesForIncreasingSelary = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                          e.Department.Name == "Tool Design" ||
                          e.Department.Name == "Marketing" ||
                          e.Department.Name == "Information Services")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    NewSelary = 1.12M * e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var e in emploeesForIncreasingSelary)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.NewSelary:F2})");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesStartingWith = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa", true, CultureInfo.InvariantCulture))
                .OrderBy(e => e.FirstName)
                .ThenBy(e=>e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Salary = e.Salary
                })
               .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var e in employeesStartingWith)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().Trim();
        }
    }
}
