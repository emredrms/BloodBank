using GeoServiceEnquiry.Model;
using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoServiceEnquiry.Mapper
{
    public class CityMapper
    {
        private static readonly CityMapper _instance = new CityMapper();

        public static CityMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<City> mapRetrieveCityList()
        {
            List<City> cities = new List<City>();

            CityController.Instance.retrieveCityList().ForEach(delegate(CityDTO cityItem)
            {
                cities.Add(new City
                {
                    CityId = cityItem.CityId,
                    CityName = cityItem.CityName,
                    CityCode = cityItem.CityCode,
                    Valid = true
                });
            });

            return cities;
        }

        public List<City> mapRetrieveCityByCountryCode(string countryCode)
        {
            List<City> cities = new List<City>();

            CityController.Instance.retrieveCityByCountryCode(countryCode).ForEach(delegate(CityDTO cityItem)
                {
                    cities.Add(new City
                    {
                        CityId = cityItem.CityId,
                        CityName = cityItem.CityName,
                        CityCode = cityItem.CityCode,
                        Valid = true
                    });
                    
                });

            return cities;
        }

        public List<City> mapRetrieveCityByStateCode(string stateCode)
        {
            List<City> cities = new List<City>();

            CityController.Instance.retrieveCityByCountryCode(stateCode).ForEach(delegate(CityDTO cityItem)
            {
                cities.Add(new City
                {
                    CityId = cityItem.CityId,
                    CityName = cityItem.CityName,
                    CityCode = cityItem.CityCode,
                    Valid = true
                });

            });

            return cities;
        }

        public City mapRetrieveCityByCityCode(string cityCode)
        {
            var city = CityController.Instance.retrieveCityByCityCode(cityCode);
            if(city != null)
            {
                return new City
                {
                    CityId = city.CityId,
                    CityName = city.CityName,
                    CityCode = city.CityCode,
                    Valid = true
                };
            }
            return new City();
        }
    }
}