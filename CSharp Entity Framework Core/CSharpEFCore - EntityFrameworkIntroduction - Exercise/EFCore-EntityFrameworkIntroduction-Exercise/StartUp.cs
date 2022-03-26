using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using SoftUni.Data;
using SoftUni.Models;
using Microsoft.EntityFrameworkCore;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //Console.WriteLine(GetEmployeesFullInformation(context));
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
            //Console.WriteLine(AddNewAddressToEmployee(context));
            //Console.WriteLine(GetEmployeesInPeriod(context));
            //Console.WriteLine(GetAddressesByTown(context));
            //Console.WriteLine(GetEmployee147(context));
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
            //Console.WriteLine(GetLatestProjects(context));
            //Console.WriteLine(IncreaseSalaries(context));
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
            //Console.WriteLine(DeleteProjectById(context));
            Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            List<Employee> db = context.Employees
                .OrderBy(x => x.EmployeeId)
                .ToList();

            foreach (Employee employee in db)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            List<Employee> db = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .ToList();

            foreach (Employee employee in db)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var db = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToList();

            foreach (var employee in db)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address() 
            { 
              AddressText = "Vitoshka 15",
              TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context.Employees
                .Where(x => x.LastName == "Nakov")
                .FirstOrDefault();

            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            List<string> allEmployeesAddresses = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(x => x.Address.AddressText)
                .ToList();

            return string.Join(Environment.NewLine, allEmployeesAddresses);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(ep => ep.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new 
                { 
                  EmployeeFirstName = e.FirstName,
                  EmployeeLastName = e.LastName,
                  ManagerFirstName = e.Manager.FirstName,
                  ManagerLastName = e.Manager.LastName,
                  Projects = e.EmployeesProjects
                  .Select(p => new  
                  { 
                    ProjectName = p.Project.Name,
                    StartDate = p.Project.StartDate,
                    EndDate = p.Project.EndDate
                  })
                })      
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    string endDate = project.EndDate.HasValue ? project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished";

                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                  .OrderBy(x => x.Project.Name)
                  .Select(p => new
                  {
                      ProjectName = p.Project.Name
                  })
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var project in employee147.Projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context) 
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees
                    .Select(e => new
                    {
                       e.FirstName,
                       e.LastName,
                       e.JobTitle
                    })
                })
                .ToList();

            foreach (var dp in departments)
            {
                sb.AppendLine($"{dp.DepartmentName} - {dp.ManagerFirstName} {dp.ManagerLastName}");

                foreach (var employee in dp.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            IQueryable<Employee> employeesToIncreaseSalary = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services");

            foreach (Employee employee in employeesToIncreaseSalary)
            {
                employee.Salary += employee.Salary * 0.12M;
            }

            context.SaveChanges();

            var employeesToDisplay = employeesToIncreaseSalary
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employeesToDisplay)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesStartsWithSa = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "sa%"))
                //.Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var emp in employeesStartsWithSa)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            List<EmployeeProject> employeesProjects = context.EmployeesProjects
                .Where(x => x.ProjectId == 2)
                .ToList();
            context.EmployeesProjects.RemoveRange(employeesProjects);

            Project projectToDelete = context.Projects.Find(2);
            context.Projects.Remove(projectToDelete);

            context.SaveChanges();

           List<string> projects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            return string.Join(Environment.NewLine, projects);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            Town townToRemove = context.Towns
                .First(t => t.Name == "Seattle");

            List<Address> addressesToRemove = context.Addresses
                .Where(a => a.Town == townToRemove)
                .ToList();

            List<Employee> employeesInSeattle = context.Employees
                .ToList()
                .Where(e => addressesToRemove.Any(a => a.AddressId == e.AddressId))
                .ToList();

            foreach (Employee employee in employeesInSeattle)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToRemove);
            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addressesToRemove.Count} addresses in Seattle were deleted";
        }
    }
}
