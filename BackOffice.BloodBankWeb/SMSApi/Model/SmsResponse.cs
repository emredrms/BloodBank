namespace SMSApi.Model
{
    public class SmsResponse
    {
        public string Ref { get; set; }
        public string ReturnMessageText { get; set; }
        public string Amount { get; set; }
        public string Type { get; set; }
        public string Credits { get; set; }
        public bool Status { get; set; }
    }
}
