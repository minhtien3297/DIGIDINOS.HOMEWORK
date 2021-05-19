using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;

namespace com.dd.minhtien.bai1.com.dd.minhtien.demo
{
    class ProductDemo
    {
        public void  createProductTest ()
        {
            Product productTest = new Product();
            productTest.Id = 1;
            productTest.Name = "tien";
            productTest.CategoryId = 2;
        }

        public void printProduct(Product product)
        {
            Console.WriteLine("product id: " + product.Id + ", name: " + product.Name + ", categoryId: " + product.CategoryId);
        }
    }
}
