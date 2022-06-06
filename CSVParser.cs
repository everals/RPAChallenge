using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RPAChallenge
{
	internal static class CSVParser
	{
		internal static List<Employee> ParseEmployees(string path)
		{
			var employees = new List<Employee>();
			var text = File.ReadAllText(path);
			var lines = text
				.Split('\n')
				.Where(s => !string.IsNullOrWhiteSpace(s));
			

			foreach (var line in lines)
			{
				var fields = line
					.TrimEnd('\r')
					.Split(',')
					.Where(s => !string.IsNullOrWhiteSpace(s))
					.ToArray();

				employees.Add(new Employee()
				{
					FirstName = fields[0],
					LastName = fields[1],
					CompanyName = fields[2],
					Role = fields[3],
					Address = fields[4],
					Email = fields[5],
					PhoneNumber = fields[6]
				});
			}

			return employees;
		}
	}
}
