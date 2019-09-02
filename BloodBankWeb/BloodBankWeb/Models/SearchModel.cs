using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankWeb.Models
{
    public class SearchModel
    {
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public long ResultCount { get; set; }
        public int AnnouncementId { get; set; }
    }
}