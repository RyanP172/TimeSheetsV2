using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Model
{
    public class Employee
    {
        public int EnployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public double PayRate { get; set; }
        public bool ApplyTaxFreeThreshold { get; set; }
        public string? UserPassword { get; set; }
        public bool Admin { get; set; }
    }
}
