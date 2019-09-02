using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Model
{
    public class Content
    {
        public int ContentId { get; set; }
        public string ContentTypeCode { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public bool Valid { get; set; }
        public ContentType ContentType { get; set; }
    }
}