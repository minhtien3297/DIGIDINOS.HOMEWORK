using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai13Sort.Models;

namespace Bai13Sort.Controllers
{
    class Controller
    {
        public List<Category> selectionSortCategoryName(List<Category> categoryList)
        {
            int indexMin;

            for (int i = 0; i < categoryList.Count - 1; i++)
            {
                indexMin = i;

                for (int j = i + 1; j < categoryList.Count; j++)
                {
                    if (string.Compare(categoryList[j].Name, categoryList[indexMin].Name) == -1)
                    {
                        indexMin = j;
                    }
                }

                if (indexMin != i)
                {
                    Category temp = categoryList[indexMin];
                    categoryList[indexMin] = categoryList[i];
                    categoryList[i] = temp;
                }
            }
            return categoryList;
        }
        public List<Product> sortCategoryByName(List<Product> productList, List<Category> categoryList)
        {
            selectionSortCategoryName(categoryList);

            Product productPlaceToHole;
            int holePosition;

            for (int i = 1; i < productList.Count; i++)
            {
                productPlaceToHole = productList[i];
                holePosition = i;

                while (holePosition > 0 &&
                    string.Compare(getCategoryName(productList[holePosition - 1].CategoryID, categoryList),
                    getCategoryName(productPlaceToHole.CategoryID, categoryList)) == 1)
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
        public string getCategoryName(int categoryID, List<Category> categoryList)
        {
            foreach (Category category in categoryList)
            {
                if (category.ID == categoryID)
                {
                    return category.Name;
                }
            }
            return "";
        }
        public void Show(List<Product> productList)
        {
            foreach (Product product in productList)
            {
                Console.WriteLine("Name:" + product.Name
                                    + ", Price:" + product.Price
                                    + ", Quality:" + product.Quality
                                    + ", ID:" + product.CategoryID);
            }
        }
    }
}
