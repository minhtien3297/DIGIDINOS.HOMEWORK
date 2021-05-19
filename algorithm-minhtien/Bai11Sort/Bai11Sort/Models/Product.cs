using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai11Sort.Models
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
        public List<Product> sortByPrice(List<Product> productList)
        {
            for (int i = 0; i < productList.Count - 1; i++)
            {
                for (int j = 0; j < productList.Count - 1 - i; j++)
                {
                    if (productList[j].Price > productList[j + 1].Price)
                    {
                        int temp = productList[j].Price;
                        productList[j].Price = productList[j + 1].Price;
                        productList[j + 1].Price = temp;
                    }
                }
            }
            return productList;
        }
        public void Show(List<Product> productList)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                Console.Write(" " + productList[i].Price);
            }
        }
    }
}

