using ReportManager.DataAccess;
using ReportManager.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class TeamController : ApiController
    {
        #region Create Team

        /// <summary>
        /// Create Team
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateTeam(Teams teams)
        {
            if (ModelState.IsValid && teams != null)
            {
                TeamAccessLayer objDB = new TeamAccessLayer();
                var result = objDB.InsertData(teams);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Create Team

        #region Get All Team

        /// <summary>
        /// Get All Team
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetAllTeam()
        {
            Teams team = new Teams();
            TeamAccessLayer objDB = new TeamAccessLayer();
            team.ShowAllTeam = objDB.Selectalldata();

            return Request.CreateResponse(HttpStatusCode.OK, team.ShowAllTeam);
        }

        #endregion Get All Team

        #region Get Team By ID

        /// <summary>
        /// Get Team By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTeamByID(int id)
        {
            Teams team = new Teams();
            TeamAccessLayer objDB = new TeamAccessLayer();
            team = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, team);
        }

        #endregion Get Team By ID

        #region Edit Team

        /// <summary>
        /// Edit Team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage EditTeam(Teams team)
        {
            if (ModelState.IsValid && team != null)
            {
                TeamAccessLayer objDB = new TeamAccessLayer();
                var result = objDB.UpdateData(team);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Edit Team

        #region Delete Team

        /// <summary>
        /// Delete Team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTeam(int id)
        {
            TeamAccessLayer objDB = new TeamAccessLayer();
            AccountsAccessLayer accDB = new AccountsAccessLayer();

            List<Accounts> Accounts = accDB.SelectAllDataByTeamID(id);
            Accounts.ForEach(account => accDB.DeleteData(account.ID));

            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        #endregion Delete Team

        #region Search Team

        /// <summary>
        /// Search By Done
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage SearchByName(string name)
        {
            string searchString = null;
            Teams team = new Teams();
            TeamAccessLayer objDB = new TeamAccessLayer();

            if (!string.IsNullOrEmpty(name))
            {
                searchString = name.Trim().ToLower();
            }
            team.ShowAllTeam = objDB.SearchByTitle(searchString);

            return Request.CreateResponse(HttpStatusCode.OK, team.ShowAllTeam);
        }

        #endregion Search Team
    }
}