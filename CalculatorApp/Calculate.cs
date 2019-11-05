using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    /// <summary>
    /// Perform arithmetic operations
    /// </summary>
    class Calculate : ICalculator
    {
        public double add(double x, double y)
        {
            return x + y;
        }
        public double subtract(double x, double y)
        {
            return x - y;
        }
        public double multiply(double x, double y)
        {
            return x * y;
        }
        public double divide(double x, double y)
        {
            return x / y;
        }
    }
}
