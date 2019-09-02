using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Model
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string ContactIds { get; set; }
        public string MessageText { get; set; }
        public string AuthUser { get; set; }
        public string Channel { get; set; }
        public bool Active { get; set; }
        public bool Approve { get; set; }
        public bool Send { get; set; }
        public bool Lead { get; set; }
        public AnnouncementDTO Announcement { get; set; }
    }
}
