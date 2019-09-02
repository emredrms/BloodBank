using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public string Text { get; set; }
        public string ContactIds { get; set; }
        public DateTime CreateDate { get; set; }

        public String StrCreateDate { get; set; }
        public bool Valid { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Phone { get; set; }
        public bool Lead { get; set; }

        public List<Message> Messages { get; set; }
    }
}