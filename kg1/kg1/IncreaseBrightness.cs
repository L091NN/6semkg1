using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class IncreaseBrightness : Filters
    {
        private const int value_to_increase_brightness = 0x32;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int red   = sourceColor.R;
            int green = sourceColor.G;
            int blue  = sourceColor.B;

            byte new_red   = clamp(red   + value_to_increase_brightness);
            byte new_green = clamp(green + value_to_increase_brightness);
            byte new_blue  = clamp(blue  + value_to_increase_brightness);

            return Color.FromArgb(new_red, new_green, new_blue);
        }

        byte clamp(int value)
        {
            if(0 > value)
            {
                return (byte)0;
            }
            else if(0xff < value)
            {
                return (byte)0xff;
            }

            return (byte)value;
        }
    }
}
