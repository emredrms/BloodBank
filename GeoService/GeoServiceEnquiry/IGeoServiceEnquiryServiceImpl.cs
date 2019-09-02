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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGeoServiceEnquiryServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IGeoServiceEnquiryServiceImpl
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONcountryEnquiry")]
        List<Country> JSONcountryEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLcountryEnquiry")]
        List<Country> XMLcountryEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONcountryByCountryCodeEnquiry/{countryCode}")]
        Country JSONcountryByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLcountryByCountryCodeEnquiry/{countryCode}")]
        Country XMLcountryByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONStateEnquiry")]
        List<State> JSONStateEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLStateEnquiry")]
        List<State> XMLStateEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONStateListByCountryCodeEnquiry/{countryCode}")]
        List<State> JSONStateListByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLStateListByCountryCodeEnquiry/{countryCode}")]
        List<State> XMLStateListByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONStateByStateCodeEnquiry/{stateCode}")]
        State JSONStateByStateCodeEnquiry(string stateCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLStateByStateCodeEnquiry/{stateCode}")]
        State XMLStateByStateCodeEnquiry(string stateCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONCityEnquiry")]
        List<City> JSONCityEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLCityEnquiry")]
        List<City> XMLCityEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONCityByCountryCodeEnquiry/{countryCode}")]
        List<City> JSONCityByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLCityByCountryCodeEnquiry/{countryCode}")]
        List<City> XMLCityByCountryCodeEnquiry(string countryCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONCityByStateCodeEnquiry/{stateCode}")]
        List<City> JSONCityByStateCodeEnquiry(string stateCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLCityByStateCodeEnquiry/{stateCode}")]
        List<City> XMLCityByStateCodeEnquiry(string stateCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONCityByCityCodeEnquiry/{cityCode}")]
        City JSONCityByCityCodeEnquiry(string cityCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLCityByCityCodeEnquiry/{cityCode}")]
        City XMLCityByCityCodeEnquiry(string cityCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONDistrictEnquiry")]
        List<District> JSONDistrictEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLDistrictEnquiry")]
        List<District> XMLDistrictEnquiry();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONDistrictListByCityCodeEnquiry/{cityCode}")]
        List<District> JSONDistrictListByCityCodeEnquiry(string cityCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLDistrictListByCityCodeEnquiry/{cityCode}")]
        List<District> XMLDistrictListByCityCodeEnquiry(string cityCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "JSONDistrictByDistrictCodeEnquiry/{districtCode}")]
        District JSONDistrictByDistrictCodeEnquiry(string districtCode);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "XMLDistrictByDistrictCodeEnquiry/{districtCode}")]
        District XMLDistrictByDistrictCodeEnquiry(string districtCode);
    }
}
