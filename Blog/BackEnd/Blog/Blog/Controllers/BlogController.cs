using Blog.DataAccessLayer;
using System.Net;

using System.Web;

using System.Web.Http.ModelBinding;

using Blog.DataAccessLayer;

using System.Web.Http;
using System.Net.Http;
using System;

namespace Blog.Controllers
{
    public class BlogController : ApiController
    {
        #region Create Blog

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateBlog(Blog blog)
        {
            if (/*ModelState.IsValid &&*/ blog != null)
            {
                BlogAccessLayer objDB = new BlogAccessLayer();
                var result = objDB.InsertData(blog);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Create Blog

        #region Get All Blog

        /// <summary>
        /// Get All Blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllBlog()
        {
            Blog blog = new Blog();
            BlogAccessLayer objDB = new BlogAccessLayer();
            blog.ShowAllBlog = objDB.Selectalldata();

            return Request.CreateResponse(HttpStatusCode.OK, blog.ShowAllBlog);
        }

        #endregion Get All Blog

        #region Get Blog By ID

        /// <summary>
        /// Get Blog By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBlogByID(int id)
        {
            Blog blog = new Blog();
            BlogAccessLayer objDB = new BlogAccessLayer();
            blog = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }

        #endregion Get Blog By ID

        #region Edit Blog

        /// <summary>
        /// Edit Blog
        /// </summary>
        ///
        /// <param name="Blog"></param>
        ///
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditBlog(Blog blog)
        {
            if (ModelState.IsValid && blog != null)
            {
                BlogAccessLayer objDB = new BlogAccessLayer();
                var result = objDB.UpdateData(blog);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Edit Blog

        #region Delete Blog

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteBlog(int id)
        {
            BlogAccessLayer objDB = new BlogAccessLayer();
            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        #endregion Delete Blog

        // phần search chưa thống nhất, chưa làm
    }
}