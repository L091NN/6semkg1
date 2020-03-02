using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class DecreaseBrightness : Filters
    {
        private const int value_to_decrease_brightness = 0x32;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int red   = sourceColor.R;
            int green = sourceColor.G;
            int blue  = sourceColor.B;

            byte new_red   = (byte)clamp(red   - value_to_decrease_brightness, 0, 0xff);
            byte new_green = (byte)clamp(green - value_to_decrease_brightness, 0, 0xff);
            byte new_blue  = (byte)clamp(blue  - value_to_decrease_brightness, 0, 0xff);

            return Color.FromArgb(new_red, new_green, new_blue);
        }
    }
}
