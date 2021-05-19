using ReportManager.DataAccess;
using ReportManager.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class AccountController : ApiController
    {
        #region Create Account

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateAccount(Accounts account)
        {
            if (ModelState.IsValid && account != null)
            {
                AccountsAccessLayer objDB = new AccountsAccessLayer();
                var result = objDB.InsertData(account);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Create Account

        #region Get All Account

        /// <summary>
        /// Get All Account
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllAccount()
        {
            Accounts account = new Accounts();
            AccountsAccessLayer objDB = new AccountsAccessLayer();
            account.ShowAllAccount = objDB.Selectalldata();

            return Request.CreateResponse(HttpStatusCode.OK, account.ShowAllAccount);
        }

        #endregion Get All Account

        #region Get Account By ID

        /// <summary>
        /// Get Account By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAccountByID(int id)
        {
            Accounts account = new Accounts();
            AccountsAccessLayer objDB = new AccountsAccessLayer();
            account = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, account);
        }

        #endregion Get Account By ID

        #region Edit Account

        /// <summary>
        /// Edit Account
        /// </summary>
        ///
        /// <param name="account"></param>
        ///
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditAccount(Accounts account)
        {
            if (ModelState.IsValid && account != null)
            {
                AccountsAccessLayer objDB = new AccountsAccessLayer();
                var result = objDB.UpdateData(account);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Edit Account

        #region Delete Account

        /// <summary>
        /// Delete Account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteAccount(int id)
        {
            AccountsAccessLayer objDB = new AccountsAccessLayer();
            ReportAccessLayer rpDb = new ReportAccessLayer();

            List<Reports> Reports = rpDb.SelectDatabyAccountID(id);
            Reports.ForEach(report => rpDb.DeleteData(report.ID));

            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        #endregion Delete Account

        #region Search Account

        /// <summary>
        /// Search By Done
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SearchByUsername(string username)
        {
            string searchString = null;
            Accounts accounts = new Accounts();
            AccountsAccessLayer objDB = new AccountsAccessLayer();

            if (!string.IsNullOrEmpty(username))
            {
                searchString = username.Trim().ToLower();
            }
            accounts.ShowAllAccount = objDB.SearchByUsername(searchString);

            return Request.CreateResponse(HttpStatusCode.OK, accounts.ShowAllAccount);
        }

        #endregion Search Account
    }
}