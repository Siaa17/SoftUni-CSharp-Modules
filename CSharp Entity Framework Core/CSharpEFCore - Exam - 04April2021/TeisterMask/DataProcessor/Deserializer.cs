namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), xmlRoot);

            StringReader reader = new StringReader(xmlString);

            ImportProjectDto[] dtoProjects = (ImportProjectDto[])xmlSerializer.Deserialize(reader);

            HashSet<Project> projects = new HashSet<Project>();

            foreach (ImportProjectDto dtoProject in dtoProjects)
            {
                if (!IsValid(dtoProject))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact(dtoProject.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;

                if (!string.IsNullOrWhiteSpace(dtoProject.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact(dtoProject.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateValue);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    dueDate = dueDateValue;
                }

                Project project = new Project()
                {
                    Name = dtoProject.Name,
                    OpenDate = openDate,
                    DueDate = dueDate
                };

                HashSet<Task> projectTasks = new HashSet<Task>();

                foreach (ImportProjectTasksDto dtoTask in dtoProject.Tasks)
                {
                    if (!IsValid(dtoTask))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskOpenDateValid = DateTime.TryParseExact(dtoTask.TaskOpenDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact(dtoTask.TaskDueDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (project.DueDate.HasValue && taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = dtoTask.TaskName,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)dtoTask.ExecutionType,
                        LabelType = (LabelType)dtoTask.LabelType,
                        Project = project
                    };

                    projectTasks.Add(task);
                }

                project.Tasks = projectTasks;
                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, projectTasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<ImportEmployeeDto> dtoEmployees = JsonConvert.DeserializeObject<ICollection<ImportEmployeeDto>>(jsonString);

            HashSet<Employee> validEmployees = new HashSet<Employee>();

            foreach (ImportEmployeeDto dtoEmployee in dtoEmployees)
            {    
                if (!IsValid(dtoEmployee))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee employee = new Employee()
                {
                    Username = dtoEmployee.Username,
                    Email = dtoEmployee.Email,
                    Phone = dtoEmployee.Phone
                };

                HashSet<EmployeeTask> employeeTasks = new HashSet<EmployeeTask>();

                foreach (int taskId in dtoEmployee.Tasks.Distinct())
                {
                    Task task = context.Tasks
                        .Find(taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        TaskId = taskId
                    };

                    employeeTasks.Add(employeeTask);
                }

                employee.EmployeesTasks = employeeTasks;
                validEmployees.Add(employee);

                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employeeTasks.Count));                
            }

            context.Employees.AddRange(validEmployees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}