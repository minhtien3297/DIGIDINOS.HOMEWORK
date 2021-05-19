using ReportManager.DataAccess;
using ReportManager.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class ReportController : ApiController
    {
        #region Create Report

        /// <summary>
        /// Create Report
        /// </summary>
        /// <param name="reports"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateReport(Reports reports)
        {
            if (ModelState.IsValid && reports != null)
            {
                ReportAccessLayer objDB = new ReportAccessLayer();
                var result = objDB.InsertData(reports);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Create Report

        #region Get All Report

        /// <summary>
        /// Get All Report
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllReport()
        {
            Reports report = new Reports();
            ReportAccessLayer objDB = new ReportAccessLayer();
            report.ShowAllReport = objDB.Selectalldata();

            return Request.CreateResponse(HttpStatusCode.OK, report.ShowAllReport);
        }

        #endregion Get All Report

        #region Get Report By ID

        /// <summary>
        /// Get Report By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetReportByID(int id)
        {
            Reports report = new Reports();
            ReportAccessLayer objDB = new ReportAccessLayer();
            report = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, report);
        }

        #endregion Get Report By ID

        #region Edit Report

        /// <summary>
        /// Edit Report
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditReport(Reports report)
        {
            report.Dates = Convert.ToDateTime(report.Dates);
            if (ModelState.IsValid && report != null)
            {
                ReportAccessLayer objDB = new ReportAccessLayer();
                var result = objDB.UpdateData(report);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Edit Report

        #region Delete Report

        /// <summary>
        /// Delete Report
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteReport(int id)
        {
            ReportAccessLayer objDB = new ReportAccessLayer();
            CommentsAccessLayer cmtDB = new CommentsAccessLayer();

            List<Comments> Comments = cmtDB.SelectDataByReportID(id);
            Comments.ForEach(comment => cmtDB.DeleteData(comment.ID));

            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        #endregion Delete Report

        #region Search Report

        /// <summary>
        /// Search By SearchString
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SearchBySearchString(string done, string date, string account_name, string teams_name)
        {
            string Done = null;
            string Date = null;
            string Account_Name = null;
            string Teams_Name = null;

            Reports report = new Reports();
            ReportAccessLayer objDB = new ReportAccessLayer();

            if (!string.IsNullOrEmpty(done))
            {
                Done = done.Trim().ToLower();
            }
            if (!string.IsNullOrEmpty(date))
            {
                Date = date.Trim().ToLower();
            }
            if (!string.IsNullOrEmpty(account_name))
            {
                Account_Name = account_name.Trim().ToLower();
            }
            if (!string.IsNullOrEmpty(teams_name))
            {
                Teams_Name = teams_name.Trim().ToLower();
            }

            report.ShowAllReport = objDB.SearchBySearchString(Done, Date, Account_Name, Teams_Name);

            return Request.CreateResponse(HttpStatusCode.OK, report.ShowAllReport);
        }

        #endregion Search Report
    }
}