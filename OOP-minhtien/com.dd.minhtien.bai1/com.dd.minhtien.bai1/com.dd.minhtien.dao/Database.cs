using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;

namespace com.dd.minhtien.bai1.com.dd.minhtien.dao
{
    class Database
    {
        private List<Product> productTable { get; set; }
        private List<Category> categoryTable { get; set; }
        private List<Accessory> accessoryTable { get; set; }
        private static Database Instance { get; set; }

        const string PRODUCT_NAME = "product";
        const string CATEGORY_NAME = "category";
        const string ACCESSORY_NAME = "accessory";

        /// <summary>
        /// Tao instance
        /// </summary>
        /// <returns></returns>
        public static Database getInstance()
        {
            if (Instance == null)
            {
                Instance = new Database();
            }

            return Instance;
        }

        /// <summary>
        /// Them object vao row
        /// </summary>
        /// <param name="name"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public int insertTable(string name, object row)
        {
            if (name == PRODUCT_NAME)
            {
                productTable.Add((Product)row);
            }

            else if (name == CATEGORY_NAME)
            {
                categoryTable.Add((Category)row);
            }

            else if (name == ACCESSORY_NAME)
            {
                accessoryTable.Add((Accessory)row);
            }

            return 1;
        }

        /// <summary>
        /// Tra ra list theo name
        /// </summary>
        /// <param name="name"></param>
        public List<object> selectTable(string name)
        {
            List<object> list = new List<object>();

            if (name == PRODUCT_NAME)
            {
                list.AddRange(productTable);

                return list;
            }

            else if (name == CATEGORY_NAME)
            {
                list.AddRange(categoryTable);

                return list;
            }

            else if (name == ACCESSORY_NAME)
            {
                list.AddRange(accessoryTable);

                return list;
            }

            return list;
        }

        /// <summary>
        /// Update row truyen vao theo name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public int updateTable(string name, object row)
        {
            if (name == PRODUCT_NAME)
            {
                Product rowProduct = (Product)row;

                foreach (Product product in productTable)
                {
                    if (product.Id == rowProduct.Id)
                    {
                        product.Name = rowProduct.Name;
                        product.CategoryId = rowProduct.CategoryId;
                    }
                }

                return 1;
            }

            else if (name == CATEGORY_NAME)
            {
                Category rowCategory = (Category)row;

                foreach (Category category in categoryTable)
                {
                    if (category.Id == rowCategory.Id)
                    {
                        category.Name = rowCategory.Name;
                    }
                }

                return 1;
            }

            return 0;
        }

        /// <summary>
        /// update row truyen vao theo id va name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public int updateTable(int id, string name, object row)
        {
            if (name == PRODUCT_NAME)
            {
                Product rowProduct = new Product();

                foreach (Product product in productTable)
                {
                    if (product.Id == rowProduct.Id)
                    {
                        product.Name = rowProduct.Name;
                        product.CategoryId = rowProduct.CategoryId;
                    }
                }

                return 1;
            }

            else if (name == CATEGORY_NAME)
            {
                Category rowCategory = new Category();

                foreach (Category category in categoryTable)
                {
                    if (category.Id == rowCategory.Id)
                    {
                        category.Name = rowCategory.Name;
                    }
                }

                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Xoa row theo id va name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public Boolean deleteTable(string name, object row)
        {
            if (name == PRODUCT_NAME)
            {
                Product rowProduct = (Product)row;

                foreach (Product product in productTable)
                {
                    if (product.Id == rowProduct.Id)
                    {
                        productTable.Remove(product);
                    }
                }

                return true;
            }

            else if (name == CATEGORY_NAME)
            {
                Category rowCategory = (Category)row;

                foreach (Category category in categoryTable)
                {
                    if (category.Id == rowCategory.Id)
                    {
                        categoryTable.Remove(category);
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Xoa toan bo mang trong database
        /// </summary>
        /// <param name="name"></param>
        public void truncateTable(string name)
        {
            if (name == PRODUCT_NAME)
            {
                productTable.Clear();
            }

            else if (name == CATEGORY_NAME)
            {
                categoryTable.Clear();
            }

            else if (name == ACCESSORY_NAME)
            {
                accessoryTable.Clear();
            }
        }
    }
}