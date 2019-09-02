using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using BloodBankService.Helper;
using BloodBankService.Model;
using BloodBankService.Validation;
using Common.InheritException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace BloodBankService.Mapper
{
    public class ContactMapper
    {
        private static readonly ContactMapper _instance = new ContactMapper();

        public static ContactMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public void mapAddContact(Contact contact)
        {

            ContactDTO contactDto = new ContactDTO
            {
                Name = contact.Name,
                Surname = contact.Surname,
                EMail = contact.EMail,
                Phone = contact.Phone,
                OtherPhone = contact.OtherPhone,
                BloodGroup = contact.BloodGroup,
                Gender = contact.Gender,
                CityCode = contact.CityCode,
                CityName = contact.CityName,
                DistrictCode = contact.DistrictCode,
                DistrictName = contact.DistrictName
            };
            ContactController.Instance.addContact(contactDto);
        }

        public List<Contact> mapRetrieveContacBySearchCriteria(Contact contact)
        {
            List<Contact> contactList = new List<Contact>();

            ContactDTO contactDto = new ContactDTO
            {
                CityCode = contact.CityCode,
                DistrictCode = contact.DistrictCode,
                BloodGroup = contact.BloodGroup,
                Gender = contact.Gender,
                Page = contact.Page
            };

            ContactController.Instance.retrieveContacBySearchCriteria(contactDto).ForEach(delegate(ContactDTO contactItem)
            {
                contactList.Add(new Contact
                {
                    Name = contactItem.Name,
                    Surname = contactItem.Surname,
                    BloodGroup = contactItem.BloodGroup,
                    CityName = contactItem.CityName,
                    DistrictName = contactItem.DistrictName
                });
            });


            return contactList;
        }

        public SearchByCriteriaResponse mapRetrieveContactBySearchCriteriaResult(ContactDTO contact)
        {
            var contactResponse = ContactController.Instance.retrieveContactBySearchCriteriaResult(contact);

            return new SearchByCriteriaResponse
            {
                Count = contactResponse.Count,
                AnnouncementId = contactResponse.AnnouncementId
            };
        }
    }
}