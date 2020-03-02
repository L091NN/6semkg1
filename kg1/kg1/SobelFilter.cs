using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class SobelFilterX : MatrixFilter
    {
        public SobelFilterX()
        {
            kernel = new float[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    kernel[x, y] = (x - 1) * (y % 2 + 1);
                }
            }
        }
    }

    class SobelFilterY : MatrixFilter
    {
        public SobelFilterY()
        {
            kernel = new float[3, 3];

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    kernel[y, x] = (x - 1) * (y % 2 + 1);
                }
            }
        }
    }
}
