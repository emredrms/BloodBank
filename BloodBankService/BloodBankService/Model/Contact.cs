using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BloodBankService.Model
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string EMail { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string OtherPhone { get; set; }

        [DataMember]
        public string BloodGroup { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string CityCode { get; set; }

        [DataMember]
        public string CityName { get; set; }

        [DataMember]
        public string DistrictCode { get; set; }

        [DataMember]
        public string DistrictName { get; set; }

        [DataMember]
        public Guid UniqueId { get; set; }

        [DataMember]
        public bool Valid { get; set; }

        [DataMember]
        public int Page { get; set; }

        [DataMember]
        public int PageCount { get; set; }

        [DataMember]
        public int PageSize { get; set; }
        
    }
}