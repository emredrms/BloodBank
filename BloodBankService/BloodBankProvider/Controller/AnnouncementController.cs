using BloodBankData;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBankProvider.Controller
{
    public class AnnouncementController
    {
        private static readonly AnnouncementController _instance = new AnnouncementController();

        public static AnnouncementController Instance
        {
            get
            {
                return _instance;
            }
        }

        public int addAnnouncement(AnnouncementDTO announcementDTO)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                Announcement ann = new Announcement();
                ann.Text = announcementDTO.Text;
                ann.ContactIds = announcementDTO.ContactIds;
                ann.CreateDate = DateTime.Now;
                ann.Active = false;
                conn.Announcement.Add(ann);
                conn.SaveChanges();

                return ann.AnnouncementId;
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public void updateAnnouncement(AnnouncementDTO announcement)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                Announcement ann = conn.Announcement.Find(announcement.AnnouncementId);
                if (!string.IsNullOrEmpty(announcement.ContactIds))
                    ann.ContactIds = announcement.ContactIds;
                if (!string.IsNullOrEmpty(announcement.Text))
                    ann.Text = announcement.Text;
                ann.Active = announcement.Valid;
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public void updateAnnouncementText(int id, string text, bool singleText)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                Announcement ann = conn.Announcement.Find(id);
                if (singleText)
                {
                    ann.Text = text;
                }
                else {
                    ann.Text = text + " " + ann.Text;
                }
                ann.Active = true;
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public List<AnnouncementDTO> retrievePendingAnnouncementMessage()
        {
            List<AnnouncementDTO> pendingAnnouncementMessage = new List<AnnouncementDTO>();

            try
            {
                DateTime maxDay = DateTime.Today.AddDays(-3);
                var announcementList = Repository.dbConnection.Announcement.Where(a => a.CreateDate > maxDay && a.Active).ToList();

                announcementList.ForEach(delegate (Announcement announcementItem)
                {
                    pendingAnnouncementMessage.Add(new AnnouncementDTO
                    {
                        AnnouncementId = announcementItem.AnnouncementId,
                        ContactIds = announcementItem.ContactIds,
                        CreateDate = announcementItem.CreateDate,
                        Messages = mapCollectionToListForMessage(announcementItem.Message),
                        Text = announcementItem.Text,

                    });
                });
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return pendingAnnouncementMessage;
        }

        public static List<MessageDTO> mapCollectionToListForMessage(ICollection<Message> message)
        {
            List<MessageDTO> messages = new List<MessageDTO>();

            if (message != null)
            {
                message.ToList().ForEach(delegate (Message messageItem)
                {
                    messages.Add(new MessageDTO
                    {
                        MessageId = messageItem.MessageId,
                        ContactIds = messageItem.ContactIds,
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
