using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankWeb.Models
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string PatientName { get; set; }
        public string Hospital { get; set; }
        public string Text { get; set; }
        public string BloodGroup { get; set; }

    }
}