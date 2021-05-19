using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai21Recursion
{
    class Program
    {
        static double calSalaryRecursion(double salary, int year)
        {
            if (year > 0)
            {
                return calSalaryRecursion(salary, year - 1) + (calSalaryRecursion(salary, year - 1) * 10) / 100;
            }
            else
                return salary;
        }

        static double calSalary(double salary, int year)
        {
            for (int i = 0; i < year; i++)
            {
                salary += (salary * 10) / 100;
            }

            return salary;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Nhap luong co ban: ");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhap so nam: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine($"Luong tai nam thu {year} la: ");
            Console.WriteLine(calSalary(salary, year));
            Console.WriteLine(calSalaryRecursion(salary, year));
            Console.ReadKey();
        }
    }
}