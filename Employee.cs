using System;
using System.Collections.Generic;
using System.Text;

namespace RPAChallenge
{
	internal class Employee
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string CompanyName { get; set; }
		public string Role { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }

		public string GetFieldValue(string inputName)
		{
			return inputName switch
			{
				"labelFirstName" => FirstName,
				"labelLastName" => LastName,
				"labelCompanyName" => CompanyName,
				"labelRole" => Role,
				"labelAddress" => Address,
				"labelEmail" => Email,
				"labelPhone" => PhoneNumber,
				_ => throw new ArgumentException($"Field '{inputName}' not implemented in class Employee")
			};

		}
	}
}
