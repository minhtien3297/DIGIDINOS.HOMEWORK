using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class HomeController : Controller
    {
        #region Login

        /// <summary>
        /// hien thi man hinh dang nhap
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        #endregion Login

        #region Login

        /// <summary>
        /// chuc nang dang nhap
        /// </summary>
        /// <param name="objAccount"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account objAccount)
        {
            if (ModelState.IsValid)
            {
                AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                List<Account> listAccount = accountAccessLayer.Selectalldata();
                Account obj = listAccount.Where(a => a.Name.Equals(objAccount.Name) && a.PassWord.Equals(objAccount.PassWord)).FirstOrDefault();
                if (obj != null)
                {
                    Session["account"] = obj;
                    return RedirectToAction("ShowAllAccounts", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Accountname or password is wrong");

                    return View(objAccount);
                }
            }
            return View(objAccount);
        }

        #endregion Login

        #region Logout

        /// <summary>
        /// chuc nang dang xuat
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        #endregion Logout
    }
}