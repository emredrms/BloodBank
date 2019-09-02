using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Model
{
    public class ContentDTO
    {
        public int ContentId { get; set; }
        public string ContentTypeCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Valid { get; set; }
        public ContentTypeDTO ContentType { get; set; }
    }
}
