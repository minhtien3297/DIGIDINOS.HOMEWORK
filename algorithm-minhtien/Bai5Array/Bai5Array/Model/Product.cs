using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai5Array.Model
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
        public List<Product> findProductByCategory(List<Product> productList, int categoryid)
        {
            List<Product> productListSorted = new List<Product>();
            foreach (Product product in productList)
            {
                if (categoryid == product.CategoryID)
                    productListSorted.Add(product);
            }
            return productListSorted;
        }
        public void Show(List<Product> productList)
        {
            if (productList.Count != 0)
                foreach (Product product in productList)
                {
                    Console.WriteLine("Name:" + product.Name + ", Price:" + product.Price + ", Quality:" + product.Quality + ", ID:" + product.CategoryID);

                }
            else
                Console.WriteLine("Khong tim thay");
        }
    }
}
