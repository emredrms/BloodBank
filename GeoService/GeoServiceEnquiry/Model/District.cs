using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoServiceEnquiry.Model
{
    [DataContract]
    public class District
    {
        [DataMember]
        public int DistrictId { get; set; }

        [DataMember]
        public string DistrictName { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public bool Valid { get; set; }
    }
}