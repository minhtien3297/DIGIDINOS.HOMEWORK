using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai14Sort.Models;

namespace Bai14Sort.Controllers
{
    class Controller
    {
        public List<Product> mapProductByCategory(List<Product> productList, List<Category> categoryList)
        {
            foreach (Category category in categoryList)
            {
                foreach (Product product in productList)
                {
                    if (category.ID == product.CategoryID)
                    {
                        product.CategoryName = category.Name;
                        Console.WriteLine("Name:" + product.Name
                                    + ", Price:" + product.Price
                                    + ", Quality:" + product.Quality
                                    + ", ID:" + product.CategoryID
                                    + ", Category Name:" + product.CategoryName);
                    }
                }
            }
            return productList;
        }
    }
}
