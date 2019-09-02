using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackOffice.BloodBankWeb.Models
{
    public class ContentModel : RootModel
    {
        public int MainContentTypeId { get; set; }
        public string MainTypeName { get; set; }
        public string MainTypeCode { get; set; }
       
        public int ContentId { get; set; }
        public string ContentTypeCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
       

    }
}