using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Calculator
{
    public class Power : IEnergy
    {
        //Voltage and Current
        public double? Calc1(double? voltage, double? current)
        {
            return voltage * current;
        }

        //Resistance and Current
        public double? Calc2(double? resistance, double? current)
        {
            return resistance * Math.Pow((double)current, 2);
        }

        //Voltage and Resistance
        public double? Calc3(double? voltage, double? resistance)
        {
            return Math.Pow((double)voltage, 2) / resistance;
        }

        public string Name()
        {
            return "Watt";
        }

        public string Options()
        {
            return "\tVolt og Ampere\t\tOhm og Ampere\t\tVolt og Ohm";
        }
    }

    public class Voltage : IEnergy
    {
        //Resistance and Current
        public double? Calc1(double? resistance, double? current)
        {
            return resistance * current;
        }
        //Power and Current
        public double? Calc2(double? power, double? current)
        {
            return power / current;
        }

        //Power and Resistance
        public double? Calc3(double? power, double? resistance)
        {
            return Math.Sqrt((double)(power * resistance));
        }

        public string Name()
        {
            return "Volt";
        }

        public string Options()
        {
            return "\tOhm og Ampere\t\tWatt og Ampere\t\tWatt og Ohm";
        }
    }

    public class Resistance : IEnergy
    {
        //Voltage and Current
        public double? Calc1(double? voltage, double? current)
        {
            return voltage / current;
        }

        //Voltage and Power
        public double? Calc2(double? voltage, double? power)
        {
            return Math.Pow((double)voltage, 2) / power;
        }

        //Power and Current
        public double? Calc3(double? power, double? current)
        {
            return power / Math.Pow((double)current, 2);
        }

        public string Name()
        {
            return "Ohm";
        }

        public string Options()
        {
            return "\tVolt og Ampere\t\tVolt og Watt\t\tWatt og Ampere";
        }
    }

    public class Current : IEnergy
    {
        //Voltage and Resistance
        public double? Calc1(double? voltage, double? resistance)
        {
            return voltage / resistance;
        }

        //Power and Voltage
        public double? Calc2(double? power, double? voltage)
        {
            return power / voltage;
        }

        //Power and Resistance
        public double? Calc3(double? power, double? resistance)
        {
            return Math.Sqrt((double)(power / resistance));
        }

        public string Name()
        {
            return "Ampere";
        }

        public string Options()
        {
            return "\tVolt og Ohm\t\tWatt og Volt\t\tWatt og Ohm";
        }
    }
}
