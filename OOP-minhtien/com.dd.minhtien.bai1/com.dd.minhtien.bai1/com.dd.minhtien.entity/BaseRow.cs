using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.entity
{
    public abstract class BaseRow
    {
        public string Name;
        public int Id;
        public int categoryId;

        public BaseRow(int id, string name, int categoryId) : this(id, name)
        {
            this.categoryId = categoryId;
        }

        protected BaseRow()
        { }
        protected BaseRow(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
