using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankProvider.Model
{
    public class AnnouncementDTO
    {
        public int AnnouncementId { get; set; }
        public string Text { get; set; }
        public string ContactIds { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Valid { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
