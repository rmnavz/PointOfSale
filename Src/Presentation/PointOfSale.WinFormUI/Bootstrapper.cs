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

namespace PointOfSale.WinFormUI
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            // Register Configuration
            var appSettings = new GlobalAppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            Locator.CurrentMutable.RegisterConstant(appSettings, typeof(GlobalAppSettings));
            Locator.CurrentMutable.RegisterConstant(Configuration, typeof(IConfiguration));

            // Register DatabaseContext
            var optionsbuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsbuilder.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
            var context = new DatabaseContext(optionsbuilder.Options);
            Locator.CurrentMutable.RegisterConstant(context, typeof(DatabaseContext));

            // Register views
            Locator.CurrentMutable.Register(() => new ContainerView(), typeof(IViewFor<ContainerViewModel>));
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
            Application.Run((Form)view);
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
