using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai22Recursion
{
    class Program
    {
        static int calMonthRecursion(double money, double rate)
        {
            int month = 0;

            while (calMoney(money, rate, month) < money * 2)
            {
                month++;
            }

            return month;
        }
        static double calMoney(double money, double rate, int month)
        {
            if (month == 0)
            {
                return money;
            }
            return calMoney(money, rate, month - 1) + calMoney(money, rate, month - 1) * rate / 100;

        }
        static int calMonth(double money, double rate)
        {
            int month = 0;
            double moneyIncrease = money;

            while (moneyIncrease < money * 2)
            {
                moneyIncrease += (rate / 100) * moneyIncrease;
                month++;
            }

            return month;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap so tien: ");
            double money = double.Parse(Console.ReadLine());

            Console.WriteLine("Nhap lai suat: ");
            double rate = double.Parse(Console.ReadLine());

            Console.WriteLine("So thang can gui tiet kiem la: ");
            Console.WriteLine(calMonth(money, rate));
            Console.WriteLine(calMonthRecursion(money, rate));

            Console.ReadKey();
        }
    }
}
