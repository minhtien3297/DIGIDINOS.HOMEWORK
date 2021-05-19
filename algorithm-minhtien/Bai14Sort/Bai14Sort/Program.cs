using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai14Sort.Controllers;
using Bai14Sort.Models;

namespace Bai14Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

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

            List<Category> categoryList = new List<Category>
            {
                new Category(1,"Comuter"),
                new Category(2,"Memory"),
                new Category(3,"Card"),
                new Category(4,"Acsesory")
            };

            Console.WriteLine("Danh sach san pham co chua ten category theo category id:");
            controller.mapProductByCategory(productList, categoryList);
            Console.ReadKey();
        }
    }
}
