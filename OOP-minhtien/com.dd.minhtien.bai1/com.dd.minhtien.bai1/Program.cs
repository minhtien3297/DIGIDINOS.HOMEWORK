using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dd.minhtien.bai1.com.dd.minhtien.demo;
using com.dd.minhtien.bai1.com.dd.minhtien.entity;

namespace com.dd.minhtien.bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DatabaseDemo DD = new DatabaseDemo();
            //DD.initDatabase();
            //DD.printTableTest();

            AccessoryDaoDemo CDD = new AccessoryDaoDemo();
            Accessory accessory = new Accessory(1, "accessory");
            CDD.insertTest(accessory);
            CDD.findAllTest();
            CDD.findByNameTest("accessory");

            Console.ReadKey();
        }
    }
}
