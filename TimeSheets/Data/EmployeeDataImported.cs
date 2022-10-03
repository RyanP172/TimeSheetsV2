using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Model;

namespace TimeSheets.Data
{
    public class EmployeeDataImported : IEmployeeDataImported
    {
        public List<Employee>? ImportEmployee()
        {
            string file = @"..\..\..\Import\employee.csv";
            using var sr = new StreamReader(file);
            var employees = new List<Employee>();
            string? line = sr.ReadLine();
            while (line != null)
            {
                string [] value = line.Split(',');
                var employee = new Employee()
                {
                    EnployeeId = int.Parse(value[0]),
                    FirstName = value[1],
                    LastName = value[2],
                    PayRate = double.Parse(value[3]),
                    ApplyTaxFreeThreshold = value[4] == "Y",
                    UserPassword = value[5],
                    Admin = value[6] == "Y",

                };

                employees.Add(employee);
                line = sr.ReadLine();
            }
            return employees;
        }
    }
}
