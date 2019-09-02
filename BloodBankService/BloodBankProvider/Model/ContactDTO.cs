using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Model
{
    public class ContactDTO
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string OtherPhone { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public Guid UniqueId { get; set; }
        public bool Vaild { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public int PageSize
        {
            get
            {
                return 20;
            }
        }
    }
}
