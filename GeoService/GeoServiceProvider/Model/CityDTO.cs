using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServiceProvider.Model
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public bool Valid { get; set; }
        private List<DistrictDTO> districts;

        public List<DistrictDTO> getDistircts()
        {
            if (this.districts == null)
                this.districts = new List<DistrictDTO>();
            return this.districts;
        }

        public void setDistricts(List<DistrictDTO> districts)
        {
            this.districts = districts;
        }
    }
}
