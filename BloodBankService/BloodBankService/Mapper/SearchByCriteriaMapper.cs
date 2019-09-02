using BloodBankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBankService.Mapper
{
    public class SearchByCriteriaMapper
    {
        public static readonly SearchByCriteriaMapper _instance = new SearchByCriteriaMapper();

        public SearchByCriteriaMapper Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}