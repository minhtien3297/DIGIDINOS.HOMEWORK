using BlogManager.DataAccess;
using BlogManager.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace BlogManager.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlogController : ApiController
    {
        #region Create Blog
        /// <summary>
        /// Create Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateBlog(Blog blog)
        {
            //blog.DatePublic = Convert.ToDateTime(blog.DatePublic);
            if (ModelState.IsValid && blog != null)
            {
                DataAccessLayer objDB = new DataAccessLayer();
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
        #endregion

        #region Get All Blog
        /// <summary>
        /// Get All Blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllBlog()
        {
            Blog blog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer();
            blog.ShowallBlogs = objDB.Selectalldata();

            return Request.CreateResponse(HttpStatusCode.OK, blog.ShowallBlogs);
        }
        #endregion

        #region Get Blog By ID
        /// <summary>
        /// Get Blog By ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetBlogByID(int id)
        {
            Blog blog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer();
            blog = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }
        #endregion

        #region Edit Blog
        /// <summary>
        /// Edit Blog
        /// </summary>
        /// <param name="objCustomer"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditBlog(Blog blog)
        {
            blog.DatePublic = Convert.ToDateTime(blog.DatePublic);
            if (ModelState.IsValid && blog != null)
            {
                DataAccessLayer objDB = new DataAccessLayer();
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
        #endregion

        #region Delete Blog
        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteBlog(int id)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Fail");
        }
        #endregion

        #region Search Blog
        /// <summary>
        /// Search By Title
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SearchByTitle(string title)
        {
            string searchString = null;
            Blog blog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer();

            if (!string.IsNullOrEmpty(title))
            {
                searchString = title.Trim().ToLower();
            }
            blog.ShowallBlogs = objDB.SearchByTitle(searchString);

            return Request.CreateResponse(HttpStatusCode.OK, blog.ShowallBlogs);
        }
        #endregion
    }
}
