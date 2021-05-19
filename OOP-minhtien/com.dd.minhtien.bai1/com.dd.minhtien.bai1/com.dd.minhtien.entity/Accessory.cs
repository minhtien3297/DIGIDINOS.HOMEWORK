using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.entity
{
    public class Accessory : IEntity
    {
        public int ID;
        public string Name;
        public int getId()
        {
            return ID;

            throw new NotImplementedException("Khong lay duoc id");
        }

        public string getName()
        {
            return Name;

            throw new NotImplementedException("Khong lay duoc name");
        }

        public int setId(int id)
        {
            ID = id;

            throw new NotImplementedException("Khong gan duoc id");
        }

        public string setName(string name)
        {
            Name = name;

            throw new NotImplementedException("Khong gan duoc ten");
        }

        public Accessory()
        { }
        public Accessory(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
