using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;

namespace com.dd.minhtien.bai1.com.dd.minhtien.dao
{
    abstract class BaseDao
    {
        protected Database db = Database.getInstance();

        const string PRODUCT_NAME = "product";
        const string CATEGORY_NAME = "category";

        /// <summary>
        /// Them row vao database
        /// </summary>
        /// <param name="baseDao"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int insert(object baseDao, string name)
        {
            return (db.insertTable(name, baseDao));
        }

        /// <summary>
        /// update row trong database
        /// </summary>
        /// <param name="baseDao"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int update(object baseDao, string name)
        {
            return (db.updateTable(name, baseDao));
        }

        /// <summary>
        /// Xoa row trong database
        /// </summary>
        /// <param name="baseDao"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Boolean delete(object baseDao, string name)
        {
            return (db.deleteTable(name, baseDao));
        }

        /// <summary>
        /// Tim tat ca object trong mang
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<object> findAll(string name)
        {
            List<object> listBaseDao = new List<object>();

            foreach (object baseDao in db.selectTable(name))
            {
                listBaseDao.Add(baseDao);
            }

            return listBaseDao;
        }

        /// <summary>
        /// Tim object theo id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object findById(int id, string name)
        {
            object findBaseDao = new object();

            if (name == PRODUCT_NAME)
            {
                foreach (Product product in db.selectTable(name))
                {
                    if (product.Id == id)
                    {
                        findBaseDao = product;
                    }
                }

                return findBaseDao;
            }

            else if (name == CATEGORY_NAME)
            {
                foreach (Category category in db.selectTable(name))
                {
                    if (category.Id == id)
                    {
                        findBaseDao = category;
                    }
                }

                return findBaseDao;
            }

            return findBaseDao;
        }
    }
}