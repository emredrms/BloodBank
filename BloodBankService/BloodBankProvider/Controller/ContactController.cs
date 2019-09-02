using BloodBankProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.InheritException;
using Common.Helper;
using BloodBankData;
using System.Data.Entity.Validation;
using BloodBankProvider.Helper;

namespace BloodBankProvider.Controller
{
    public class ContactController
    {
        private static readonly ContactController _instance = new ContactController();

        public static ContactController Instance
        {
            get
            {
                return _instance;
            }
        }

        public void addContact(ContactDTO contactDTO)
        {
            Blood_Bank_Entities conn = Repository.dbConnection;
            try
            {
                Contact contact = new Contact();
                contact.Name = contactDTO.Name.Trim();
                contact.Surname = contactDTO.Surname.Trim();
                contact.Email = contactDTO.EMail.Trim();
                contact.Phone = contactDTO.Phone.Trim();
                contact.OtherPhone = contactDTO.OtherPhone != null ? contactDTO.OtherPhone.Trim() : null;
                contact.BloodGroup = contactDTO.BloodGroup.Trim();
                contact.CityCode = contactDTO.CityCode != null ? contactDTO.CityCode.Trim() : null;
                contact.CityName = contactDTO.CityName != null ? contactDTO.CityName.Trim() : null;
                contact.DistrictCode = contactDTO.DistrictCode != null ? contactDTO.DistrictCode.Trim() : null;
                contact.DistrictName = contactDTO.DistrictName != null ? contactDTO.DistrictName.Trim() : null;
                contact.Gender = contactDTO.Gender != null ? contactDTO.Gender.Trim() : null;
                contact.UniqueId = System.Guid.NewGuid();
                contact.Valid = true;
                conn.Contact.Add(contact);
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }

        public ContactDTO getContact(int contactId)
        {
            ContactDTO contactDTO = null;
            Contact contact = Repository.dbConnection.Contact.Where(c=>c.ContactId == contactId && c.Valid).SingleOrDefault();
            if(contact != null)
            {
                contactDTO = new ContactDTO();
                contactDTO.BloodGroup = contact.BloodGroup;
                contactDTO.CityCode = contact.CityCode;
                contactDTO.CityName = contact.CityName;
                contactDTO.ContactId = contact.ContactId;
                contactDTO.DistrictCode = contact.DistrictCode;
                contactDTO.DistrictName = contact.DistrictName;
                contactDTO.EMail = contact.Email;
                contactDTO.Gender = contact.Gender;
                contactDTO.Name = contact.Name;
                contactDTO.OtherPhone = contact.OtherPhone;
                contactDTO.Phone = contact.Phone;
                contactDTO.Surname = contact.Surname;
                contactDTO.UniqueId = contact.UniqueId;
                contactDTO.Vaild = contact.Valid;
            }

            return contactDTO;
        }

        public bool avaliableEmail(string email)
        {
            try
            {
                return !Repository.dbConnection.Contact.Any(c => c.Email == email);
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
            }
            return true;
        }

        public List<ContactDTO> retrieveContacBySearchCriteria(ContactDTO contact)
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            List<Contact> contactDataList = new List<Contact>();

            try
            {
                int skip = (contact.Page - 1) * contact.PageSize;

                if (contact.Gender == null)
                    contactDataList = Repository.dbConnection.Contact.Where(c => c.CityCode == contact.CityCode && c.DistrictCode == contact.DistrictCode && c.BloodGroup == contact.BloodGroup).OrderBy(c => c.Name).Skip(skip).Take(contact.PageSize).ToList();
                else
                    contactDataList = Repository.dbConnection.Contact.Where(c => c.CityCode == contact.CityCode && c.DistrictCode == contact.DistrictCode && c.BloodGroup == contact.BloodGroup && c.Gender == contact.Gender).OrderBy(c => c.Name).Skip(skip).Take(contact.PageSize).ToList();

                contactDataList.ForEach(delegate(Contact contactItem)
                {
                    contacts.Add(new ContactDTO
                    {
                        Name = contactItem.Name,
                        Surname = contactItem.Surname,
                        BloodGroup = contactItem.BloodGroup,
                        CityName = contactItem.CityName,
                        DistrictName = contactItem.DistrictName
                    });
                });
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
            }

            return contacts;
        }

        public SearchByCriteriaResponseDTO retrieveContactBySearchCriteriaResult(ContactDTO contact)
        {
            SearchByCriteriaResponseDTO response = new SearchByCriteriaResponseDTO();
            List<Contact> contactDataList = new List<Contact>();
            List<int> contactIds = new List<int>();

            City city = Repository.dbConnection.City.Where(v => v.CityCode == contact.CityCode).FirstOrDefault();
            District district = Repository.dbConnection.District.Where(v => v.DistrictCode == contact.DistrictCode).FirstOrDefault();

            if (contact.Gender == null)
                contactIds = Repository.dbConnection.Contact.Where(c => c.CityCode == contact.CityCode && c.DistrictCode == contact.DistrictCode && c.BloodGroup == contact.BloodGroup).Select(c => c.ContactId).ToList();
            else
                contactIds = Repository.dbConnection.Contact.Where(c => c.CityCode == contact.CityCode && c.DistrictCode == contact.DistrictCode && c.BloodGroup == contact.BloodGroup && c.Gender == contact.Gender).Select(c => c.ContactId).ToList();
            if (contactIds.Count > 0)
            {
                AnnouncementDTO announcement = new AnnouncementDTO();
                announcement.ContactIds = String.Join("-", contactIds.ConvertAll(c => c.ToString()));
                announcement.Text = "(" + city.CityName + " " + district.DistrictName + ")";
                response.AnnouncementId = AnnouncementController.Instance.addAnnouncement(announcement);
                response.Count = contactIds.Count();

            }
            else
            {
                AnnouncementDTO announcement = new AnnouncementDTO();
                announcement.ContactIds = "null";
                announcement.Text = "(" + city.CityName + " " + district.DistrictName + ")";
                response.AnnouncementId = AnnouncementController.Instance.addAnnouncement(announcement);
                response.Count = 0;
            }
            return response;
        }
    }
}
