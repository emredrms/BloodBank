using BloodBankWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BloodBankWeb.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/


        public ActionResult Index(string name)
        {
            ContentModel model = new ContentModel();

            Dictionary<string, int> contentMap = ContentModel.getContentDictionary();
            if (contentMap.ContainsKey(name))
            {
                var content = BloodBankProvider.Controller.ContentController.Instance.getContentById(contentMap[name]);
                model = new ContentModel();
                model.ContentId = content.ContentId;
                model.Content = content.Content;
                model.ContentTypeCode = content.ContentTypeCode;
                model.Title = content.Title;
            }

            return View(model);
        }

    }
}
