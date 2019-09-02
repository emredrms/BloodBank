using GeoServiceEnquiry.Mapper;
using GeoServiceEnquiry.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GeoServiceEnquiry
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GeoServiceEnquiryServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GeoServiceEnquiryServiceImpl.svc or GeoServiceEnquiryServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class GeoServiceEnquiryServiceImpl : IGeoServiceEnquiryServiceImpl
    {
        public List<Country> JSONcountryEnquiry()
        {
            return CountryMapper.Instance.mapCountryList();
        }

        public List<Country> XMLcountryEnquiry()
        {
            return CountryMapper.Instance.mapCountryList();
        }

        public Country JSONcountryByCountryCodeEnquiry(string countryCode)
        {
            return CountryMapper.Instance.mapCountryByCountryCode(countryCode);
        }

        public Country XMLcountryByCountryCodeEnquiry(string countryCode)
        {
            return CountryMapper.Instance.mapCountryByCountryCode(countryCode);
        }

        public List<State> JSONStateEnquiry()
        {
            return StateMapper.Instance.mapRetrieveStateList();
        }

        public List<State> XMLStateEnquiry()
        {
            return StateMapper.Instance.mapRetrieveStateList();
        }

        public List<State> JSONStateListByCountryCodeEnquiry(string countryCode)
        {
            return StateMapper.Instance.mapRetrieveStateListByCountryCode(countryCode);
        }

        public List<State> XMLStateListByCountryCodeEnquiry(string countryCode)
        {
            return StateMapper.Instance.mapRetrieveStateListByCountryCode(countryCode);
        }

        public State JSONStateByStateCodeEnquiry(string stateCode)
        {
            return StateMapper.Instance.mapRetrieveStateByStateCode(stateCode);
        }

        public State XMLStateByStateCodeEnquiry(string stateCode)
        {
            return StateMapper.Instance.mapRetrieveStateByStateCode(stateCode);
        }

        public List<City> JSONCityEnquiry()
        {
            return CityMapper.Instance.mapRetrieveCityList();
        }

        public List<City> XMLCityEnquiry()
        {
            return CityMapper.Instance.mapRetrieveCityList();
        }

        public List<City> JSONCityByCountryCodeEnquiry(string countryCode)
        {
            return CityMapper.Instance.mapRetrieveCityByCountryCode(countryCode);
        }

        public List<City> XMLCityByCountryCodeEnquiry(string countryCode)
        {
            return CityMapper.Instance.mapRetrieveCityByCountryCode(countryCode);
        }

        public List<City> JSONCityByStateCodeEnquiry(string stateCode)
        {
            return CityMapper.Instance.mapRetrieveCityByStateCode(stateCode);
        }

        public List<City> XMLCityByStateCodeEnquiry(string stateCode)
        {
            return CityMapper.Instance.mapRetrieveCityByStateCode(stateCode);
        }

        public City JSONCityByCityCodeEnquiry(string cityCode)
        {
            return CityMapper.Instance.mapRetrieveCityByCityCode(cityCode);
        }

        public City XMLCityByCityCodeEnquiry(string cityCode)
        {
            return CityMapper.Instance.mapRetrieveCityByCityCode(cityCode);
        }

        public List<District> JSONDistrictEnquiry()
        {
            return DistrictMapper.Instance.mapRetrieveDistrictList();
        }

        public List<District> XMLDistrictEnquiry()
        {
            return DistrictMapper.Instance.mapRetrieveDistrictList();
        }

        public List<District> JSONDistrictListByCityCodeEnquiry(string cityCode)
        {
            return DistrictMapper.Instance.mapRetrieveDistrictListByCityCode(cityCode);
        }

        public List<District> XMLDistrictListByCityCodeEnquiry(string cityCode)
        {
            return DistrictMapper.Instance.mapRetrieveDistrictListByCityCode(cityCode);
        }

        public District JSONDistrictByDistrictCodeEnquiry(string districtCode)
        {
            return DistrictMapper.Instance.mapRetrieveDistrictByDistrictCode(districtCode);
        }

        public District XMLDistrictByDistrictCodeEnquiry(string districtCode)
        {
            return DistrictMapper.Instance.mapRetrieveDistrictByDistrictCode(districtCode);
        }
    }
}
