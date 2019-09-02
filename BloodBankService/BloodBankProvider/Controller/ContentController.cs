using BloodBankData;
using BloodBankProvider.Helper;
using BloodBankProvider.Model;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBankProvider.Controller
{
    public class ContentController
    {
        private static readonly ContentController _instance = new ContentController();

        public static ContentController Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<ContentTypeDTO> getValidContentType()
        {
            List<ContentTypeDTO> contentTypes = new List<ContentTypeDTO>();

            try
            {
                var contentTypeList = Repository.dbConnection.ContentType.Where(v=>v.Valid).ToList();

                if (contentTypeList != null && contentTypeList.Count > 0)
                {
                    contentTypeList.ForEach(delegate(ContentType contentTypeItem)
                    {
                        contentTypes.Add(new ContentTypeDTO
                        {
                            ContentTypeId = contentTypeItem.ContentTypeId,
                            TypeName = contentTypeItem.TypeName,
                            TypeCode = contentTypeItem.TypeCode,
                            Valid = contentTypeItem.Valid
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return contentTypes;
        }

        public List<ContentDTO> getContentByContentTypeCode(string contentTypeCode)
        {
            List<ContentDTO> contents = new List<ContentDTO>();

            try
            {
                var contentTypeList = Repository.dbConnection.Content.Where(c => c.ContentTypeCode == contentTypeCode && c.Valid).ToList();

                if (contentTypeList != null && contentTypeList.Count > 0)
                {
                    contentTypeList.ForEach(delegate(Content contentItem)
                    {
                        contents.Add(new ContentDTO
                        {
                            ContentId = contentItem.ContentId,
                            ContentTypeCode = contentItem.ContentTypeCode,
                            Title = contentItem.Title,
                            Content = contentItem.Content1,
                            Valid = contentItem.Valid
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return contents;
        }

        public ContentDTO getContentById(int contentId)
        {
            ContentDTO contentDTO = new ContentDTO();

            try
            {
                var content = Repository.dbConnection.Content.Find(contentId);

                contentDTO = new ContentDTO
                {
                    ContentId = content.ContentId,
                    ContentTypeCode = content.ContentTypeCode,
                    Content = content.Content1,
                    Title = content.Title,
                    Valid = content.Valid
                };
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }

            return contentDTO;
        }

        public void updateContentById(int contentId, string text)
        {
            try
            {
                Blood_Bank_Entities conn = Repository.dbConnection;
                var content = conn.Content.Find(contentId);
                content.Content1 = text;
                conn.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(BloodBankConstant.EXCEPTION_FILE_PATH);
                throw ex;
            }
        }
    }
}
