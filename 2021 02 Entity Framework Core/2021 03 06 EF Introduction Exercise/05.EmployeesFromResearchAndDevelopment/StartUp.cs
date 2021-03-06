﻿using SoftUni.Data;
using System;
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
                //05. Employees from Research and Development
                Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

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
                .ThenByDescending(e=>e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var emploee in employyes)
            {
                sb.AppendLine($"{emploee.FirstName} {emploee.LastName} from {emploee.DepartmentName} - ${emploee.Salary:F2}");
            }
            return sb.ToString().Trim();
        }
    }
}
