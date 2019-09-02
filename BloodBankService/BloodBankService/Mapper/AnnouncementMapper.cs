using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Mapper
{
    public class AnnouncementMapper
    {
        private static readonly AnnouncementMapper _instance = new AnnouncementMapper();

        public static AnnouncementMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public RetrievePendingApprovalAnnouncementResponse mapRetrievePendingApprovalAnnouncement()
        {
            RetrievePendingApprovalAnnouncementResponse retrievePendingApprovalMessageResponse = new RetrievePendingApprovalAnnouncementResponse();
            List<Announcement> announcementList = new List<Announcement>();

            AnnouncementController.Instance.retrievePendingAnnouncementMessage().ForEach(delegate(AnnouncementDTO announcementDtoItem)
            {
                announcementList.Add(new Announcement
                {
                    AnnouncementId = announcementDtoItem.AnnouncementId,
                    ContactIds = announcementDtoItem.ContactIds,
                    CreateDate = announcementDtoItem.CreateDate,
                    Messages = mapMessageDTOToMessageForMessage(announcementDtoItem.Messages),
                    Text = announcementDtoItem.Text,
                    Valid = announcementDtoItem.Valid,
                    Facebook = true,
                    Twitter = true,
                    Phone = true,
                    Lead = true

                });
            });

            retrievePendingApprovalMessageResponse.Announcements = announcementList;
            retrievePendingApprovalMessageResponse.TotalCount = announcementList.Count;

            return retrievePendingApprovalMessageResponse;
        }

        public static List<Message> mapMessageDTOToMessageForMessage(List<MessageDTO> message)
        {
            List<Message> messages = new List<Message>();

            if (message != null)
            {
                message.ToList().ForEach(delegate(MessageDTO messageItem)
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