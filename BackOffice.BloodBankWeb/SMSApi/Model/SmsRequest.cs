namespace SMSApi.Model
{
    public class SmsRequest
    {
        public string UserName { get; set; }
        public string Password{ get; set; }
        public string PhoneNumber { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
    }
}
