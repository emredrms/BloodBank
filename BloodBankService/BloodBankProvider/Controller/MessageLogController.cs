using BloodBankData;
using BloodBankProvider.Model;
using System;

namespace BloodBankProvider.Controller
{
    public class MessageLogController
    {
        private static readonly MessageLogController _instance = new MessageLogController();

        public static MessageLogController Instance
        {
            get
            {
                return _instance;
            }
        }

        public void addMessageLog(MessageLogDTO messageLogDTO)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                MessageLog messageLog = new MessageLog();
                messageLog.ReferenceNo = messageLogDTO.ReferenceNo;
                messageLog.MessageText = messageLogDTO.MessageText;
                messageLog.UsedAmount = messageLogDTO.UsedAmount;
                messageLog.Type = messageLogDTO.Type;
                messageLog.Credits = messageLogDTO.Credits;
                messageLog.Phone = messageLogDTO.Phone;
                conn.MessageLog.Add(messageLog);
                conn.SaveChanges();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
