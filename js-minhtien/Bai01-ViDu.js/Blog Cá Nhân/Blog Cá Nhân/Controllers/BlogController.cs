using BlogManager.App_Common.DataAccess;
using BlogManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogManager.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// Hien thi seach blog
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchBlog()
        {
            Blog blog = new Blog();
            DataAccessLayer dal = new DataAccessLayer();
            blog.ShowAllBlog = dal.Selectalldata();

            return View(blog);
        }

        /// <summary>
        /// Hien thi phan search theo data nhap vao
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SearchDataByName(string ID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            Blog blog = new Blog
            {
                ShowAllBlog = dal.SearchDataByName(ID)
            };

            return View(blog);
        }

        /// <summary>
        /// Hien thi man hinh them Blog
        /// </summary>
        /// <returns>Views/EditBlog</returns>
        [HttpGet]
        public ActionResult NewsEditBlog(string ID)
        {
            if (ID != null)
            {
                DataAccessLayer objDB = new DataAccessLayer();

                return View(objDB.SelectDatabyID(ID));
            }
            else
            {
                Blog blog = new Blog
                {
                    BlogID = 0
                };

                return View(blog);
            }
        }

        /// <summary>
        /// Them Blog moi
        /// </summary>
        /// <param name="objBlog"></param>
        /// <returns>BLog Data</returns>
        [HttpPost]
        public ActionResult NewsEditBlog(Blog blog)
        {
            if (blog.BlogID == 0)
            {
                if (ModelState.IsValid)
                {
                    DataAccessLayer objDB = new DataAccessLayer();
                    string result = objDB.InsertData(blog);
                    TempData["result1"] = result;
                    ModelState.Clear();

                    return RedirectToAction("ListBlogs");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");

                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    DataAccessLayer objDB = new DataAccessLayer();
                    string result = objDB.UpdateData(blog);
                    TempData["result2"] = result;
                    ModelState.Clear();

                    return RedirectToAction("ListBlogs");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");

                    return View();
                }
            }
        }

        /// <summary>
        /// Lay du lieu List Blog
        /// </summary>
        /// <returns>Views/ListBlogs</returns>
        [HttpGet]
        public ActionResult ListBlogs()
        {
            Blog blog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer();
            blog.ShowAllBlog = objDB.Selectalldata();

            return View("~/Views/Blog/ListBlogs.cshtml", blog);
        }

        /// <summary>
        /// Xoa blog theo id truyen vao
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear();

            return RedirectToAction("ListBlogs");
        }
    }
}