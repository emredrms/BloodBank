using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankWeb.Models
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserBloodGroup { get; set; }
        public string UserGender { get; set; }
        public string Phone { get; set; }
        public string UserCityId { get; set; }
        public string UserDistrictId { get; set; }
    }
}