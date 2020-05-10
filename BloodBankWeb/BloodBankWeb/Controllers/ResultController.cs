using BloodBankProvider.Controller;
using BloodBankWeb.Models;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BloodBankWeb.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        public ActionResult Index()
        {
            SearchModel searchModel = new SearchModel();
            AnnouncementModel model = new AnnouncementModel();
            if (Session["result"] != null)
            {
                searchModel = (SearchModel)Session["result"];
                TempData["ResulCount"] = searchModel.ResultCount;
                model.AnnouncementId = searchModel.AnnouncementId;
                model.BloodGroup = searchModel.BloodGroup;
            }
            return View(model);
        }

        public ActionResult UpdateAnnouncement(AnnouncementModel model)
        {
            model.Text = model.Hospital + " Hastanesi'ndeki " + model.PatientName + " için " + model.BloodGroup.Replace("+", " pozitif").Replace("-", " negatif") + " kana ihtiyaç var. " + model.Name + " -  " + model.Phone.Replace("-", "").Replace("(", "").Replace(")", "");

            AnnouncementController.Instance.updateAnnouncementText(model.AnnouncementId, model.Text, false);

            return PartialView("_PAnnouncementInfo");
        }

    }
}
