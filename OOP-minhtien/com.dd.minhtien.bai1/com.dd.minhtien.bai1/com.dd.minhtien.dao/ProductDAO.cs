using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.dao
{
    class ProductDAO : BaseDao
    {
        /// <summary>
        /// Tim product theo name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object findByName(string name)
        {
            Product findProduct = new Product();

            foreach (Product product in db.selectTable(name))
            {
                if (findProduct.Name == product.Name)
                {
                    findProduct = product;
                }
            }

            return findProduct;
        }
    }
}
