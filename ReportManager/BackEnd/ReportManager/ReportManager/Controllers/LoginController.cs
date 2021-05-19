using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class LoginController : ApiController
    {
        #region Get User Info

        /// <summary>
        /// Get User Info
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("api/user")]
        public HttpResponseMessage GetUserInfo()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Request.CreateResponse(HttpStatusCode.OK, identity.Name);
        }

        #endregion Get User Info
    }
}