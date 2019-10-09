using System.Drawing;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI
{
    public class GlobalAppSettings
    {

        // Application Settings
        public string Secret { get; set; }
        public decimal DESIGN_TIME_SCREEN_WIDTH { get; set; }
        public decimal DESIGN_TIME_SCREEN_HEIGHT { get; set; }


        // User Settings

        public FormWindowState MainFormState { get; set; }
        public Point MainFormLocation { get; set; }
        public Size MainFormSize { get; set; }

    }
}
