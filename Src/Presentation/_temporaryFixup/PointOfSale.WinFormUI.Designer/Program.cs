using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI.Designer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Console.WriteLine("This is just a temporary fix to Net Core 3.0 Winform's Designer Support on Visual Studio. Please Run the PointOfSale.WinFormUI Project to Debug/Build");
        }
    }
}
