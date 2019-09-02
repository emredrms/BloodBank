using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankWeb.Models
{
    public class Helper
    {
        public static List<SelectListItem> GetCities(string countryCode)
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Seçiniz", Value = "" });

            CityController.Instance.retrieveCityByCountryCode(countryCode).ForEach(delegate(CityDTO cityItem)
            {
                list.Add(new SelectListItem { Text = cityItem.CityName, Value = cityItem.CityCode });
            });

            return list;
        }

        public static List<SelectListItem> GetDistrictByCity(string cityCode)
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Seçiniz", Value = "" });

            DistrictController.Instance.retrieveDistrictListByCityCode(cityCode).ForEach(delegate(DistrictDTO districtItem)
            {
                list.Add(new SelectListItem { Text = districtItem.DistrictName, Value = districtItem.DistrictCode });
            });

            return list;
        }

        public static List<SelectListItem> GetBloodBankGroup()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem() { Text = "Seçiniz", Value = "" });

            list.Add(new SelectListItem { Text = "A RH+", Value = "Aplus" });
            list.Add(new SelectListItem { Text = "A RH-", Value = "Aminus" });
            list.Add(new SelectListItem { Text = "B RH+", Value = "Bplus" });
            list.Add(new SelectListItem { Text = "B RH-", Value = "Bminus" });
            list.Add(new SelectListItem { Text = "AB RH+", Value = "ABplus" });
            list.Add(new SelectListItem { Text = "AB RH-", Value = "ABminus" });
            list.Add(new SelectListItem { Text = "0 RH+", Value = "0plus" });
            list.Add(new SelectListItem { Text = "0 RH-", Value = "0minus" });

            return list;
        }

        public static List<SelectListItem> GetGender(bool showDouble)
        {
            var list = new List<SelectListItem>();

            if (showDouble)
            {
                list.Add(new SelectListItem() { Text = "Kadın / Erkek", Value = null });
            }
            list.Add(new SelectListItem() { Text = "Kadın", Value = "K" });
            list.Add(new SelectListItem() { Text = "Erkek", Value = "E" });

            return list;
        }

    }
}