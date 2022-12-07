using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Company_Roster
{
    class Program
    {
        class Emplyee
        {
            public Emplyee(string name, decimal salary)
            {
                Name = name;
                Salary = salary;
            }
            public string Name { get; set; }
            public decimal Salary { get; set; }
        }

        class Department
        {
            public Department(string nameOfDepartment)
            {
                DepartmentName = nameOfDepartment;
            }
            public string DepartmentName { get; set; }
            public List<Emplyee> Employees { get; set; } = new List<Emplyee>();
            public decimal TotalSalaries { get; set; }

            public void AddEmployee(string name, decimal salary)
            {
                Employees.Add(new Emplyee(name, salary));

                TotalSalaries += salary;
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();

            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split().ToArray();

                if (!departments.Any(x => x.DepartmentName == inputInfo[2]))
                {
                    departments.Add(new Department(inputInfo[2]));
                }

                departments.Find(x => x.DepartmentName == inputInfo[2]).AddEmployee(inputInfo[0], decimal.Parse(inputInfo[1]));
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
