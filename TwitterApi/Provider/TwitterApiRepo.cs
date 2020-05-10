using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
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

                        MessageLogDTO messageLogDTO = new MessageLogDTO
                        {
                            ReferenceNo = status.IdStr
                        };
                    }
                    catch (Exception)
                    {

                    }
                    return true;
                }
                else
                {
                    MessageLogDTO messageLogDTO = new MessageLogDTO
                    {
                        ReferenceNo = "olmadı",
                        MessageText = twit.Message,
                        Type = tweet.Status
                    };
                }
            }
            return false;
        }

        
        public void sendTwitMultiple(List<Twit> twits)
        {
            if (twits != null && twits.Count > 0)
            {
                twits.ForEach(delegate (Twit twit)
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
