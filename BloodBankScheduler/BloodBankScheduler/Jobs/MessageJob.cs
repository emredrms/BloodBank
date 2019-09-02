using BloodBankProvider.Controller;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using BloodBankScheduler.Constant;
using Quartz;
using TwitterApi.Model;
using TwitterApi.Provider;

namespace BloodBankScheduler.Jobs
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
        }

        private void sendApprovalTwitterMessage()
        {
            var messages = MessageController.Instance.retrievePendingApprovalMessageByChannel(BloodBankConstant.TWITTER_CHANNEL);
            Twit twit = null;
            bool sendMessage = false;

            if (messages != null && messages.Count > 0)
            {
                messages.ForEach(delegate(MessageDTO messageItem)
                {
                    if (!string.IsNullOrEmpty(messageItem.MessageText))
                    {
                        twit = new Twit();
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
    }
}