namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Projects");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectDto>), xmlRoot);

            var projectsDto = (List<ImportProjectDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                DateTime openDate;
                var isValidOpenDate = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDate);

                DateTime? dueDate = null;
                DateTime checkDueDate;

                if (projectDto.DueDate != null && projectDto.DueDate != string.Empty)
                {
                    var isValidDueDate = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out checkDueDate);

                    if (!isValidDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = checkDueDate;
                }


                if (!IsValid(projectDto) || !isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var tasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    DateTime openTaskDate;
                    var isValidOpenTaskDate = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openTaskDate);

                    DateTime dueTaskDate;
                    var isValidDueTaskDate = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueTaskDate);

                    if (!IsValid(taskDto) || !isValidOpenTaskDate || !isValidDueTaskDate || openTaskDate < openDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dueDate.HasValue)
                    {
                        if (dueTaskDate > dueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }

                    var task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = openTaskDate,
                        DueDate = dueTaskDate,
                        ExecutionType = Enum.Parse<ExecutionType>(taskDto.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(taskDto.LabelType)
                    };

                    tasks.Add(task);
                }

                var project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                    Tasks = tasks
                };

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().Trim();

        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Employee> employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                //TODO be shure of valid UserName only letters& num
                //For now is with regex

                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                var tasks = new List<Task>();

                foreach (var taskDto in employeeDto.Tasks.Distinct())
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskDto);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Task = task,
                        Employee = employee
                    });
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}