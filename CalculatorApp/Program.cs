using System;

/*A calculator application to add, subtract, divide, and multiply two decimal values. 
  Need to handle different input scenarios. Make this application menu driven.*/

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, result;
            String choice = "0";
            Calculate cal = new Calculate();
            while (true)
            {
                Console.WriteLine(" 1. Add\n 2. Subtract\n 3. Multiply\n 4. Divide\n 5. Exit");
                Console.Write("Enter option:");
                choice = Console.ReadLine();
                if (choice == "5")
                {
                    Console.WriteLine("Exiting");
                    break;
                }
                Console.Write("Enter 1st number:");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter 2nd number");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Result:");
                switch (choice)
                {
                    case "1":
                        result = cal.add(a, b);
                        Console.WriteLine(result);
                        break;
                    case "2":
                        result = cal.subtract(a, b);
                        Console.WriteLine(result);
                        break;
                    case "3":
                        result = cal.multiply(a, b);
                        Console.WriteLine(result);
                        break;
                    case "4":
                        result = cal.divide(a, b);
                        break;
                }
            }
        }
    }
}
