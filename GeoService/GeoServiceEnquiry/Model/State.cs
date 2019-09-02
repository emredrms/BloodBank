using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GeoServiceEnquiry.Model
{
    [DataContract]
    public class State
    {
        [DataMember]
        public int StateId { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string StateCode { get; set; }

        [DataMember]
        public bool Valid { get; set; }
    }
}