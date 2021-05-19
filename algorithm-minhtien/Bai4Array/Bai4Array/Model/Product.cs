using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4Array.Model
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }
        public int CategoryID { get; set; }
        public Product(string name, int price, int quality, int categoryid)
        {
            Name = name;
            Price = price;
            Quality = quality;
            CategoryID = categoryid;
        }
        public Product()
        {

        }
        public Product findProduct(List<Product> productList, string name)
        {
            Product productSorted = new Product();
            foreach (Product product in productList)
            {
                if (name == product.Name)
                {
                    productSorted = product;
                }
            }
            return productSorted;
        }
        public void Show(Product product)
        {
            if (product.Name != null)
                Console.WriteLine("Name:" + product.Name + ", Price:" + product.Price + ", Quality:" + product.Quality + ", ID:" + product.CategoryID);
            else
                Console.WriteLine("Khong tim thay");
        }
    }
}



