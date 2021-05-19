using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.entity
{
    interface IEntity
    {
        string getName();
        string setName(string name);
        int getId();
        int setId(int id);
    }
}
