using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Model;

namespace TimeSheets.Data
{
    public interface IEmployeeDataImported
    {
        public List<Employee>? ImportEmployee();
    }
}
