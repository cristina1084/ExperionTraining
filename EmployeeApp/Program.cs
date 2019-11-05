/*A sample application to create/store/edit/retrieve employee details. 
  There is no need to use a database. Keep the data locally in a data structure.*/

using System;
using System.Collections.Generic;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;
            int empId;
            String empName;
            String dept;
            bool flag;
            double sal;
            List<Employee> e = new List<Employee>();
            while (true)
            {
                Console.WriteLine("1. Create\n2. Edit\n3. Retrieve\n4. Display All\n5. Exit\n");
                Console.Write("Enter choice: ");
                choice = Console.ReadLine();
                Console.WriteLine("");
                switch (choice)
                {
                    case "1":
                        Console.Write("ID: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        empName = Console.ReadLine();
                        Console.Write("Department: ");
                        dept = Console.ReadLine();
                        Console.Write("Salary: ");
                        sal = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("");
                        e.Add(new Employee {Id = empId, EmpName = empName, Dept = dept, Salary = sal });
                        break;

                    case "2":
                        Console.Write("Enter Employee ID: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        flag = false;
                        foreach (var emp in e)
                        {
                            if (emp.Id == empId)
                            {
                                Console.Write("Name: ");
                                emp.EmpName = Console.ReadLine();
                                Console.Write("Department: ");
                                emp.Dept = Console.ReadLine();
                                Console.Write("Salary: ");
                                emp.Salary = Convert.ToDouble(Console.ReadLine());
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                            Console.WriteLine("Employee not found");
                        Console.WriteLine("");
                        break;
                            
                    case "3":
                        Console.Write("Enter Employee ID: ");
                        empId = Convert.ToInt32(Console.ReadLine());
                        flag = false;
                        foreach (var emp in e)
                        {
                            if(emp.Id == empId)
                            {
                                Console.WriteLine("Employee: {0}, {1}, {2}, {3}", emp.Id, emp.EmpName, emp.Dept, emp.Salary);
                                flag = true;
                                break;
                            }
                        }
                        if(!flag)
                            Console.WriteLine("Employee not found");
                        Console.WriteLine("");
                        break;

                    case "4":
                        Console.WriteLine("Employee_Id\tEmployee_Name\tDepartment\tSalary");
                        foreach(var emp in e)
                            Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", emp.Id, emp.EmpName, emp.Dept, emp.Salary);
                        Console.WriteLine("");
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
