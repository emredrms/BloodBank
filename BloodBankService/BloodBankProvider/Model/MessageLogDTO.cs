namespace BloodBankProvider.Model
{
    public class MessageLogDTO
    {
        public int MessageLogID { get; set; }
        public string ReferenceNo { get; set; }
        public string MessageText { get; set; }
        public string UsedAmount { get; set; }
        public string Type { get; set; }
        public string Credits { get; set; }
        public string Phone { get; set; }
    }
}
