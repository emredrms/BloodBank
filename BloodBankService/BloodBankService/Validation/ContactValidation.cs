using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Validation
{
    public class ContactValidation
    {
        private static readonly ContactValidation _instance = new ContactValidation();

        public static ContactValidation Instance
        {
            get
            {
                return _instance;
            }
        }

        public string validateAddContact(Contact contact)
        {
            List<String> errors = new List<String>();

            if (String.IsNullOrEmpty(contact.Name))
                errors.Add("İsim alanı zorunludur");
            if (String.IsNullOrEmpty(contact.Surname))
                errors.Add("Soyisim alanı zorunludur");
            if (String.IsNullOrEmpty(contact.EMail))
                errors.Add("E-mail alanı zorunludur");
            if (String.IsNullOrEmpty(contact.Phone))
                errors.Add("Telefon alanı zorunludur");
            if (String.IsNullOrEmpty(contact.Gender))
                errors.Add("Cinsiyet alanı zorunludur");

            if (errors.Count > 0)
                return String.Join("-", errors);
            return null;
        }
    }
}