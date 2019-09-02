using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Model;

namespace TwitterApi.Provider
{
    public interface ITwitterApi
    {
        bool sendTweet(Twit twit);
        void sendTwitMultiple(List<Twit> twits);
    }
}
