using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloodBankService.Model
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public int MessageId { get; set; }

        [DataMember]
        public string ContectIds { get; set; }

        [DataMember]
        public string MessageText { get; set; }

        [DataMember]
        public string AuthUser { get; set; }

        [DataMember]
        public string Channel{ get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        public bool Approve { get; set; }

        [DataMember]
        public bool Send { get; set; }


    }
}