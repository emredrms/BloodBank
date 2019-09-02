using BloodBankData;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBankProvider.Controller
{
    public class MentionTwitterController
    {
        private static readonly MentionTwitterController _instance = new MentionTwitterController();

        public static MentionTwitterController Instance
        {
            get
            {
                return _instance;
            }
        }

        public void addMentionTwitter(MentionTwitterDTO mentionTwitterDTO)
        {
            try
            {  
                Blood_Bank_Entities conn = Repository.dbConnection;
                if (!conn.MentionTwitter.Any(m => m.Account == mentionTwitterDTO.Account))
                {
                    MentionTwitter mentionTwitter = new MentionTwitter();
                    mentionTwitter.Account = mentionTwitterDTO.Account;
                    mentionTwitter.UsedCount = 0;
                    mentionTwitter.Valid = true;
                    conn.MentionTwitter.Add(mentionTwitter);
                    conn.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void updateMentionTwitter(MentionTwitterDTO mentionTwitterDTO)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                MentionTwitter mentionTwitter = conn.MentionTwitter.Find(mentionTwitterDTO.Id);
                if (!string.IsNullOrEmpty(mentionTwitterDTO.Account))
                    mentionTwitter.Account = mentionTwitterDTO.Account;
                if (mentionTwitterDTO.UsedCount > 0)
                    mentionTwitter.UsedCount = mentionTwitterDTO.UsedCount;
                mentionTwitter.Valid = mentionTwitterDTO.Valid;
                conn.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void increaseUsedCount(int id)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                MentionTwitter mentionTwitter = conn.MentionTwitter.Find(id);
                mentionTwitter.UsedCount = mentionTwitter.UsedCount + 1;
                conn.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void deleteMentionTwitter(int id)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                MentionTwitter mentionTwitter = conn.MentionTwitter.Find(id);
                conn.MentionTwitter.Remove(mentionTwitter);
                conn.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void doPassiveAll()
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                var mentions = conn.MentionTwitter.ToList();
                foreach (var item in mentions)
                {
                    item.Valid = false;
                }
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MentionTwitterDTO> retrieveMentionList()
        {
            try
            {
                List<MentionTwitterDTO> mentionList = new List<MentionTwitterDTO>();
                var mentions = Repository.dbConnection.MentionTwitter.ToList();

                foreach (var item in mentions)
                {
                    mentionList.Add(new MentionTwitterDTO
                    {
                        Id = item.Id,
                        Account = item.Account,
                        UsedCount = item.UsedCount,
                        Valid = item.Valid
                    });

                }

                return mentionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MentionTwitterDTO> retrieveMentionList(bool status)
        {
            try
            {
                List<MentionTwitterDTO> mentionList = new List<MentionTwitterDTO>();
                var mentions = Repository.dbConnection.MentionTwitter.Where(m => m.Valid == status).ToList();

                if (mentions != null && mentions.Count > 0)
                {
                    foreach (var item in mentions)
                    {
                        mentionList.Add(new MentionTwitterDTO
                        {
                            Id = item.Id,
                            Account = item.Account,
                            UsedCount = item.UsedCount,
                            Valid = item.Valid
                        });

                    }
                }

                return mentionList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
