using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai12Sort.Models
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
        public List<Product> sortByName(List<Product> productList)
        {
            Product productPlaceToHole;
            int holePosition;

            for (int i = 1; i < productList.Count; i++)
            {
                productPlaceToHole = productList[i];
                holePosition = i;

                while (holePosition > 0 && productList[holePosition - 1].Name.Length < productPlaceToHole.Name.Length)
                {
                    productList[holePosition] = productList[holePosition - 1];
                    holePosition--;
                }
                if (holePosition != i)
                {
                    productList[holePosition] = productPlaceToHole;
                }
            }

            return productList;
        }
        public void Show(List<Product> productList)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                Console.Write(" " + productList[i].Name);
            }
        }
    }
}
