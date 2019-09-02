using BackOffice.BloodBankWeb.Constant;
using BloodBankProvider.Controller;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using Quartz;
using SMSApi;
using SMSApi.Model;
using System;
using TwitterApi.Model;
using TwitterApi.Provider;


namespace BackOffice.BloodBankWeb.Jobs
{
    public class MessageJob : IJob
    {
        private KeyAccessToken token;
        private TwitterApiRepo repo;

        public MessageJob()
        {
            token = new KeyAccessToken();
            token.ConsumerKey = TwitterConstant.ConsumerKey;
            token.ConsumerSecret = TwitterConstant.ConsumerSecret;
            token.AccessToken = TwitterConstant.AccessToken;
            token.AccessSecret = TwitterConstant.AccessSecret;
            repo = new TwitterApiRepo(token);
        }

        public void Execute(IJobExecutionContext context)
        {
            sendApprovalTwitterMessage();
            sendApprovalPhoneMessage();
        }

        private void sendApprovalTwitterMessage()
        {
            var messages = MessageController.Instance.retrievePendingApprovedMessageByChannel(BloodBankConstant.TWITTER_CHANNEL);
            Twit twit = null;
            bool sendMessage = false;

            if (messages != null && messages.Count > 0)
            {
                messages.ForEach(delegate (MessageDTO messageItem)
                {
                    if (!string.IsNullOrEmpty(messageItem.MessageText))
                    {
                        twit = new Twit();
                        twit.Message = messageItem.MessageText;
                        sendMessage = repo.sendTweet(twit);
                        if (sendMessage)
                        {
                            messageItem.Send = true;
                            messageItem.Active = true;
                            messageItem.Approve = true;
                            MessageController.Instance.updateMessage(messageItem);

                        }
                    }

                });
            }

        }

        private void sendApprovalPhoneMessage()
        {
            var messages = MessageController.Instance.retrievePendingApprovedMessageByChannel(BloodBankConstant.PHONE_CHANNEL);
            string[] contactIds = null;
            SmsRequest request = null;
            SmsResponse response = null;
            SmsProvider smsProvider = null;
            if (messages != null && messages.Count > 0)
            {
                messages.ForEach(delegate (MessageDTO messageItem)
                {
                    if (!string.IsNullOrEmpty(messageItem.MessageText) && !string.IsNullOrEmpty(messageItem.ContactIds) && "null" != messageItem.ContactIds.Trim())
                    {
                        contactIds = messageItem.ContactIds.Split('-');
                        for (int i = 0; i < contactIds.Length; i++)
                        {
                            ContactDTO contactDto = ContactController.Instance.getContact(Convert.ToInt32(contactIds[i]));
                            if (!string.IsNullOrEmpty(contactDto.Phone))
                            {
                                smsProvider = new SmsProvider();
                                request = new SmsRequest();
                                request.Caption = SmsConstant.Caption;
                                request.UserName = SmsConstant.Username;
                                request.Password = SmsConstant.Password;
                                request.PhoneNumber = contactDto.Phone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Trim();
                                request.Text = messageItem.MessageText;
                                response = smsProvider.postMessage(request);
                                if(response != null && response.Status)
                                {
                                    messageItem.Send = true;
                                    messageItem.Active = true;
                                    messageItem.Approve = true;
                                    MessageController.Instance.updateMessage(messageItem);

                                    MessageLogDTO messageLogDTO = new MessageLogDTO();
                                    messageLogDTO.Credits = response.Credits;
                                    messageLogDTO.MessageText = response.ReturnMessageText;
                                    messageLogDTO.Phone = request.PhoneNumber;
                                    messageLogDTO.ReferenceNo = response.Ref;
                                    messageLogDTO.Type = response.Type;
                                    messageLogDTO.UsedAmount = response.Amount;
                                    MessageLogController.Instance.addMessageLog(messageLogDTO);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageController.Instance.doPassiveMessage(messageItem);
                    }

                });
            }
        }


    }
}