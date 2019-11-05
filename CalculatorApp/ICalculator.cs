using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp
{
    /// <summary>
    /// Calculator Interface
    /// </summary>
    public interface ICalculator
    {
        double add(double x, double y);
        double subtract(double x, double y);
        double multiply(double x, double y);
        double divide(double x, double y);
    }
}
