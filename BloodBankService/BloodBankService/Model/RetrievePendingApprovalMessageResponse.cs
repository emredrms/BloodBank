using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Model
{
    public class RetrievePendingApprovalAnnouncementResponse
    {
        public List<Announcement> Announcements { get; set; }
        public int TotalCount { get; set; }
    }
}