using MesajPaneli.Business;
using MesajPaneli.Models;
using MesajPaneli.Models.JsonPostModels;
using SMSApi.Model;

namespace SMSApi
{
    public class SmsProvider
    {
        public SmsResponse postMessage(SmsRequest request)
        {
            SmsResponse smsResponse = new SmsResponse();

            smsData data = new smsData();
            data.user = new UserInfo(request.UserName, request.Password);
            data.msgBaslik = request.Caption;
            data.msgData.Add(new msgdata(request.PhoneNumber.Trim(), request.Text.Trim()));

            ReturnValue returnData = data.DoPost("http://api.mesajpaneli.com/json_api/", true, true);
            smsResponse.Status = returnData.status;
            if (returnData.status)
            {
                smsResponse.Ref = returnData.Ref;
                smsResponse.Amount = returnData.amount;
                smsResponse.Type = returnData.type;
                smsResponse.ReturnMessageText = "TRUE";
            }
            else
            {
                smsResponse.ReturnMessageText = returnData.error;
            }
            
            return smsResponse;
        }
    }
}
