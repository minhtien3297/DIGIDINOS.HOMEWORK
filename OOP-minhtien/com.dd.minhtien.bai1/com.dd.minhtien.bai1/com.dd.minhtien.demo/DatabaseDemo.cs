using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using com.dd.minhtien.bai1.com.dd.minhtien.dao;

namespace com.dd.minhtien.bai1.com.dd.minhtien.demo
{
    class DatabaseDemo
    {
        Database db = new Database();

        public void insertTableTest(string name, object row)
        {
            db.insertTable(name, row);
        }

        public void selectTableTest(string name)
        {
            db.selectTable(name);
        }

        public void updateTableTest(string name, object row)
        {
            db.updateTable(name, row);
        }

        public void updateTableTest(int id, string name, object row)
        {
            db.updateTable(id, name, row);
        }

        public void deleteTableTest(string name, object row)
        {
            db.deleteTable(name, row);
        }

        public void truncateTableTest(string name)
        {
            db.truncateTable(name);
        }

        public void initDatabase()
        {
            for (int i = 1; i <= 10; i++)
            {
                Product product = new Product();
                product.Id = i;
                product.Name = "tien" + i;
                product.CategoryId = i;

                Category category = new Category();
                category.Id = i;
                category.Name = "minh" + i;

                Accessory accessory = new Accessory();
                accessory.Id = i;
                accessory.Name = "dao" + i;

                insertTableTest("product", product);
                insertTableTest("category", category);
                insertTableTest("accessory", accessory);
            }
        }

        public void printTableTest()
        {
            Console.WriteLine("Mang product: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(db.productTable[i].Name);
            }

            Console.WriteLine("Mang category: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(db.categoryTable[i].Name);
            }

            Console.WriteLine("Mang accessory: ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(db.accessoryTable[i].Name);
            }

        }
    }
}
