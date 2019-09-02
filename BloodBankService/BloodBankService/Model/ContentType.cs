using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Model
{
    public class ContentType
    {
        public int ContentTypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public bool Valid { get; set; }

        private List<Content> contentList;

        public List<Content> getContentList()
        {
            if (this.contentList == null)
                this.contentList = new List<Content>();
            return this.contentList;
        }

        public void setContentList(List<Content> contentList)
        {
            this.contentList = contentList;
        }
    }
}