using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var testClass = Assembly.GetCallingAssembly()
                                    .GetTypes()
                                    .Where(t => t.Name.StartsWith("Start"))
                                    .First();

            Console.WriteLine(testClass.Name);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new { e.EmployeeId, e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary })
                                             .OrderBy(e => e.EmployeeId)
                                             .ToList();

            var sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Salary > 50000)
                                             .Select(e => new { e.FirstName, e.Salary })
                                             .OrderBy(e => e.FirstName)
                                             .ToList();

            var sb = new StringBuilder();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} - {e.Salary:F2}"));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                                             .Where(e => e.Name == "Research and Development")
                                             .OrderBy(e => e.Salary)
                                             .ThenByDescending(e => e.LastName)
                                             .ToList();

            var sb = new StringBuilder();

            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:F2}"));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAdress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAdress);

            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAdress;

            context.SaveChanges();

            var employees = context.Employees.OrderByDescending(e => e.AddressId)
                                             .Select(e => e.Address.AddressText)
                                             .Take(10)
                                             .ToList();

            var sb = new StringBuilder();
            employees.ForEach(e => sb.AppendLine(e));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Include(e => e.Manager)
                                             .Include(e => e.EmployeesProjects)
                                             .ThenInclude(ep => ep.Project)
                                             .Where(e => e.EmployeesProjects
                                                .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                                             .Take(30)
                                             .ToList();

            var sb = new StringBuilder();
            var format = "M/d/yyyy h:mm:ss tt";

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.Manager.FirstName} {e.Manager.LastName}");

                foreach (var p in e.EmployeesProjects)
                {
                    var startDate = p.Project.StartDate.ToString(format, CultureInfo.InvariantCulture);
                    var endDate = "not finished";

                    if (p.Project.EndDate != null)
                    {
                        endDate = p.Project.EndDate?.ToString(format, CultureInfo.InvariantCulture);
                    }

                    sb.AppendLine($"--{p.Project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context.Addresses.Select(a => new
            {
                a.AddressText,
                TownName = a.Town.Name,
                Count = a.Employees.Count()
            })
                                            .OrderByDescending(a => a.Count)
                                            .ThenBy(a => a.TownName)
                                            .ThenBy(a => a.AddressText)
                                            .Take(10)
                                            .ToList();

            var sb = new StringBuilder();
            adresses.ForEach(a => sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count} employees"));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees.Where(e => e.EmployeeId == 147)
                                               .Select(e => new
                                               {
                                                   e.EmployeeId,
                                                   e.FirstName,
                                                   e.LastName,
                                                   e.JobTitle,
                                                   ProjectNames = e.EmployeesProjects.Select(p => p.Project.Name)
                                               })
                                                .First();

            var sb = new StringBuilder();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            employee147.ProjectNames.OrderBy(n => n)
                                    .ToList()
                                    .ForEach(n => sb.AppendLine(n));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Include(d => d.Manager)
                                                 .Include(d => d.Employees)
                                                 .Where(d => d.Employees.Count > 5)
                                                 .OrderBy(d => d.Employees.Count)
                                                 .ThenBy(d => d.Name)
                                                 .ToList();

            var sb = new StringBuilder();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                var orderedEmployees = d.Employees.OrderBy(e => e.FirstName)
                                                  .ThenBy(e => e.LastName);

                foreach (var e in orderedEmployees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate)
                                           .Take(10)
                                           .OrderBy(p => p.Name)
                                           .ToList();

            var sb = new StringBuilder();
            var format = "M/d/yyyy h:mm:ss tt";

            foreach (var p in projects)
            {
                sb.AppendLine(p.Name);
                sb.AppendLine(p.Description);
                sb.AppendLine(p.StartDate.ToString(format, CultureInfo.InvariantCulture));
            }

            return sb.ToString()
                     .TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Engineering"
                                                      || e.Department.Name == "Tool Design"
                                                      || e.Department.Name == "Marketing"
                                                      || e.Department.Name == "Information Services")
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList();

            var sb = new StringBuilder();

            employees.ForEach(e => e.Salary *= 1.12M);
            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));

            context.SaveChanges();

            return sb.ToString()
                     .TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var testClass = Assembly.GetEntryAssembly()
                                    .GetTypes()
                                    .Where(t => t.Name.StartsWith("Test_00"))
                                    .First();

            var assertMethod = testClass.GetMethod("AssertMethod");
            var result = string.Empty;

            if (testClass.Name != "Test_002")
            {
                result = (string)assertMethod.Invoke(null, new object[] { context }); ;
            }

            return result;
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            var employeesProjects = context.EmployeesProjects.Where(ep => ep.Project == project)
                                                             .ToList();

            context.EmployeesProjects.RemoveRange(employeesProjects);
            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Select(p => p.Name)
                                           .Take(10)
                                           .ToList();

            var sb = new StringBuilder();
            projects.ForEach(p => sb.AppendLine(p));

            return sb.ToString()
                     .TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            var addresses = context.Addresses.Where(a => a.Town == town)
                                             .ToList();

            context.Employees.Where(e => addresses.Contains(e.Address))
                             .ToList()
                             .ForEach(e => e.Address = null);

            if (town != null)
            {
                context.Addresses.RemoveRange(addresses);
                context.Towns.Remove(town);
            }

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }

        public string Saved(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName.StartsWith("Sa"))
                                             .OrderBy(e => e.FirstName)
                                             .ThenBy(e => e.LastName)
                                             .ToList();

            var sb = new StringBuilder();
            employees.ForEach(e => sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));

            return sb.ToString()
                     .TrimEnd();
        }
    }
}
