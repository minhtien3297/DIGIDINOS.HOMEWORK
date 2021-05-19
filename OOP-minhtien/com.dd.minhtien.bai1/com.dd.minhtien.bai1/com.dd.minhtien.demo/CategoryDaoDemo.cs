using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dd.minhtien.bai1.com.dd.minhtien.dao;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;

namespace com.dd.minhtien.bai1.com.dd.minhtien.demo
{
    class CategoryDaoDemo
    {
        CategoryDAO CD = new CategoryDAO();
        const string CATEGORY_NAME = "category";

        public void insertTest(Category category)
        {
            CD.insert(category, CATEGORY_NAME);
        }

        public void updateTest(Category category)
        {
            CD.update(category, CATEGORY_NAME);
        }

        public void deleteTest(Category category)
        {
            CD.delete(category, CATEGORY_NAME);
        }

        public void findAllTest()
        {
            CD.findAll(CATEGORY_NAME);
        }

        public void findByIDTest(int id)
        {
            CD.findById(id);
        }
    }
}
