using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeGUI
{
    public static class RandomValue
    {
        public static double RandomDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return Math.Round(random.NextDouble() * (maxValue - minValue) + minValue, 2);
        }

        public static int RandomInt(
            this Random random,
            int minValue,
            int maxValue)
        {
            return random.Next(minValue, maxValue+1);
        }
    }
}
