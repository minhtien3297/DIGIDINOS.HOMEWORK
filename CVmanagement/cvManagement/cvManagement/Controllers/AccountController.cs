using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class AccountController : Controller
    {
        #region ShowAllAccounts

        /// <summary>
        /// Hien thi toan bo account
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult ShowAllAccounts()
        {
            Account account = new Account();
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
            account.listAccount = accountAccessLayer.Selectalldata();
            account.account = (Account)Session["account"];

            return View(account);
        }

        #endregion ShowAllAccounts

        #region Delete

        /// <summary>
        /// Chuc nang xoa account
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns value="ActionResult"></returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
            int result = accountAccessLayer.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllAccounts");
        }

        #endregion Delete

        #region updatePassword

        /// <summary>
        /// chuyen sang man hinh update mat khau
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>Quay sang man hinh update mat khau</returns>
        [HttpGet]
        public ActionResult updatePassword(string id)
        {
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();

            return View(accountAccessLayer.SelectDataById(id));
        }

        #endregion updatePassword

        #region updatePassword

        /// <summary>
        /// cap nhat mat khau
        /// </summary>
        /// <param name="account"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult updatePassword(Account account, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                string oldpassword = form["oldpassword"];
                string newpasswordAgain = form["newpasswordagain"];
                string newpassword = form["newpassword"];
                if (oldpassword == "" || newpasswordAgain == "" || newpassword == "")
                {
                    ModelState.AddModelError("", "oldpassword, new password again or new password is null");

                    return View(account);
                }
                else
                {
                    if (account.PassWord == oldpassword && newpasswordAgain == newpassword)
                    {
                        Account updatedAccount = new Account
                        {
                            Id = account.Id,
                            Name = account.Name,
                            PassWord = newpassword,
                            Role = account.Role
                        };
                        string result = accountAccessLayer.Updatedata(updatedAccount);
                        TempData["UpdateResult"] = result;
                        ModelState.Clear();

                        return RedirectToAction("ShowAllAccounts");
                    }
                    else if (account.PassWord != oldpassword)
                    {
                        ModelState.AddModelError("", "your oldpassword is false");

                        return View(account);
                    }
                    else if (newpasswordAgain != newpassword)
                    {
                        ModelState.AddModelError("", "your newpasswordagain is not equal to newpassword");

                        return View(account);
                    }
                    return View(account);
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in updating data");

                return View();
            }
        }

        #endregion updatePassword

        #region createAccount

        /// <summary>
        /// hien thi man hinh them Account
        /// </summary>
        /// <param></param>
        /// <returns>hien thi man hinh them account</returns>
        [HttpGet]
        public ActionResult createAccount()
        {
            return View();
        }

        #endregion createAccount

        #region createAccount

        /// <summary>
        /// chuc nang them account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult createAccount(Account account, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                string password = form["password1"];
                string passwordAgain = form["passwordAgain"];
                if (password == "" || passwordAgain == "")
                {
                    ModelState.AddModelError("", "Your password or password again is null");

                    return View();
                }
                else
                {
                    if (password == passwordAgain)
                    {
                        account.PassWord = password;
                        string result = accountAccessLayer.Insertdata(account);
                        TempData["InsertResult"] = result;
                        ModelState.Clear();

                        return RedirectToAction("ShowAllAccounts");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your password is not equal to passwordAgain");

                        return View();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data to table");

                return View();
            }
        }

        #endregion createAccount

        #region editAccount

        /// <summary>
        /// hien thi man hinh sua Account
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns>hien thi man hinh sua account</returns>
        [HttpGet]
        public ActionResult editAccount(string id)
        {
            AccountAccessLayer accountAccessLayer = new AccountAccessLayer();

            return View(accountAccessLayer.SelectDataById(id));
        }

        #endregion editAccount

        #region editAccount

        /// <summary>
        /// Chuc nang sua account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult editAccount(Account account, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                AccountAccessLayer accountAccessLayer = new AccountAccessLayer();
                string password = form["oldpassword"];
                int id = account.Id;
                if (password == "")
                {
                    ModelState.AddModelError("", "Your password is null");

                    return View(account);
                }
                else
                {
                    if (password == account.PassWord)
                    {
                        Account updatedAccount = new Account
                        {
                            Id = account.Id,
                            Name = account.Name,
                            PassWord = password,
                            Role = account.Role
                        };
                        string result = accountAccessLayer.Updatedata(updatedAccount);
                        TempData["UpdateResult"] = result;
                        ModelState.Clear();

                        return RedirectToAction("ShowAllAccounts");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Your password is not true");

                        return View(account);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in updating data");

                return View(account);
            }
        }

        #endregion editAccount
    }
}