using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai5Array.Model;

namespace Bai5Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>
            {
                new Product("CPU",750,10,1),
                new Product( "RAM",  50, 2,  2),
                new Product( "HDD",  70,  1,  2),
                new Product( "Main",  400, 3, 1),
                new Product( "Keyboard",  30,  8,  4),
                new Product(  "Mouse",25,  50,  4),
                new Product(  "VGA", 60,  35,  3),
                new Product(  "Monitor",  120,  28,  2),
                new Product(  "Case", 120,  28,  5)
            };
            Product product = new Product();
            Console.WriteLine("Nhap id cua category:");
            product.Show(product.findProductByCategory(productList, int.Parse(Console.ReadLine())));
            Console.ReadKey();
        }
    }
}
