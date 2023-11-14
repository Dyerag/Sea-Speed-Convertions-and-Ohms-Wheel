using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SpeedConversions
    {
        public SpeedConversions()
        {
        }

        public double KnotToKmH(double knot)
        {
            return knot * 1.852;
        }

        public double KmHToKnot(double KmH)
        {
            return KmH * 0.539957;
        }
    }
}
