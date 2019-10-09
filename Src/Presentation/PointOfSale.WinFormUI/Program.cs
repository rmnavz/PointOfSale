using Microsoft.EntityFrameworkCore;
using PointOfSale.Persistence;
using Splat;
using System;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create and run Bootstrapper
            var bootstrapper = new Bootstrapper();

            using (var context = Locator.Current.GetService<DatabaseContext>())
            {
                
                try
                {
                    context.Database.Migrate();

                    DatabaseInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
            }

            bootstrapper.Run();
        }
    }
}
