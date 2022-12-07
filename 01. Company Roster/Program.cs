using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        class Employee
        {
            public Employee(string name, decimal salary)
            {
                Name = name;
                Salary = salary;
            }
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }

        class Department
        {
            public Department(string departmentName)
            {
                DepartmentName = departmentName;
            }
            public string DepartmentName { get; set; }
            public List<Employee> Employees { get; set; } = new List<Employee>();
            public decimal TotalSalaries { get; set; }

            public void AddNewEmplyee(string name, decimal salary)
            {
                Employees.Add(new Employee(name ,salary));

                TotalSalaries += salary;
            }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();

            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split().ToArray();

                if (!departments.Any(x => x.DepartmentName == employeeInfo[2]))
                {
                    departments.Add(new Department(employeeInfo[2]));
                }

                departments.Find(x => x.DepartmentName == employeeInfo[2]).AddNewEmplyee(employeeInfo[0], decimal.Parse(employeeInfo[1]));
            }

            Department bestDepartment = departments.OrderByDescending(x => x.TotalSalaries / x.Employees.Count()).First();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartment.Employees.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }
}
