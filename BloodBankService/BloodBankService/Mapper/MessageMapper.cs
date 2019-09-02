using BloodBankProvider.Controller;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Mapper
{
    public class MessageMapper
    {
        private static readonly MessageMapper _instance = new MessageMapper();

        public static MessageMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Message> mapRetrievePendingApprovalMessage()
        {
            List<Message> messages = new List<Message>();

            MessageController.Instance.retrievePendingApprovalMessage().ForEach(delegate(MessageDTO messageDtoItem)
            {
                messages.Add(new Message
                {
                    MessageId = messageDtoItem.MessageId,
                    MessageText = messageDtoItem.MessageText,
                    Channel = messageDtoItem.Channel
                });
            });

            return messages;
        }

        public RetrieveMessageByAnnouncementResponse mapretrieveMessageByAnnouncementId(int announcementId)
        {
            RetrieveMessageByAnnouncementResponse retrieveMessageByAnnouncementResponse = new RetrieveMessageByAnnouncementResponse();
            List<Message> messages = new List<Message>();

            MessageController.Instance.retrieveMessageByAnnouncementId(announcementId).ForEach(delegate(MessageDTO messageDtoItem)
            {
                messages.Add(new Message
                {
                    MessageId = messageDtoItem.MessageId,
                    ContectIds = messageDtoItem.ContactIds,
                    AuthUser =messageDtoItem.AuthUser,
                    Channel = messageDtoItem.Channel,
                    MessageText = messageDtoItem.MessageText,
                    Active = messageDtoItem.Active,
                    Approve = messageDtoItem.Approve,
                    Send = messageDtoItem.Send
                });
            });

            retrieveMessageByAnnouncementResponse.messages = messages;
            retrieveMessageByAnnouncementResponse.TotalCount = messages.Count;

            return retrieveMessageByAnnouncementResponse;
        }

        public void addMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead)
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

            announcement.AnnouncementId = announcementId != null ? Convert.ToInt32(announcementId) : 0;
            message.Announcement = announcement;
            message.ContactIds = contactIds;
            message.MessageText = messageText;
            message.AuthUser = authUser;

            MessageController.Instance.addMessageByChannel(message,channelList);

        }
    }
}