using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoServiceEnquiry.Model
{
    [DataContract]
    public class City
    {
        [DataMember]
        public int CityId { get; set; }

        [DataMember]
        public string CityName { get; set; }

        [DataMember]
        public string  CityCode { get; set; }

        [DataMember]
        public bool Valid { get; set; }
    }
}