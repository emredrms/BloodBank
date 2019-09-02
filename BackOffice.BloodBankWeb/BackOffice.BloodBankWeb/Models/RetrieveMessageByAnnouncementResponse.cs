using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class RetrieveMessageByAnnouncementResponse
    {
        public List<Message> messages { get; set; }
        public int TotalCount { get; set; }
    }
}