using DemoWebAPI.Models;
using DemoWebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebAPI.Controllers
{
    public class HomeController : Controller
    {
        IComments Icom;

        public HomeController()

        {

            Icom = new Comments();

        }

        [HttpGet]

        public ActionResult InsertComment()

        {

            return View(new Comment());

        }

    }
}

