using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using SoftUni;
using SoftUni.Data;
using SoftUni.Models;

// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace

[TestFixture]
public class Test_002
{
    [Test]
    public void ValidateOutput()
    {
        string expected = "";

        string result = Assembly.GetEntryAssembly()
                                   .GetTypes()
                                   .Where(t => t.Name.StartsWith("Test_"))
                                   .First()
                                   .Name;

        Assert.AreEqual(expected, result, "Returned value is incorrect!");
    }

    private void Seed(SoftUniContext context)
    {
        var employees = new List<Employee>();

        var firstNames = new[]
        {
            "Svetlin", "Mariela", "Ani", "Slavi", "Pesho",
            "Kircata", "Gosheto", "OnziTam", "DamnGod", "Test123"
        };

        var lastNames = new[]
        {
            "Nakov", "Cureva", "Topova", "Ludakov", "Peshev",
            "Wakov", "Sliperov", "Topalov", "Hristov", "Petrov"
        };

        var middleNames = new[]
        {
            "Petrov", "Kirov", "Stoyanov", "Angelov", "Vladimirov",
            "Karlov", "Markov", "Kostov", "Pavlov", "Georgiev"
        };

        var jobTitles = new[]
        {
            "Bartender", "Waiter", "Artist", "Shefa", "Driver",
            "IT", "DevOps", "DataScientist", "BusDriver", "Trainer",
        };

        var salaries = new[]
        {
            642.12m, 5235, 4000.32m, 25432, 2535235.33m,
            52354.12m, 956, 658.32m, 95846, 75343215.33m,
        };

        for (int i = 0; i < firstNames.Length; i++)
        {
            var employee = new Employee
            {
                FirstName = firstNames[i],
                LastName = lastNames[i],
                MiddleName = middleNames[i],
                JobTitle = jobTitles[i],
                Salary = salaries[i],
            };

            employees.Add(employee);
        }

        context.Employees.AddRange(employees);
        context.SaveChanges();
    }

    public static string AssertMethod(SoftUniContext context)
    {
        var content = new StringBuilder();

        string pattern = "SA";
        var employeesByNamePattern = context.Employees
            .Where(employee => employee.FirstName.StartsWith(pattern));

        foreach (var employeeByPattern in employeesByNamePattern)
        {
            content.AppendLine($"{employeeByPattern.FirstName} {employeeByPattern.LastName} " +
                               $"- {employeeByPattern.JobTitle} - (${employeeByPattern.Salary})");
        }

        return content.ToString().TrimEnd();
    }
}