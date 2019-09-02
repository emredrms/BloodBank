using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using BloodBankService.Helper;
using BloodBankService.Mapper;
using BloodBankService.Model;
using BloodBankService.Validation;
using Common.InheritException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BloodBankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BloodServiceServiceImpl" in code, svc and config file together.
    public class BloodServiceServiceImpl : IBloodServiceServiceImpl
    {
        public void JSONAddContact(string name, string surname, string email, string phone, string otherPhone, string bloodGroup, string gender, string cityCode, string cityName, string districtCode, string districtName)
        {
            bloodGroup = bloodGroup != "null" ? bloodGroup.Replace("plus", "+").Replace("minus", "-") : null;
            Contact contact = new Contact
            {
                Name = name == "null" ? null : name,
                Surname = surname == "null" ? null : surname,
                EMail = email == "null" ? null : email,
                Phone = phone == "null" ? null : phone,
                OtherPhone = otherPhone == "null" ? null : otherPhone,
                BloodGroup = bloodGroup == "null" ? null : bloodGroup,
                Gender = gender,
                CityCode = cityCode == "null" ? null : cityCode,
                CityName = cityName == "null" ? null : cityName,
                DistrictCode = districtCode == "null" ? null : districtCode,
                DistrictName = districtName == "null" ? null : districtName
            };

            string errors = ContactValidation.Instance.validateAddContact(contact);
            if (!string.IsNullOrEmpty(errors))
            {
                throw new BloodBankServiceException(errors, ExceptionType.Info.ToString());
            }

            try
            {
                ContactMapper.Instance.mapAddContact(contact);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public void XMLAddContact(string name, string surname, string email, string phone, string otherPhone, string bloodGroup, string gender, string cityCode, string cityName, string districtCode, string districtName)
        {
            bloodGroup = bloodGroup != null ? bloodGroup.Replace("plus", " +").Replace("minus", "-") : null;
            Contact contact = new Contact
            {
                Name = name == "null" ? null : name,
                Surname = surname == "null" ? null : surname,
                EMail = email == "null" ? null : email,
                Phone = phone == "null" ? null : phone,
                OtherPhone = otherPhone == "null" ? null : otherPhone,
                BloodGroup = bloodGroup == "null" ? null : bloodGroup,
                Gender = gender,
                CityCode = cityCode == "null" ? null : cityCode,
                CityName = cityName == "null" ? null : cityName,
                DistrictCode = districtCode == "null" ? null : districtCode,
                DistrictName = districtName == "null" ? null : districtName
            };

            string errors = ContactValidation.Instance.validateAddContact(contact);
            if (!string.IsNullOrEmpty(errors))
            {
                throw new BloodBankServiceException(errors, ExceptionType.Info.ToString());
            }

            try
            {
                ContactMapper.Instance.mapAddContact(contact);
            }
            catch (Exception exception)
            {

                throw exception;
            }
        }

        public bool JSONAvaliableEmail(string email)
        {
            return ContactController.Instance.avaliableEmail(email);
        }

        public bool XMLAvaliableEmail(string email)
        {
            return ContactController.Instance.avaliableEmail(email);
        }

        public List<Contact> JSONRetrieveContacBySearchCriteria(string cityCode, string districtCode, string bloodGroup, string gender, string page)
        {
            bloodGroup = bloodGroup != "null" ? bloodGroup.Replace("plus", "+").Replace("minus", "-") : null;

            Contact contact = new Contact
            {
                CityCode = cityCode,
                DistrictCode = districtCode,
                BloodGroup = bloodGroup,
                Gender = gender,
                Page = Convert.ToInt32(page)

            };

            return ContactMapper.Instance.mapRetrieveContacBySearchCriteria(contact);
        }

        public List<Contact> XMLRetrieveContacBySearchCriteria(string cityCode, string districtCode, string bloodGroup, string gender, string page)
        {
            bloodGroup = bloodGroup != "null" ? bloodGroup.Replace("plus", "+").Replace("minus", "-") : null;

            Contact contact = new Contact
            {
                CityCode = cityCode,
                DistrictCode = districtCode,
                BloodGroup = bloodGroup,
                Gender = gender,
                Page = Convert.ToInt32(page)
            };

            return ContactMapper.Instance.mapRetrieveContacBySearchCriteria(contact);
        }

        public SearchByCriteriaResponse JSONRetrieveContacBySearchCriteriaResult(string cityCode, string districtCode, string bloodGroup, string gender)
        {
            bloodGroup = bloodGroup != "null" ? bloodGroup.Replace("plus", "+").Replace("minus", "-") : null;
            gender = gender != "null" ? gender : null;

            ContactDTO contact = new ContactDTO
            {
                CityCode = cityCode,
                DistrictCode = districtCode,
                BloodGroup = bloodGroup,
                Gender = gender,
            };

            return ContactMapper.Instance.mapRetrieveContactBySearchCriteriaResult(contact);
        }

        public SearchByCriteriaResponse XMLRetrieveContacBySearchCriteriaResult(string cityCode, string districtCode, string bloodGroup, string gender)
        {
            bloodGroup = bloodGroup != "null" ? bloodGroup.Replace("plus", "+").Replace("minus", "-") : null;
            gender = gender != "null" ? gender : null;

            ContactDTO contact = new ContactDTO
            {
                CityCode = cityCode,
                DistrictCode = districtCode,
                BloodGroup = bloodGroup,
                Gender = gender,
            };

            return ContactMapper.Instance.mapRetrieveContactBySearchCriteriaResult(contact);
        }

        public void JSONUpdateMessage(string messageId, string text)
        {
            MessageDTO messageDto = new MessageDTO
            {
                MessageId = Int32.Parse(messageId),
                MessageText = text,
                Active = true
            };

            MessageController.Instance.updateMessage(messageDto);
        }

        public void XMLUpdateMessage(string messageId, string text)
        {
            MessageDTO messageDto = new MessageDTO
            {
                MessageId = Int32.Parse(messageId),
                MessageText = text,
                Active = true
            };

            MessageController.Instance.updateMessage(messageDto);
        }

        public bool JSONLoginSystem(string userName, string password)
        {
            return SystemUserController.Instance.loginSystem(userName, password);
        }

        public bool XMLLoginSystem(string userName, string password)
        {
            return SystemUserController.Instance.loginSystem(userName, password);
        }

        public SystemUser JSONgetUserByUsername(string userName)
        {
            return SystemUserMapper.Instance.getUserByUserName(userName);
        }

        public SystemUser XMLgetUserByUsername(string userName)
        {
            return SystemUserMapper.Instance.getUserByUserName(userName);
        }

        public List<Message> JSONRetrievePendingApprovalMessage()
        {
            return MessageMapper.Instance.mapRetrievePendingApprovalMessage();
        }

        public List<Message> XMLRetrievePendingApprovalMessage()
        {
            return MessageMapper.Instance.mapRetrievePendingApprovalMessage();
        }

        public void JSONUpdateAnnouncement(string announcementId, string text)
        {
            AnnouncementDTO announcementDto = new AnnouncementDTO
            {
                AnnouncementId = Int32.Parse(announcementId),
                Text = text,
                Valid = true
            };

            AnnouncementController.Instance.updateAnnouncement(announcementDto);
        }

        public void XMLUpdateAnnouncement(string announcementId, string text)
        {
            AnnouncementDTO announcementDto = new AnnouncementDTO
            {
                AnnouncementId = Int32.Parse(announcementId),
                Text = text,
                Valid = true
            };

            AnnouncementController.Instance.updateAnnouncement(announcementDto);
        }

        public RetrievePendingApprovalAnnouncementResponse JSONRetrievePendingApprovalAnnouncement()
        {
            return AnnouncementMapper.Instance.mapRetrievePendingApprovalAnnouncement();
        }

        public RetrievePendingApprovalAnnouncementResponse XMLRetrievePendingApprovalAnnouncement()
        {
            return AnnouncementMapper.Instance.mapRetrievePendingApprovalAnnouncement();
        }

        public RetrieveMessageByAnnouncementResponse JSONRetrieveMessageByAnnouncementId(string announcementId)
        {
            return MessageMapper.Instance.mapretrieveMessageByAnnouncementId(Convert.ToInt32(announcementId));
        }

        public RetrieveMessageByAnnouncementResponse XMLRetrieveMessageByAnnouncementId(string announcementId)
        {
            return MessageMapper.Instance.mapretrieveMessageByAnnouncementId(Convert.ToInt32(announcementId));
        }

        public void JSONAddMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead)
        {
            MessageMapper.Instance.addMessageByChannel(announcementId, contactIds, messageText, authUser, facebook, twitter, phone, lead);
        }

        public void XMLAddMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead)
        {
            MessageMapper.Instance.addMessageByChannel(announcementId, contactIds, messageText, authUser, facebook, twitter, phone, lead);
        }

        public List<ContentType> JSONgetValidContentType()
        {
            return ContentMapper.Instance.mapValidContentType();
        }

        public List<ContentType> XMLgetValidContentType()
        {
            return ContentMapper.Instance.mapValidContentType();
        }

        public List<Content> JSONgetContentByContentTypeCode(string contentTypeCode)
        {
            return ContentMapper.Instance.mapContentByContentTypeCode(contentTypeCode);
        }

        public List<Content> XMLgetContentByContentTypeCode(string contentTypeCode)
        {
            return ContentMapper.Instance.mapContentByContentTypeCode(contentTypeCode);
        }

        public Content JSONgetContentById(string contentId)
        {
            return ContentMapper.Instance.mapContentById(contentId);
        }

        public Content XMLgetContentById(string contentId)
        {
            return ContentMapper.Instance.mapContentById(contentId);
        }

        public void JSONUpdateContentById(string contentId, string text)
        {
            text = text.Replace("|", "/");
            ContentController.Instance.updateContentById(!string.IsNullOrEmpty(contentId) ? Convert.ToInt32(contentId) : 0, text);
        }

        public void XMLUpdateContentById(string contentId, string text)
        {
            text = text.Replace("|", "/");
            ContentController.Instance.updateContentById(!string.IsNullOrEmpty(contentId) ? Convert.ToInt32(contentId) : 0, text);
        }

    }
}
