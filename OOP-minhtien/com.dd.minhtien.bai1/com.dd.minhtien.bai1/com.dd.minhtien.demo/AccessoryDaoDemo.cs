using com.dd.minhtien.bai1.com.dd.minhtien.dao;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.demo
{
    class AccessoryDaoDemo
    {
        AccessoryDAO AD = new AccessoryDAO();
        const string ACCESSORY_NAME = "accessory";

        public void insertTest(Accessory accessory)
        {
            AD.insert(accessory, ACCESSORY_NAME);
        }

        public void updateTest(Accessory accessory)
        {
            AD.update(accessory, ACCESSORY_NAME);
        }

        public void deleteTest(Accessory accessory)
        {
            AD.delete(accessory, ACCESSORY_NAME);
        }

        public void findAllTest()
        {
            AD.findAll(ACCESSORY_NAME);
        }

        public void findByIdTest(int id)
        {
            AD.findById(id);
        }

        public void findByNameTest(string name)
        {
            AD.findByName(name);
        }
    }
}
