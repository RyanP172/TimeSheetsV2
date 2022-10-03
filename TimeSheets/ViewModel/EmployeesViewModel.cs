using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Command;
using TimeSheets.Data;

namespace TimeSheets.ViewModel
{
    public class EmployeesViewModel : ViewModelBase
    {
        private readonly IEmployeeDataImported _employeeDataImported;
        private EmployeeItemViewModel? _selectedEmployee;

        public EmployeesViewModel(IEmployeeDataImported employeeDataImported)
        {
            _employeeDataImported = employeeDataImported;
            LoginCommand = new DelegateCommand(Login);
        }



        public ObservableCollection<EmployeeItemViewModel> Employees { get; } = new();
        public ObservableCollection<EmployeeItemViewModel> SelectedEmployees { get; } = new();

        public bool IsEmployeeSelected => SelectedEmployee != null;
        public bool SelectedEmployeeDetail { get; set; }
        

        public EmployeeItemViewModel? SelectedEmployee
        {
            get => _selectedEmployee;
            set 
            { 
                _selectedEmployee = value; 
                NotifyPropertyChanged(nameof(SelectedEmployee));
                NotifyPropertyChanged(nameof(IsEmployeeSelected));
            }
        }

        public DelegateCommand LoginCommand { get; }



        public void LoadData()
        {
            var employees = _employeeDataImported.ImportEmployee();

            if (Employees.Any())
            {
                return;//check if data is not load yet
            }

            if (employees != null)
            {
                foreach (var p in employees)
                {
                    Employees.Add(new EmployeeItemViewModel(p));
                }
            }

        }

        private void Login(object? parameter)
        {
            if (SelectedEmployee != null)
            {
                if (SelectedEmployee.IsLogin == true)
                {
                    SelectedEmployeeDetail = true;
                    SelectedEmployee.IsLogin = false;
                }
            }

        }

    }
}
