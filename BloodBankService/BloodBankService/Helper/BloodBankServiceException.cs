using Common.InheritException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace BloodBankService.Helper
{
    [DataContract]
    public class BloodBankServiceException : Exception
    {
        [DataMember]
        public string message { get; set; }

        [DataMember]
        public string type { get; set; }

        public BloodBankServiceException(string message, string type)
        {
            this.message = message;
            this.type = type;
        }
    }

}