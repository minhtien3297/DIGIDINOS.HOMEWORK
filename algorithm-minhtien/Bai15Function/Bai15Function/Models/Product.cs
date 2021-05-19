using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai15Function.Models
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
        public Product minByPrice(List<Product> productList)
        {
            Product productMin = productList[0];
            foreach (Product product in productList)
            {
                if(productMin.Price > product.Price)
                {
                    productMin = product;
                }
            }
            return productMin;
        }
        public void Show(Product product)
        {
            Console.WriteLine("Name:" + product.Name + ", Price:" + product.Price + ", Quality:" + product.Quality + ", ID:" + product.CategoryID);
        }
    }
}
