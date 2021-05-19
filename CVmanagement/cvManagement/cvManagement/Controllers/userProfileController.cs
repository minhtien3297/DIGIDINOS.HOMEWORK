using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class UserProfileController : Controller
    {
        /// <summary>
        /// Hien thi man hinh insert Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InsertUserProfile()
        {
            PositionLayer positionLayer = new PositionLayer();
            SourceLayer sourceLayer = new SourceLayer();
            UserProfile userprofile = new UserProfile();
            userprofile.listPosition = positionLayer.Selectalldata();
            userprofile.listSource = sourceLayer.Selectalldata();
            return View(userprofile);
        }

        /// <summary>
        /// Insert Profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InsertUserProfile(UserProfile pro, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                UserProfileLayer upl = new UserProfileLayer();
                string result = upl.InsertData(pro);
                TempData["InsertResult"] = result;
                ModelState.Clear();

                return RedirectToAction("ListUserProfile");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return RedirectToAction("InsertUserProfile");
            }
        }

        /// <summary>
        /// Hien thi man hinh update Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult UpdateUserProfile(string id)
        {
            UserProfileLayer userprofilelayer = new UserProfileLayer();
            PositionLayer positionLayer = new PositionLayer();
            SourceLayer sourceLayer = new SourceLayer();
            UserProfile userprofile = new UserProfile();
            userprofile = userprofilelayer.SelectDatabyID(id);
            userprofile.listPosition = positionLayer.Selectalldata();
            userprofile.listSource = sourceLayer.Selectalldata();

            return View(userprofile);
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateUserProfile(UserProfile pro)
        {
            if (ModelState.IsValid)
            {
                UserProfileLayer upl = new UserProfileLayer();
                string result = upl.UpdateData(pro);
                TempData["UpdateResult"] = result;
                ModelState.Clear();

                return RedirectToAction("ListUserProfile");
            }
            else
            {
                ModelState.AddModelError("", "Error in updating data");
                return RedirectToAction("UpdateUserProfile");
            }
        }

        /// <summary>
        /// Hien thi man hinh List Profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListUserProfile()
        {
            UserProfile userProfile = new UserProfile();
            UserProfileLayer userProfileLayer = new UserProfileLayer();
            SourceLayer sourceLayer = new SourceLayer();
            PositionLayer positionLayer = new PositionLayer();
            userProfile.listPosition = positionLayer.Selectalldata();
            userProfile.listSource = sourceLayer.Selectalldata();
            userProfile.ListProfile = userProfileLayer.Selectalldata();

            return View(userProfile);
        }
    }
}