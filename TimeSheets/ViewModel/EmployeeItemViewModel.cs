using System.Security;
using TimeSheets.Model;

namespace TimeSheets.ViewModel
{
    public class EmployeeItemViewModel : ViewModelBase
    {
        private readonly Employee _model;

        public EmployeeItemViewModel(Employee employee)
        {
            _model = employee;
        }

        public int EmployeeId => _model.EnployeeId;
        
        public string? FirstName
        {
            get => _model.FirstName;
            set 
            { 
                _model.FirstName = value; 
                NotifyPropertyChanged(nameof(FirstName));
            }
        }
        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }

        public double PayRate
        {
            get => _model.PayRate;
            set
            {
                _model.PayRate = value;
                NotifyPropertyChanged(nameof(PayRate));
            }
        }
        public bool ApplyTaxFreeThreshold => _model.ApplyTaxFreeThreshold;
        
        public bool IsLogin { get; set; }
        public string? UserPassword
        {
            get => (_model.UserPassword == null) ? null : _model.UserPassword;
            set 
            { 
                _model.UserPassword = value;
                NotifyPropertyChanged(nameof(UserPassword));
            }
        }

        public string? InputPassword
        {
            
            set
            {

                var inputPassword = value;
                NotifyPropertyChanged(nameof(InputPassword));
                if (inputPassword != null)
                {
                    if (inputPassword == UserPassword)
                    {
                        IsLogin = true;
                    }
                    else
                    {
                        return;
                    }
                  
                }

            }
        }

        public bool Admin => _model.Admin;





    }
}
