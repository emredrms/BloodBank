using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServiceProvider.Model
{
    public class StateDTO
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public bool Valid { get; set; }
        private List<CityDTO> cities;

        public List<CityDTO> getCities()
        {
            if (this.cities == null)
                this.cities = new List<CityDTO>();
            return this.cities;
        }

        public void setCities(List<CityDTO> cities)
        {
            this.cities = cities;
        }
    }
}
