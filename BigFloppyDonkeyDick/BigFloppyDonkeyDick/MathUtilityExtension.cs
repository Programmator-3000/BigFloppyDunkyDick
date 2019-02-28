using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFloppyDonkeyDick
{
    public static class MathUtilityExtension
    {
        public static T Clamp<T>(this T x, T min, T max) where T : IComparable<T>
        {
            if (x.CompareTo(min) < 0)
            {
                return min;
            }

            if (x.CompareTo(max) > 0)
            {
                return max;
            }

            return x;
        }
    }
}
