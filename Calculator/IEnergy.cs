using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IEnergy
    {
        public string Name();

        public string Options();

        public double? Calc1(double? value1, double? Value2);
        public double? Calc2(double? value1, double? Value2);
        public double? Calc3(double? value1, double? Value2);
    }
}
