using BackOffice.BloodBankWeb.Filters;
using System;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetContentById(string contentId)
        {
            if (!string.IsNullOrEmpty(contentId))
            {
                var content = BloodBankProvider.Controller.ContentController.Instance.getContentById(Convert.ToInt32(contentId));

                return Json(content.Content, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("");
            }
        }

        
        [ValidateInput(false)]
        public ActionResult UpdateContent(string contentId, string content)
        {
            BloodBankProvider.Controller.ContentController.Instance.updateContentById(Convert.ToInt32(contentId), content);
            return Content("ok");
        }

     }
}
