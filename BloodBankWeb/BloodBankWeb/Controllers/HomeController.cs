using BloodBankProvider.Controller;
using BloodBankProvider.Model;
using BloodBankWeb.Models;
using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BloodBankWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult GetDistrictByCity(string cityCode)
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Seçiniz", Value = "" });

            DistrictController.Instance.retrieveDistrictListByCityCode(cityCode).ForEach(delegate(DistrictDTO districtItem)
            {
                list.Add(new SelectListItem { Text = districtItem.DistrictName, Value = districtItem.DistrictCode });
            });

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegisterUser(UserRegisterModel userRegisterModel)
        {
            ContactDTO contact = new ContactDTO();
            contact.BloodGroup = userRegisterModel.UserBloodGroup.Replace("plus", " +").Replace("minus", "-");
            contact.CityCode = userRegisterModel.UserCityId;
            contact.DistrictCode = userRegisterModel.UserDistrictId;
            contact.EMail = userRegisterModel.Email;
            contact.Gender = userRegisterModel.UserGender;
            contact.Phone = "("+Regex.Split(userRegisterModel.Phone, @"\-\(")[1];
            contact.Name = userRegisterModel.Name;
            contact.Surname = userRegisterModel.Surname;

            ContactController.Instance.addContact(contact);

            return PartialView("_PRegister", userRegisterModel);
        }

        public ActionResult RetrieveContactBySearchCriteria(SearchModel searchModel)
        {
            ContactDTO contactDTO = new ContactDTO
            {
                CityCode = searchModel.CityId,
                DistrictCode = searchModel.DistrictId,
                BloodGroup = searchModel.BloodGroup.Replace("plus", "+").Replace("minus", "-"),
                Gender = searchModel.Gender.Equals("Kadın / Erkek") ? null : searchModel.Gender,
                Page = 1
            };
        
            var contactResponse = ContactController.Instance.retrieveContactBySearchCriteriaResult(contactDTO);
            if (contactResponse != null)
            {
                SearchModel search = new SearchModel
                {
                    ResultCount = contactResponse.Count,
                    AnnouncementId = contactResponse.AnnouncementId,
                    BloodGroup = searchModel.BloodGroup.Replace("plus", "+").Replace("minus", "-")

                };

                TempData["NoResult"] = null;

                Session["Result"] = search;

                return RedirectToAction("Index", "Result");
            }
            else
            {
                TempData["NoResult"] = "Aradiginiz kriterlere uygun sonuc bulunamamistir";
                return RedirectToAction("Index");
            }
        }

        public ActionResult AvaliableEmail(string email)
        {
            return Json(ContactController.Instance.avaliableEmail(email), JsonRequestBehavior.AllowGet);
        }
    }
}
