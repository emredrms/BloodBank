using BloodBankService.Model;
using BloodBankService.Helper;
using Common.InheritException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Configuration;

namespace BloodBankService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBloodServiceServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IBloodServiceServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "JSONAddContact/{name}/{surname}/{email}/{phone}/{otherPhone}/{bloodGroup}/{gender}/{cityCode}/{cityName}/{districtCode}/{districtName}")]
        void JSONAddContact(string name, string surname, string email, string phone, string otherPhone, string bloodGroup, string gender, string cityCode, string cityName, string districtCode, string districtName);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "XMLAddContact/{name}/{surname}/{email}/{phone}/{otherPhone}/{bloodGroup}/{gender}/{cityCode}/{cityName}/{districtCode}/{districtName}")]
        void XMLAddContact(string name, string surname, string email, string phone, string otherPhone, string bloodGroup, string gender, string cityCode, string cityName, string districtCode, string districtName);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "JSONAvaliableEmail/{email}")]
        bool JSONAvaliableEmail(string email);

        [OperationContract]
        [WebInvoke(Method = "GET",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Xml,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "XMLAvaliableEmail/{email}")]
        bool XMLAvaliableEmail(string email);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONRetrieveContacBySearchCriteria/{cityCode}/{districtCode}/{bloodGroup}/{gender}/{page}")]
        List<Contact> JSONRetrieveContacBySearchCriteria(string cityCode, string districtCode, string bloodGroup, string gender, string page);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLRetrieveContacBySearchCriteria/{cityCode}/{districtCode}/{bloodGroup}/{gender}/{page}")]
        List<Contact> XMLRetrieveContacBySearchCriteria(string cityCode, string districtCode, string bloodGroup, string gender, string page);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONRetrieveContacBySearchCriteriaResult/{cityCode}/{districtCode}/{bloodGroup}/{gender}")]
        SearchByCriteriaResponse JSONRetrieveContacBySearchCriteriaResult(string cityCode, string districtCode, string bloodGroup, string gender);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLRetrieveContacBySearchCriteriaResult/{cityCode}/{districtCode}/{bloodGroup}/{gender}")]
        SearchByCriteriaResponse XMLRetrieveContacBySearchCriteriaResult(string cityCode, string districtCode, string bloodGroup, string gender);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONUpdateMessage/{messageId}/{text}")]
        void JSONUpdateMessage(string messageId, string text);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLUpdateMessage/{messageId}/{text}")]
        void XMLUpdateMessage(string messageId, string text);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONLoginSystem/{userName}/{password}")]
        bool JSONLoginSystem(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLLoginSystem/{userName}/{password}")]
        bool XMLLoginSystem(string userName, string password);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONgetUserByUsername/{userName}")]
        SystemUser JSONgetUserByUsername(string userName);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLgetUserByUsername/{userName}")]
        SystemUser XMLgetUserByUsername(string userName);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONRetrievePendingApprovalMessage")]
        List<Message> JSONRetrievePendingApprovalMessage();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLRetrievePendingApprovalMessage")]
        List<Message> XMLRetrievePendingApprovalMessage();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONUpdateAnnouncement/{announcementId}/{text}")]
        void JSONUpdateAnnouncement(string announcementId, string text);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLUpdateAnnouncement/{announcementId}/{text}")]
        void XMLUpdateAnnouncement(string announcementId, string text);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONRetrievePendingApprovalAnnouncement")]
        RetrievePendingApprovalAnnouncementResponse JSONRetrievePendingApprovalAnnouncement();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLRetrievePendingApprovalAnnouncement")]
        RetrievePendingApprovalAnnouncementResponse XMLRetrievePendingApprovalAnnouncement();

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONRetrieveMessageByAnnouncementId/{announcementId}")]
        RetrieveMessageByAnnouncementResponse JSONRetrieveMessageByAnnouncementId(string announcementId);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLRetrieveMessageByAnnouncementId/{announcementId}")]
        RetrieveMessageByAnnouncementResponse XMLRetrieveMessageByAnnouncementId(string announcementId);

        [WebInvoke(Method = "GET",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  BodyStyle = WebMessageBodyStyle.Wrapped,
                  UriTemplate = "JSONAddMessageByChannel/req?announcementId={announcementId}&contactIds={contactIds}&messageText={messageText}&authUser={authUser}&facebook={facebook}&twitter={twitter}&phone={phone}&{lead}")]
        void JSONAddMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead);

        [WebInvoke(Method = "GET",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Xml,
                  BodyStyle = WebMessageBodyStyle.Wrapped,
                  UriTemplate = "XMLAddMessageByChannel/req?announcementId={announcementId}&contactIds={contactIds}&messageText={messageText}&authUser={authUser}&facebook={facebook}&twitter={twitter}&phone={phone}&{lead}")]
        void XMLAddMessageByChannel(string announcementId, string contactIds, string messageText, string authUser, string facebook, string twitter, string phone, string lead);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONgetValidContentType")]
        List<ContentType> JSONgetValidContentType();

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLgetValidContentType")]
        List<ContentType> XMLgetValidContentType();

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONgetContentByContentTypeCode/{contentTypeCode}")]
        List<Content> JSONgetContentByContentTypeCode(string contentTypeCode);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLgetContentByContentTypeCode/{contentTypeCode}")]
        List<Content> XMLgetContentByContentTypeCode(string contentTypeCode);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "JSONgetContentById/{contentId}")]
        Content JSONgetContentById(string contentId);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLgetContentById/{contentId}")]
        Content XMLgetContentById(string contentId);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "JSONUpdateContentById/{contentId}/{text}")]
        void JSONUpdateContentById(string contentId, string text);

        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Xml,
                   BodyStyle = WebMessageBodyStyle.Wrapped,
                   UriTemplate = "XMLUpdateContentById/{contentId}/{text}")]
        void XMLUpdateContentById(string contentId, string text);
    }
}
