using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.dao
{
    class AccessoryDAO : IDao
    {
        Database db = Database.getInstance();
        const string ACCESSORY_NAME = "accessory";

        /// <summary>
        /// Tim accessory theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object findById(int id)
        {
            Accessory findAccessory = new Accessory();

            foreach (Accessory accessory in db.selectTable(ACCESSORY_NAME))
            {
                if (accessory.ID == findAccessory.ID)
                {
                    findAccessory = accessory;
                }

                else
                    throw new NotImplementedException("Id khong tim thay");
            }

            return findAccessory;
        }

        /// <summary>
        /// Tim accessory theo name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object findByName(string name)
        {
            Accessory findAccessory = new Accessory();

            foreach (Accessory accessory in db.selectTable(name))
            {
                if (findAccessory.ID == accessory.ID)
                {
                    findAccessory = accessory;
                }
            }

            return findAccessory;
        }

        /// <summary>
        /// Them object vao database
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int insert(object obj, string name)
        {
            if (name == ACCESSORY_NAME)
            {
                return db.insertTable(name, obj);
            }
            throw new NotImplementedException("Ten khong hop le");
        }

        /// <summary>
        /// update object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int update(object obj, string name)
        {
            if (name == ACCESSORY_NAME)
            {
                return db.updateTable(name, obj);
            }
            throw new NotImplementedException("Ten khong hop le");
        }

        /// <summary>
        /// Xoa object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool delete(object obj, string name)
        {
            if (name == ACCESSORY_NAME)
            {
                return db.deleteTable(name, obj);
            }
            throw new NotImplementedException("Ten khong hop le");
        }

        /// <summary>
        /// Tra lai mang theo name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<object> findAll(string name)
        {
            if (name == ACCESSORY_NAME)
            {
                List<object> listBaseDao = new List<object>();

                foreach (object baseDao in db.selectTable(name))
                {
                    listBaseDao.Add(baseDao);
                }

                return listBaseDao;
            }
            throw new NotImplementedException("Ten khong hop le");
        }
    }
}
