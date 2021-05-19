using ReportManager.DataAccess;
using ReportManager.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class CommentController : ApiController
    {
        #region Create Comment

        /// <summary>
        /// Create Comment
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateComment(Comments comments)
        {
            if (ModelState.IsValid && comments != null)
            {
                CommentsAccessLayer objDB = new CommentsAccessLayer();
                var result = objDB.InsertData(comments);
                ModelState.Clear();

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");

                return Request.CreateResponse(HttpStatusCode.OK, "Fail");
            }
        }

        #endregion Create Comment

        #region Get Comment By ID

        /// <summary>
        /// Get Comment By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetCommentByID(int id)
        {
            Comments comment = new Comments();
            CommentsAccessLayer objDB = new CommentsAccessLayer();
            comment.ShowAllCmt = objDB.SelectDatabyID(id);

            return Request.CreateResponse(HttpStatusCode.OK, comment.ShowAllCmt);
        }

        #endregion Get Comment By ID

        #region Delete Comment

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteComment(int id)
        {
            CommentsAccessLayer objDB = new CommentsAccessLayer();
            objDB.DeleteData(id);

            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        #endregion Delete Comment
    }
}