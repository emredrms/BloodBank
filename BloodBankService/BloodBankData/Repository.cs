using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankData
{
    public class Repository
    {
        public static Blood_Bank_Entities dbConnection
        {
            get
            {
                return new Blood_Bank_Entities();
            }
        }
    }
}
