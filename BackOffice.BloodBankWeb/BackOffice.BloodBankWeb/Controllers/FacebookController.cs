using BackOffice.BloodBankWeb.Constant;
using BloodBankProvider.Controller;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using Facebook;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class FacebookController : Controller
    {
        //
        // GET: /Facebook/

        public ActionResult Index()

        {
            if (Request.QueryString["code"] == null)
            {
                Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    FacebookConstant.AppId,
                    FacebookConstant.Url,
                    FacebookConstant.Scope));

            }
            else
            {

                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    FacebookConstant.AppId,
                    FacebookConstant.Url,
                    FacebookConstant.Scope,
                    Request.QueryString["code"],
                    FacebookConstant.AppSecret);

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string vals = reader.ReadToEnd();

                    foreach (string token in vals.Split('&'))
                    {
                        tokens.Add(token.Substring(0, token.IndexOf("=")),
                            token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                    }
                }

                string access_token = tokens["access_token"];

                List<MessageDTO> messages = MessageController.Instance.retrievePendingApprovedMessageByChannel(BloodBankConstant.FACEBOOK_CHANNEL);
                if (messages != null && messages.Count > 0)
                {
                    dynamic result;
                    var client = new FacebookClient(access_token);
                    foreach (var messageItem in messages)
                    {
                        result = client.Post("me/feed", new { message = messageItem.MessageText });
                        result = client.Post(FacebookConstant.Page_Id + "/feed", new { message = messageItem.MessageText });
                        //result = client.Post(FacebookConstant.Group_Id + "/feed", new { message = messageItem.MessageText });
                        if (result != null)
                        {
                            messageItem.Send = true;
                            messageItem.Active = true;
                            messageItem.Approve = true;
                            MessageController.Instance.updateMessage(messageItem);
                        }
                    }

                }

            }
            return View();
        }


    }
}
