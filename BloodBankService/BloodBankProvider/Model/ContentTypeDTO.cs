using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Model
{
    public class ContentTypeDTO
    {
        public int ContentTypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public bool Valid { get; set; }

        private List<ContentDTO> contentList;

        public List<ContentDTO> getContentList()
        {
            if (this.contentList == null)
                this.contentList = new List<ContentDTO>();
            return this.contentList;
        }

        public void setContentList(List<ContentDTO> contentList)
        {
            this.contentList = contentList;
        }

    }
}
