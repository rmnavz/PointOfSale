using PointOfSale.WinFormUI.ViewModels;
using PointOfSale.WinFormUI.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Splat;
using ReactiveUI;
using System.Windows.Forms;
using System.IO;
using System;
using PointOfSale.Persistence;
using PointOfSale.WinFormUI.Core;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PointOfSale.Common.Interfaces;
using PointOfSale.Infrastructure;

namespace PointOfSale.WinFormUI
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            ConfigureServices();
        }

        private IMutableDependencyResolver IOC = Locator.CurrentMutable;

        private void ConfigureServices()
        {

            // Register Framework Services
            IOC.Register(() => new MachineDateTime(), typeof(IDateTime));
            IOC.Register(() => new AuthenticationService(), typeof(IAuthenticationService));

            // Register Configuration
            var appSettings = new GlobalAppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            IOC.RegisterConstant(appSettings, typeof(GlobalAppSettings));
            IOC.RegisterConstant(Configuration, typeof(IConfiguration));

            // Register DatabaseContext
            IOC.Register(() =>
            {
                var optionsbuilder = new DbContextOptionsBuilder<DatabaseContext>();
                // MS SQL Server
                switch (appSettings.DbProvider)
                {
                    case "MSSQL":
                        optionsbuilder.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
                        break;
                    case "MYSQL":
                        optionsbuilder.UseMySql(Configuration.GetConnectionString("DatabaseConnection"), mySqlOptions => {
                            mySqlOptions.ServerVersion(new Version(10, 4, 8), ServerType.MariaDb);
                        });
                        break;
                    default:
                        optionsbuilder.UseInMemoryDatabase($"PointOfSale_{Guid.NewGuid()}");
                        break;
                }
                return new DatabaseContext(optionsbuilder.Options);
            }, typeof(DatabaseContext));

            // Register ViewLocator
            IOC.RegisterLazySingleton(() => new ConventionalViewLocator(), typeof(IViewLocator));

            // Register Views
            RegisterViews();

        }

        private void RegisterViews()
        {
            IOC.Register(() => new ContainerView(), typeof(IViewFor<ContainerViewModel>));
            IOC.Register(() => new LoginView(), typeof(IViewFor<LoginViewModel>));
            IOC.Register(() => new DashboardView(), typeof(IViewFor<DashboardViewModel>));
        }

        public void Run()
        {
            // Create ResponsiveObject and register as Responsive
            var responsiveObj = new Responsive(Screen.PrimaryScreen.Bounds);
            responsiveObj.SetMultiplicationFactor();
            Locator.CurrentMutable.RegisterConstant(responsiveObj, typeof(Responsive));

            // Create MainWindowViewModel and register as IScreen
            var viewModel = new ContainerViewModel();
            Locator.CurrentMutable.RegisterConstant(viewModel, typeof(IScreen));

            // Resolve view for MainWindowViewModel
            var view = ViewLocator.Current.ResolveView(viewModel);
            view.ViewModel = viewModel;

            // Run application
            System.Windows.Forms.Application.Run((Form)view);
        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
    }
}
