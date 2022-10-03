using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TimeSheets.Data;
using TimeSheets.ViewModel;

namespace TimeSheets
{

    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new();
            ConfigurationServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigurationServices(ServiceCollection services)
        {
            services.AddTransient<MainWindow>();
            services.AddTransient<EmployeesViewModel>();
            services.AddTransient<IEmployeeDataImported, EmployeeDataImported>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
