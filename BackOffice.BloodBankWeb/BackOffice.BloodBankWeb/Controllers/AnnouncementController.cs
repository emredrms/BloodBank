using BackOffice.BloodBankWeb.Filters;
using BackOffice.BloodBankWeb.Models;
using BloodBankProvider.Controller;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class AnnouncementController : Controller
    {
        //
        // GET: /Announcement/

        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RetrievePendingApprovalAnnouncement(int? AnnouncementId)
        {
            List<AnnouncementModel> announcementList = new List<AnnouncementModel>();
            RetrievePendingApprovalAnnouncementResponse announcementResponse = new RetrievePendingApprovalAnnouncementResponse();
            if (AnnouncementId == null)
            {
                BloodBankProvider.Controller.AnnouncementController.Instance.retrievePendingAnnouncementMessage().ForEach(delegate (AnnouncementDTO announcementDtoItem)
                 {
                     announcementList.Add(new AnnouncementModel
                     {
                         AnnouncementId = announcementDtoItem.AnnouncementId,
                         ContactIds = announcementDtoItem.ContactIds,
                         CreateDate = announcementDtoItem.CreateDate,
                         StrCreateDate = announcementDtoItem.CreateDate.ToString(),
                         Messages = mapMessageDTOToMessageForMessage(announcementDtoItem.Messages),
                         Text = announcementDtoItem.Text,
                         Valid = announcementDtoItem.Valid,
                         Facebook = true,
                         Twitter = true,
                         Phone = true,
                         Lead = true

                     });
                 });

                announcementResponse.Announcements = announcementList.OrderByDescending(a => a.CreateDate).ToList();
                announcementResponse.TotalCount = announcementList.Count();
            }
            else
            {
               // sendApprovalPhoneMessage();
            }

            return Json(announcementResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RetrieveMessageByAnnouncementId(string announcementId)
        {
            List<Message> messages = new List<Message>();
            RetrieveMessageByAnnouncementResponse retrieveMessageByAnnouncementResponse = new RetrieveMessageByAnnouncementResponse();
            if (!string.IsNullOrEmpty(announcementId))
            {
                BloodBankProvider.Controller.MessageController.Instance.retrieveMessageByAnnouncementId(Convert.ToInt32(announcementId)).ForEach(delegate (MessageDTO messageDtoItem)
                {
                    messages.Add(new Message
                    {
                        MessageId = messageDtoItem.MessageId,
                        ContectIds = messageDtoItem.ContactIds,
                        AuthUser = messageDtoItem.AuthUser,
                        Channel = messageDtoItem.Channel,
                        MessageText = messageDtoItem.MessageText,
                        Active = messageDtoItem.Active,
                        Approve = messageDtoItem.Approve,
                        Send = messageDtoItem.Send
                    });
                });
            }

            retrieveMessageByAnnouncementResponse.messages = messages;
            retrieveMessageByAnnouncementResponse.TotalCount = messages.Count();
            return Json(retrieveMessageByAnnouncementResponse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead)
        {
            List<string> channelList = new List<string>();
            MessageDTO message = new MessageDTO();
            AnnouncementDTO announcement = new AnnouncementDTO();

            if (!string.IsNullOrEmpty(facebook) && facebook.Equals("true"))
                channelList.Add(BloodBankConstant.FACEBOOK_CHANNEL);
            if (!string.IsNullOrEmpty(twitter) && twitter.Equals("true"))
                channelList.Add(BloodBankConstant.TWITTER_CHANNEL);
            if (!string.IsNullOrEmpty(phone) && phone.Equals("true"))
                channelList.Add(BloodBankConstant.PHONE_CHANNEL);
            if (!string.IsNullOrEmpty(lead) && lead.Equals("true"))
                message.Lead = true;

            announcement.AnnouncementId = announcementId != null ? Convert.ToInt32(announcementId) : 0;
            message.Announcement = announcement;
            message.ContactIds = contactIds;
            message.MessageText = messageText.Replace("pozitif","(+)").Replace("negatif","(-)");
            message.AuthUser = authUser;

            MessageController.Instance.addMessageByChannel(message, channelList);

            return RedirectToAction("RetrievePendingApprovalAnnouncement", new { AnnouncementId = 5 });
        }

        public static List<Message> mapMessageDTOToMessageForMessage(List<MessageDTO> message)
        {
            List<Message> messages = new List<Message>();

            if (message != null)
            {
                message.ToList().ForEach(delegate (MessageDTO messageItem)
                {
                    messages.Add(new Message
                    {
                        MessageId = messageItem.MessageId,
                        ContectIds = messageItem.ContactIds,
                        MessageText = messageItem.MessageText,
                        AuthUser = messageItem.AuthUser,
                        Channel = messageItem.Channel,
                        Active = messageItem.Active,
                        Approve = messageItem.Approve,
                        Send = messageItem.Send
                    });
                });
            }

            return messages;
        }

    }
}
