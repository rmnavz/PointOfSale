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
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

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
