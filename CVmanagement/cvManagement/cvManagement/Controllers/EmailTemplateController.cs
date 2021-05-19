using cvManagement.DataAccessLayer;
using cvManagement.Models;
using System.Web.Mvc;

namespace cvManagement.Controllers
{
    public class EmailTemplateController : Controller
    {
        #region ShowAllTemplates

        /// <summary>
        /// Hien thi toan bo Template
        /// </summary>
        /// <returns value="ActionResult">View()</returns>
        [HttpGet]
        public ActionResult ShowAllTemplates()
        {
            EmailTemplate objTemplate = new EmailTemplate();
            EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
            objTemplate.listTemplate = emailTemplateLayer.Selectalldata();

            return View(objTemplate);
        }

        #endregion ShowAllTemplates

        #region Delete

        /// <summary>
        /// Chuc nang xoa template
        /// </summary>
        /// <param name="id" value="string"></param>
        /// <returns value="ActionResult"></returns>
        [HttpGet]
        public ActionResult Delete(string id)
        {
            EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
            int result = emailTemplateLayer.DeleteData(id);
            TempData["DeleteResult"] = result;
            ModelState.Clear();

            return RedirectToAction("ShowAllTemplates");
        }

        #endregion Delete

        #region createTemplate

        /// <summary>
        /// hien thi man sua template
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult createTemplate()
        {
            return View();
        }

        #endregion createTemplate

        #region createTemplate

        /// <summary>
        /// tao moi template
        /// </summary>
        /// <param name="emailtemplate"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult createTemplate(EmailTemplate emailtemplate)
        {
            if (ModelState.IsValid)
            {
                EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
                string result = emailTemplateLayer.Insertdata(emailtemplate);
                TempData["InsertResult"] = result;
                ModelState.Clear();

                return RedirectToAction("ShowAllTemplates");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data to table");

                return View();
            }
        }

        #endregion createTemplate

        #region editTemplate

        /// <summary>
        /// hien thi man sua template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult editTemplate(string id)
        {
            EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();

            return View(emailTemplateLayer.SelectDataById(id));
        }

        #endregion editTemplate

        #region editTemplate

        /// <summary>
        /// sua template
        /// </summary>
        /// <param name="emailtemplate"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult editTemplate(EmailTemplate emailtemplate)
        {
            if (ModelState.IsValid)
            {
                EmailTemplateAccessLayer emailTemplateLayer = new EmailTemplateAccessLayer();
                string result = emailTemplateLayer.Updatedata(emailtemplate);
                TempData["UpdateResult"] = result;
                ModelState.Clear();

                return RedirectToAction("ShowAllTemplates");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data to table");

                return View();
            }
        }

        #endregion editTemplate
    }
}