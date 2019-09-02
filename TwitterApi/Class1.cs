using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;
using TwitterApi.Model;
using TwitterApi.Provider;

namespace TwitterApi
{
    public class Class1
    {
        static void Main(string[] args)
        {
            TwitterService service = new TwitterService("7sVu6owPg7EytYfBagqJYE9Gx", "HtzeDKshMl6LqW7lbKsMZfnMMNF4tlk5xeo7BmcpT91zobJ4dc", "186576310-MzhauOAcMXKOi0AyxFlLpSA8uCsGeaZYHzVpgus0", "Y1hSqOP0fq22cvqi5y7LQtgqg4zT4Cn3EHdFyjDAEMToY");
            var twit = new SendTweetOptions { Status = "test", DisplayCoordinates = true };
            TwitterStatus status = service.SendTweet(twit);
            Console.ReadLine();

           
        }
    }
}
