using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class Message
    { 
        public int MessageId { get; set; }
        public string ContectIds { get; set; }
        public string MessageText { get; set; }
        public string AuthUser { get; set; }
        public string Channel { get; set; }
        public bool Active { get; set; }
        public bool Approve { get; set; }
        public bool Send { get; set; }
    }
}