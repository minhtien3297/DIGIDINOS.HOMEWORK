using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dd.minhtien.bai1.com.dd.minhtien.dao
{
    interface IDao
    {
        /// <summary>
        /// Them object vao database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int insert(object obj, string name);

        /// <summary>
        /// update obj vao database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int update(object obj, string name);

        /// <summary>
        /// Xoa object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Boolean delete(object obj, string name);

        /// <summary>
        /// Tra ve mang object
        /// </summary>
        /// <returns></returns>
        List<object> findAll(string name);

        /// <summary>
        /// Tim object theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object findById(int id);
    }
}
