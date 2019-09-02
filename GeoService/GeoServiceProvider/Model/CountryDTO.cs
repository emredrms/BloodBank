using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServiceProvider.Model
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public bool Valid { get; set; }
        private List<StateDTO> states;
        private List<CityDTO> cities;

        public List<StateDTO> getStates()
        {
            if (this.states == null)
                this.states = new List<StateDTO>();
            return this.states;
        }

        public void setStates(List<StateDTO> states)
        {
            this.states = states;
        }

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
