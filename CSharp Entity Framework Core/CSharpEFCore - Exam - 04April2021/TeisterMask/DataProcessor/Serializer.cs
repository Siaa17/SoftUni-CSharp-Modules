namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Projects");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProjectDto[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            ExportProjectDto[] projectsWithTheirTasks = context.Projects
                .ToArray()
                .Where(p => p.Tasks.Any())
                .Select(p => new ExportProjectDto
                {
                    ProjectName = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks
                    .Select(t => new ExportProjectTasksDto
                    {
                        TaskName = t.Name,
                        TaskLabel = t.LabelType.ToString()
                    })
                    .OrderBy(x => x.TaskName)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
               .ToArray();

            xmlSerializer.Serialize(writer, projectsWithTheirTasks, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            List<ExportEmlpoyeeTasksDto> mostBusiestEmployees = context.Employees
                .ToList()
                .Where(x => x.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .Select(x => new ExportEmlpoyeeTasksDto
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks
                    .Where(x => x.Task.OpenDate >= date)
                    .Select(x => x.Task)
                    .OrderByDescending(x => x.DueDate)
                    .ThenBy(x => x.Name)
                    .Select(x => new ExportTaskDto
                    {
                        TaskName = x.Name,
                        OpenDate = x.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = x.LabelType.ToString(),
                        ExecutionType = x.ExecutionType.ToString()
                    })
                .ToList()
                })
                .OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10)
                .ToList();

            string busiestEmployeesAsJson = JsonConvert.SerializeObject(mostBusiestEmployees, Formatting.Indented);

            return busiestEmployeesAsJson;
        }
    }
}