using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoServiceData
{
    public class Repository
    {
        public static Geo_DataSource_Entities dbConnection
        {
            get
            {
                return new Geo_DataSource_Entities();
            }
        }
    }
}
