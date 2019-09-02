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
    public class CityController
    {
        private static readonly CityController _instance = new CityController();

        public static CityController Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<CityDTO> retrieveCityList()
        {
            List<CityDTO> cities = new List<CityDTO>();

            try
            {
                List<City> cityList = Repository.dbConnection.City.Where(c => c.Valid).ToList();

                if (cityList != null)
                {
                    cityList.ForEach(delegate (City cityItem)
                    {
                        cities.Add(new CityDTO
                        {
                            CityId = cityItem.CityId,
                            CityName = cityItem.CityName.Trim(),
                            CityCode = cityItem.CityCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return cities;
        }

        public List<CityDTO> retrieveCityByCountryCode(string countryCode)
        {
            List<CityDTO> cities = new List<CityDTO>();

            try
            {
                List<City> cityList = Repository.dbConnection.City.Where(c => c.Valid && c.CountryCode.Trim() == countryCode.Trim()).OrderBy(c => c.CityName).ToList();

                if (cityList != null)
                {
                    cityList.ForEach(delegate (City cityItem)
                    {
                        cities.Add(new CityDTO
                        {
                            CityId = cityItem.CityId,
                            CityName = cityItem.CityName.Trim(),
                            CityCode = cityItem.CityCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return cities;
        }

        public List<CityDTO> retrieveCityByStateCode(string stateCode)
        {
            List<CityDTO> cities = new List<CityDTO>();

            try
            {
                List<City> cityList = Repository.dbConnection.City.Where(c => c.Valid && c.StateCode == stateCode).ToList();

                if (cityList != null)
                {
                    cityList.ForEach(delegate (City cityItem)
                    {
                        cities.Add(new CityDTO
                        {
                            CityId = cityItem.CityId,
                            CityName = cityItem.CityName.Trim(),
                            CityCode = cityItem.CityCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return cities;
        }

        public CityDTO retrieveCityByCityCode(string cityCode)
        {
            try
            {
                var city = Repository.dbConnection.City.Where(c => c.Valid && c.CityCode == cityCode).FirstOrDefault();

                if (city == null)
                    return null;

                return new CityDTO
                {
                    CityId = city.CityId,
                    CityName = city.CityName.Trim(),
                    CityCode = city.CityCode.Trim()
                };
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return new CityDTO();
        }
    }
}
