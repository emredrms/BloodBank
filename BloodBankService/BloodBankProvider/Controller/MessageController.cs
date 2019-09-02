using BloodBankData;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Controller
{
    public class MessageController
    {
        private static readonly MessageController _instance = new MessageController();

        public static MessageController Instance
        {
            get
            {
                return _instance;
            }
        }

        public int addMessage(MessageDTO message)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                Message mes = new Message();
                mes.ContactIds = message.ContactIds;
                mes.MessageText = String.IsNullOrEmpty(message.MessageText) ? null : message.MessageText.Trim();
                mes.Active = message.Active;
                mes.Approve = message.Approve;
                mes.Send = message.Send;
                conn.Message.Add(mes);
                conn.SaveChanges();
                return mes.MessageId;
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public void addMessageByChannel(MessageDTO message, List<string> chanells)
        {
            try
            {
                if (chanells != null && chanells.Count > 0)
                {
                    Blood_Bank_Entities conn = Repository.dbConnection;
                    Message mes = null;
                    List<MentionTwitterDTO> mentions = MentionTwitterController.Instance.retrieveMentionList(true);

                    chanells.ForEach(delegate (string chanellItem)
                    {
                        if (chanellItem.Equals(BloodBankConstant.TWITTER_CHANNEL))
                        {
                            mes = new Message();
                            mes.AnnouncementId = message.Announcement.AnnouncementId;
                            mes.ContactIds = message.ContactIds;
                            mes.MessageText = message.MessageText;
                            mes.AuthUser = message.AuthUser;
                            mes.Channel = chanellItem;
                            mes.Active = true;
                            mes.Approve = true;
                            mes.Send = false;
                            conn.Message.Add(mes);

                            foreach (var item in mentions)
                            {
                                mes = new Message();
                                mes.AnnouncementId = message.Announcement.AnnouncementId;
                                mes.ContactIds = message.ContactIds;
                                mes.MessageText = message.MessageText + " " + item.Account;
                                mes.AuthUser = message.AuthUser;
                                mes.Channel = chanellItem;
                                mes.Active = true;
                                mes.Approve = true;
                                mes.Send = false;
                                conn.Message.Add(mes);

                                MentionTwitterController.Instance.increaseUsedCount(item.Id);
                            }
                        }
                        else
                        {
                            mes = new Message();
                            mes.AnnouncementId = message.Announcement.AnnouncementId;
                            mes.ContactIds = message.ContactIds;
                            mes.MessageText = message.MessageText;
                            mes.AuthUser = message.AuthUser;
                            mes.Channel = chanellItem;
                            mes.Active = true;
                            mes.Approve = true;
                            mes.Send = false;
                            conn.Message.Add(mes);
                        }
                    });

                    conn.SaveChanges();
                }
                if (message.Lead)
                {
                    message.MessageText = message.MessageText.Replace("(+)", "pozitif").Replace("(-)", "negatif");
                    AnnouncementController.Instance.updateAnnouncementText(message.Announcement.AnnouncementId, message.MessageText,true);
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public void updateMessage(MessageDTO message)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                Message mess = conn.Message.Find(message.MessageId);
                if (!string.IsNullOrEmpty(message.ContactIds))
                    mess.ContactIds = message.ContactIds;
                if (!string.IsNullOrEmpty(message.MessageText))
                    mess.MessageText = message.MessageText;
                mess.Active = message.Active;
                mess.Approve = message.Approve;
                mess.Send = message.Send;
                conn.SaveChanges();

            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public List<MessageDTO> retrievePendingApprovalMessage()
        {

            List<MessageDTO> pendingApprovelMessage = new List<MessageDTO>();

            try
            {
                var messageList = Repository.dbConnection.Message.Where(m => m.Approve == false && m.Send == false && m.Active).ToList();

                messageList.ForEach(delegate (Message messageItem)
                {
                    pendingApprovelMessage.Add(new MessageDTO
                    {
                        MessageId = messageItem.MessageId,
                        MessageText = messageItem.MessageText,
                        Channel = messageItem.Channel
                    });
                });
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return pendingApprovelMessage;
        }

        public List<MessageDTO> retrievePendingApprovalMessageByChannel(string channel)
        {

            List<MessageDTO> pendingApprovelMessage = new List<MessageDTO>();

            try
            {
                var messageList = Repository.dbConnection.Message.Where(m => m.Approve == false && m.Send == false && m.Active && m.Channel == channel).ToList();

                messageList.ForEach(delegate (Message messageItem)
                {
                    pendingApprovelMessage.Add(new MessageDTO
                    {
                        MessageId = messageItem.MessageId,
                        MessageText = messageItem.MessageText,
                        Channel = messageItem.Channel
                    });
                });
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return pendingApprovelMessage;
        }

        public List<MessageDTO> retrievePendingApprovedMessageByChannel(string channel)
        {

            List<MessageDTO> pendingApprovelMessage = new List<MessageDTO>();

            try
            {
                var messageList = Repository.dbConnection.Message.Where(m => m.Approve && m.Send == false && m.Active && m.Channel == channel).ToList();

                messageList.ForEach(delegate (Message messageItem)
                {
                    pendingApprovelMessage.Add(new MessageDTO
                    {
                        MessageId = messageItem.MessageId,
                        MessageText = messageItem.MessageText,
                        Channel = messageItem.Channel,
                        ContactIds = messageItem.ContactIds,
                        Announcement = map(messageItem.Announcement)
                    });
                });
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return pendingApprovelMessage;
        }

        public List<MessageDTO> retrieveMessageByAnnouncementId(int announcementId)
        {
            List<MessageDTO> messages = new List<MessageDTO>();

            try
            {
                var messageList = Repository.dbConnection.Message.Where(m => m.AnnouncementId == announcementId && m.Active).ToList();
                if (messageList != null)
                {
                    messageList.ForEach(delegate (Message messageItem)
                    {
                        messages.Add(new MessageDTO
                        {
                            MessageId = messageItem.MessageId,
                            ContactIds = messageItem.ContactIds,
                            AuthUser = messageItem.AuthUser,
                            MessageText = messageItem.MessageText,
                            Channel = getChannelText(messageItem.Channel),
                            Active = messageItem.Active,
                            Approve = messageItem.Send,
                            Send = messageItem.Send
                        });
                    });
                }

            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return messages;
        }

        public void doPassiveMessage(MessageDTO messageDto)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                var message = conn.Message.Find(messageDto.MessageId);
                message.Active = false;
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

        }

        public static string getChannelText(string channel)
        {
            if (!string.IsNullOrEmpty(channel))
            {
                if (channel.Equals(BloodBankConstant.FACEBOOK_CHANNEL))
                    return "Facebook";
                else if (channel.Equals(BloodBankConstant.TWITTER_CHANNEL))
                    return "Twitter";
                else if (channel.Equals(BloodBankConstant.PHONE_CHANNEL))
                    return "Telefon";
            }

            return "";
        }

        private static AnnouncementDTO map(Announcement announcement)
        {
            AnnouncementDTO announcementDTO = new AnnouncementDTO();
            announcementDTO.AnnouncementId = announcement.AnnouncementId;
            announcementDTO.ContactIds = announcement.ContactIds;
            announcementDTO.CreateDate = announcement.CreateDate;
            announcementDTO.Text = announcement.Text;
            announcementDTO.Valid = announcement.Active;

            return announcementDTO;
        }
    }
}
