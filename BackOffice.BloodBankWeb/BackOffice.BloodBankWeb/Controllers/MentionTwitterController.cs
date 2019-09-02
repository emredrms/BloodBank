using BackOffice.BloodBankWeb.Filters;
using BackOffice.BloodBankWeb.Models;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class MentionTwitterController : Controller
    {
        //
        // GET: /MentionTwitter/
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RetrieveMentionTwitter()
        {
            List<MentionTwitter> twitterAccounList = new List<MentionTwitter>();
            BloodBankProvider.Controller.MentionTwitterController.Instance.retrieveMentionList().ForEach(delegate (MentionTwitterDTO mentionTwitterDTO) {
                twitterAccounList.Add(new MentionTwitter
                {
                    Id = mentionTwitterDTO.Id,
                    Account = mentionTwitterDTO.Account,
                    UsedCount = mentionTwitterDTO.UsedCount,
                    Valid = mentionTwitterDTO.Valid
                });
            });

            return Json(twitterAccounList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateMentionList(string ids, string newAccounts)
        {
            string[] mentionIds =ids.Split('-');
            string[] newAccountArr = null;
            MentionTwitterDTO mentionTwitterDTO = null;
            
            BloodBankProvider.Controller.MentionTwitterController.Instance.doPassiveAll();

            for (int i = 0; i < mentionIds.Length; i++)
            {
                if(mentionIds[i] != "0") {
                    mentionTwitterDTO = new MentionTwitterDTO();
                    mentionTwitterDTO.Id = Convert.ToInt32(mentionIds[i]);
                    mentionTwitterDTO.Valid = true;
                    BloodBankProvider.Controller.MentionTwitterController.Instance.updateMentionTwitter(mentionTwitterDTO);
                }
            }
            if (!string.IsNullOrEmpty(newAccounts))
            {
                newAccountArr = newAccounts.Split('-');
                for (int i = 0; i < newAccountArr.Length; i++)
                {
                    mentionTwitterDTO = new MentionTwitterDTO();
                    mentionTwitterDTO.Account = newAccountArr[i];
                    BloodBankProvider.Controller.MentionTwitterController.Instance.addMentionTwitter(mentionTwitterDTO);
                }
            }

            return Content("ok");
        }

    }
}
