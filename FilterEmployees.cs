using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class Pusula
{

    public static string FilterEmployees(IEnumerable<(string Name, int Age, string Department, decimal Salary, DateTime HireDate)> employees)
    {

        var filtered = employees
            .Where(e => e.Age >= 25 && e.Age <= 40)
            .Where(e => e.Department == "IT" || e.Department == "Finance")
            .Where(e => e.Salary >= 5000 && e.Salary <= 9000)
            .Where(e => e.HireDate > new DateTime(2017, 1, 1))
            .ToList();

        var names = filtered
            .Select(e => e.Name)
            .OrderByDescending(n => n.Length)
            .ThenBy(n => n)
            .ToList();

        decimal totalSalary = filtered.Sum(e => e.Salary);
        decimal averageSalary = filtered.Count > 0 ? Math.Round(filtered.Average(e => e.Salary), 2) : 0;
        decimal minSalary = filtered.Count > 0 ? filtered.Min(e => e.Salary) : 0;
        decimal maxSalary = filtered.Count > 0 ? filtered.Max(e => e.Salary) : 0;
        int count = filtered.Count;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MinSalary = minSalary,
            MaxSalary = maxSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result, options);
    }
}
