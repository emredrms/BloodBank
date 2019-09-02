using GeoServiceData;
using GeoServiceProvider.Model;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoServiceProvider.Helper;

namespace GeoServiceProvider.Controller
{
    public class CountryController
    {
        private static readonly CountryController _instance = new CountryController();

        public static CountryController Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<CountryDTO> retrieveCountryList()
        {
            List<CountryDTO> countries = new List<CountryDTO>();

            try
            {
                List<Country> countryList = Repository.dbConnection.Country.Where(v => v.Valid).ToList();

                if (countryList != null)
                {
                    countryList.ForEach(delegate(Country countryItem)
                    {
                        countries.Add(new CountryDTO
                        {
                            CountryId = countryItem.CountryId,
                            CountryName = countryItem.CountryName.Trim(),
                            CountryCode = countryItem.CountryCode.Trim(),

                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }
            return countries;
        }

        public CountryDTO retrieveCountryByCountryCode(string countryCode)
        {
            try
            {
                var country = Repository.dbConnection.Country.Where(c => c.Valid && c.CountryCode == countryCode).FirstOrDefault();

                if (country == null)
                    return null;

                return new CountryDTO
                {
                    CountryId = country.CountryId,
                    CountryName = country.CountryName,
                    CountryCode = countryCode
                };
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }
            return new CountryDTO();

        }
    }
}
