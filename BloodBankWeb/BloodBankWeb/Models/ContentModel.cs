using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankWeb.Models
{
    public class ContentModel
    {
        public int ContentId { get; set; }
        public string ContentTypeCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private static Dictionary<string, int> contentDictionary;

        public static Dictionary<string,int> getContentDictionary()
        {
            contentDictionary = new Dictionary<string, int>();
            contentDictionary.Add("Hakkimizda", 1);
            contentDictionary.Add("Faaliyetler", 2);
            contentDictionary.Add("BasinOdasi", 3);
            contentDictionary.Add("SSS", 4);
            contentDictionary.Add("BizeUlasin", 6);

            return contentDictionary;
        }
    }
}