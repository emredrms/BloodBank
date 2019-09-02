using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class RetrievePendingApprovalAnnouncementResponse
    {
        public List<AnnouncementModel> Announcements { get; set; }
        public int TotalCount { get; set; }
    }
}