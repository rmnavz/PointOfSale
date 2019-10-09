using Splat;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PointOfSale.WinFormUI
{
    public class Responsive
    {
        private static GlobalAppSettings appSettings = Locator.Current.GetService<GlobalAppSettings>();

        float WIDTH_AT_DESIGN_TIME = (float)Convert.ToDouble(appSettings.DESIGN_TIME_SCREEN_WIDTH);
        float HEIGHT_AT_DESIGN_TIME = (float)Convert.ToDouble(appSettings.DESIGN_TIME_SCREEN_HEIGHT);
        Rectangle Resolution;
        float WidthMultiplicationFactor;
        float HeightMultiplicationFactor;

        public Responsive(Rectangle ResolutionParam)
        {
            Resolution = ResolutionParam;
        }

        public void SetMultiplicationFactor()
        {
            WidthMultiplicationFactor = Resolution.Width / WIDTH_AT_DESIGN_TIME;
            HeightMultiplicationFactor = Resolution.Height / HEIGHT_AT_DESIGN_TIME;
        }

        public void SetControls(Control.ControlCollection controlCollection)
        {
            if (controlCollection.Count > 0)
            {
                foreach (Control Ctl in controlCollection)
                {
                    if (Ctl is PictureBox)
                    {
                        Ctl.Width = GetMetrics(Ctl.Width, "Width");
                        Ctl.Height = GetMetrics(Ctl.Height, "Height");
                        Ctl.Top = GetMetrics(Ctl.Top, "Top");
                        Ctl.Left = GetMetrics(Ctl.Left, "Left");
                    }
                    else
                    {
                        Ctl.Font = new Font("Microsoft JhengHei",
                                            GetMetrics((int)Ctl.Font.Size), FontStyle.Regular);
                        Ctl.Width = GetMetrics(Ctl.Width, "Width");
                        Ctl.Height = GetMetrics(Ctl.Height, "Height");
                        Ctl.Top = GetMetrics(Ctl.Top, "Top");
                        Ctl.Left = GetMetrics(Ctl.Left, "Left");
                    }

                    SetControls(Ctl.Controls);
                }
            }
        }

        public int GetMetrics(int ComponentValue)
        {
            return (int)(Math.Floor(ComponentValue * WidthMultiplicationFactor));
        }

        public int GetMetrics(int ComponentValue, string Direction)
        {
            if (Direction.Equals("Width") || Direction.Equals("Left"))
                return (int)(Math.Floor(ComponentValue * WidthMultiplicationFactor));
            else if (Direction.Equals("Height") || Direction.Equals("Top"))
                return (int)(Math.Floor(ComponentValue * HeightMultiplicationFactor));
            return 1;
        }
    }
}
