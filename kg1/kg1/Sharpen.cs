using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kg1
{
    class Sharpen : MatrixFilter
    {
        public Sharpen()
        {
            kernel = new float[3, 3];

            kernel[0, 0] = -1.0f;
            kernel[0, 1] = -1.0f;
            kernel[0, 2] = -1.0f;

            kernel[1, 0] = -1.0f;
            kernel[1, 1] =  9.0f;
            kernel[1, 2] = -1.0f;

            kernel[2, 0] = -1.0f;
            kernel[2, 1] = -1.0f;
            kernel[2, 2] = -1.0f;
        }
    }
}
