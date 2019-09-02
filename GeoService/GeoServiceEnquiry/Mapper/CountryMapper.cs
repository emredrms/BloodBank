using GeoServiceEnquiry.Model;
using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoServiceEnquiry.Mapper
{
    public class CountryMapper
    {


        private static readonly CountryMapper _instance = new CountryMapper();

        public static CountryMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<Country> mapCountryList()
        {
            List<Country> countries = new List<Country>();

            CountryController.Instance.retrieveCountryList().ForEach(delegate(CountryDTO countryItem)
            {
                countries.Add(new Country
                {
                    CountryId = countryItem.CountryId,
                    CountryName = countryItem.CountryName,
                    CountryCode = countryItem.CountryCode,
                    Valid = true
                });
            });

            return countries;
        }

        public Country mapCountryByCountryCode(string countryCode)
        {
            var country = CountryController.Instance.retrieveCountryByCountryCode(countryCode);
            if (country != null)
            {
                return new Country
                {
                    CountryId = country.CountryId,
                    CountryName = country.CountryName,
                    CountryCode = country.CountryCode,
                    Valid = true
                };
            }

            return new Country();
        }
    }
}