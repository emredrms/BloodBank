using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Mapper
{
    public class ContentMapper
    {
        private static readonly ContentMapper _instance = new ContentMapper();

        public static ContentMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<ContentType> mapValidContentType()
        {
            List<ContentType> contentTypes = new List<ContentType>();

            ContentController.Instance.getValidContentType().ForEach(delegate(ContentTypeDTO contentTypeItem)
            {
                contentTypes.Add(new ContentType
                {
                    ContentTypeId = contentTypeItem.ContentTypeId,
                    TypeCode = contentTypeItem.TypeCode.Trim(),
                    TypeName = contentTypeItem.TypeName,
                    Valid = contentTypeItem.Valid
                });
            });

            return contentTypes;
        }

        public List<Content> mapContentByContentTypeCode(string contentTypeCode)
        {
            List<Content> contents = new List<Content>();

            ContentController.Instance.getContentByContentTypeCode(contentTypeCode.Trim()).ForEach(delegate(ContentDTO contentItem)
            {
                contents.Add(new Content
                {
                    ContentId = contentItem.ContentId,
                    ContentText = contentItem.Content,
                    ContentTypeCode = contentItem.ContentTypeCode.Trim(),
                    Title = contentItem.Title,
                    Valid = contentItem.Valid
                });
            });

            return contents;
        }

        public Content mapContentById(string contentId)
        {
            Content content = new Content();
            var con = ContentController.Instance.getContentById(!string.IsNullOrEmpty(contentId) ? Convert.ToInt32(contentId) : 0);

            content = new Content
            {
                ContentId = con.ContentId,
                ContentText = con.Content,
                ContentTypeCode = con.ContentTypeCode.Trim(),
                Title = con.Title,
                Valid = con.Valid
            };

            return content;
        }
    }
}