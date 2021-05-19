using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.entity
{
    public class Product : BaseRow
    {
        public int CategoryId;

        public Product() : base()
        { }
        public Product(int id, string name, int categoryId) : base(id, name, categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }
    }
}
