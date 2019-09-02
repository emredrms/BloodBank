using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Models
{
    public class Helper
    {
        public static List<SelectListItem> GetContentType()
        {
            var list = new List<SelectListItem>();

            ContentController.Instance.getValidContentType().ForEach(delegate (ContentTypeDTO contentTypeItem)
            {
                list.Add(new SelectListItem { Text = contentTypeItem.TypeName, Value = contentTypeItem.TypeCode });
            });

            return list;
        }

        public static List<SelectListItem> GetContentByTypeCode(string typeCode)
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Seçiniz", Value = "" });

            ContentController.Instance.getContentByContentTypeCode(typeCode).ForEach(delegate (ContentDTO contentItem)
            {
                list.Add(new SelectListItem { Text = contentItem.Title, Value = contentItem.ContentId.ToString() });
            });

            return list;
        }
    }
}