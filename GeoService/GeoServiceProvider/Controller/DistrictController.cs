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
    public class DistrictController
    {
        private static readonly DistrictController _instance = new DistrictController();

        public static DistrictController Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<DistrictDTO> retrieveDistrictList()
        {
            List<DistrictDTO> districts = new List<DistrictDTO>();

            try
            {
                List<District> districtList = Repository.dbConnection.District.Where(d => d.Valid).ToList();

                if (districtList != null)
                {
                    districtList.ForEach(delegate (District districtItem)
                    {
                        districts.Add(new DistrictDTO
                        {
                            DistrictId = districtItem.DistrictId,
                            DistrictName = districtItem.DistrictName.Trim(),
                            DistrictCode = districtItem.DistrictCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return districts;
        }

        public List<DistrictDTO> retrieveDistrictListByCityCode(string cityCode)
        {
            List<DistrictDTO> distircts = new List<DistrictDTO>();

            try
            {
                List<District> districtList = Repository.dbConnection.District.Where(d => d.Valid && d.CityCode.Trim() == cityCode.Trim()).OrderBy(d => d.DistrictName).ToList();

                if (districtList != null)
                {
                    districtList.ForEach(delegate (District districtItem)
                    {
                        distircts.Add(new DistrictDTO
                        {
                            DistrictId = districtItem.DistrictId,
                            DistrictName = districtItem.DistrictName.Trim(),
                            DistrictCode = districtItem.DistrictCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return distircts;
        }

        public DistrictDTO retrieveDistrictByDistrictCode(string districtCode)
        {
            try
            {
                var district = Repository.dbConnection.District.Where(c => c.Valid && c.DistrictCode == districtCode).FirstOrDefault();

                if (district == null)
                    return null;

                return new DistrictDTO
                {
                    DistrictId = district.DistrictId,
                    DistrictName = district.DistrictName.Trim(),
                    DistrictCode = district.DistrictCode.Trim()
                };
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return new DistrictDTO();
        }
    }
}
