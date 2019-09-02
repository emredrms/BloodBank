using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using TweetSharp;
using TwitterApi.Model;

namespace TwitterApi.Provider
{
    public class TwitterApiRepo : ITwitterApi
    {
        KeyAccessToken keyAccessToken;
        TwitterService service;

        public TwitterApiRepo()
        {

        }

        public TwitterApiRepo(KeyAccessToken keyAccessToken)
        {
            this.keyAccessToken = keyAccessToken;
            this.service = new TwitterService(keyAccessToken.ConsumerKey, keyAccessToken.ConsumerSecret, keyAccessToken.AccessToken, keyAccessToken.AccessSecret);
        }

        public bool sendTweet(Twit twit)
        {
            if (twit != null && !string.IsNullOrEmpty(twit.Message) && twit.Message.Length <= 280)
            {
                var tweet = new SendTweetOptions { Status = twit.Message, DisplayCoordinates = true };
                TwitterStatus status = service.SendTweet(tweet);
                if (status != null)
                {
                    try
                    {
                      
                        MessageLogDTO messageLogDTO = new MessageLogDTO();
                        messageLogDTO.ReferenceNo = status.IdStr;
                        //MessageLogController.Instance.addMessageLog(messageLogDTO);
                    }
                    catch (Exception)
                    {

                    }
                    return true;
                }
                else
                {
                    MessageLogDTO messageLogDTO = new MessageLogDTO();
                    messageLogDTO.ReferenceNo = "olmadı";
                    messageLogDTO.MessageText = twit.Message;
                    messageLogDTO.Type = tweet.Status;
                    
                    //MessageLogController.Instance.addMessageLog(messageLogDTO);
                }
            }
            return false;

        }

        public void sendTwitMultiple(List<Twit> twits)
        {
            if (twits != null && twits.Count > 0)
            {
                twits.ForEach(delegate(Twit twit)
                {
                    if (twit != null && !string.IsNullOrEmpty(twit.Message) && twit.Message.Length <= 140)
                    {
                        var tweet = new SendTweetOptions { Status = twit.Message, DisplayCoordinates = true };
                        TwitterStatus status = service.SendTweet(tweet);
                    }
                });
            }
        }
    }
}
