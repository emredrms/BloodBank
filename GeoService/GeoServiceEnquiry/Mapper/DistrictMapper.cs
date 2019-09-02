using GeoServiceEnquiry.Model;
using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoServiceEnquiry.Mapper
{
    public class DistrictMapper
    {
        private static readonly DistrictMapper _instance = new DistrictMapper();

        public static DistrictMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<District> mapRetrieveDistrictList()
        {
            List<District> districts = new List<District>();

            DistrictController.Instance.retrieveDistrictList().ForEach(delegate(DistrictDTO districtItem)
            {
                districts.Add(new District
                {
                    DistrictId = districtItem.DistrictId,
                    DistrictName = districtItem.DistrictName,
                    DistrictCode = districtItem.DistrictCode,
                    Valid = true
                });
            });

            return districts;
        }

        public List<District> mapRetrieveDistrictListByCityCode(string districtCode)
        {
            List<District> districts = new List<District>();

            DistrictController.Instance.retrieveDistrictListByCityCode(districtCode).ForEach(delegate(DistrictDTO districtsItem)
            {
                districts.Add(new District
                {
                    DistrictId = districtsItem.DistrictId,
                    DistrictName = districtsItem.DistrictName,
                    DistrictCode = districtsItem.DistrictCode,
                    Valid = true
                });
            });

            return districts;
        }

        public District mapRetrieveDistrictByDistrictCode(string districtCode)
        {
            var district = DistrictController.Instance.retrieveDistrictByDistrictCode(districtCode);
            if(district != null)
            {
                return new District
                {
                    DistrictId = district.DistrictId,
                    DistrictName = district.DistrictName,
                    DistrictCode = district.DistrictCode,
                    Valid = true
                };
            }

            return new District();
        }
    }
}