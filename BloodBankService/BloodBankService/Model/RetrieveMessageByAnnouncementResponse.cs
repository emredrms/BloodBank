using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Model
{
    public class RetrieveMessageByAnnouncementResponse
    {
        public List<Message> messages { get; set; }
        public int TotalCount { get; set; }
    }
}