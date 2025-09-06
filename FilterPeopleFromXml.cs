using System;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;

public class Pusula
{

    public static string FilterPeopleFromXml(string xmlData)
    {
        if (string.IsNullOrEmpty(xmlData))
            return JsonSerializer.Serialize(new { Names = new List<string>(), TotalSalary = 0, AverageSalary = 0, MaxSalary = 0, Count = 0 });

        XDocument doc = XDocument.Parse(xmlData);

        var filteredPeople = doc.Descendants("Person")
            .Select(p => new
            {
                Name = (string)p.Element("Name"),
                Age = (int)p.Element("Age"),
                Department = (string)p.Element("Department"),
                Salary = (int)p.Element("Salary"),
                HireDate = DateTime.Parse((string)p.Element("HireDate"))
            })
            .Where(p => p.Age > 30 && p.Department == "IT" && p.Salary > 5000 && p.HireDate.Year < 2019)
            .ToList();

        var names = filteredPeople.Select(p => p.Name).OrderBy(n => n).ToList();
        int totalSalary = filteredPeople.Sum(p => p.Salary);
        int maxSalary = filteredPeople.Count > 0 ? filteredPeople.Max(p => p.Salary) : 0;
        int count = filteredPeople.Count;
        int averageSalary = count > 0 ? totalSalary / count : 0;

        var result = new
        {
            Names = names,
            TotalSalary = totalSalary,
            AverageSalary = averageSalary,
            MaxSalary = maxSalary,
            Count = count
        };

        return JsonSerializer.Serialize(result);
    }
}
