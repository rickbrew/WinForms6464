using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms6464
{
    internal static class DoubleUtil
    {
        public static byte ClampToByte(double value)
        {
            if (value <= (double)byte.MinValue)
            {
                return byte.MinValue;
            }

            if (value >= (double)byte.MaxValue)
            {
                return byte.MaxValue;
            }

            return (byte)value;
        }
    }
}
