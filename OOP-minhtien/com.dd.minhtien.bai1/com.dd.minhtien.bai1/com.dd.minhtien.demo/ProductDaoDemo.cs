using com.dd.minhtien.bai1.com.dd.minhtien.dao;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.demo
{
    class ProductDaoDemo
    {
        ProductDAO PD = new ProductDAO();
        const string PRODUCT_NAME = "product";

        public void insertTest(Product product)
        {
            PD.insert(product, PRODUCT_NAME);
        }

        public void updateTest(Product product)
        {
            PD.update(product, PRODUCT_NAME);
        }

        public void deleteTest(Product product)
        {
            PD.delete(product, PRODUCT_NAME);
        }

        public void findAllTest()
        {
            PD.findAll(PRODUCT_NAME);
        }

        public void findByIdTest(int id)
        {
            PD.findById(id);
        }

        public void findByNameTest(string name)
        {
            PD.findByName(name);
        }
    }
}
