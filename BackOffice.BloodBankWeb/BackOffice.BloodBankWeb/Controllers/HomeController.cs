using BackOffice.BloodBankWeb.Filters;
using BloodBankProvider.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackOffice.BloodBankWeb.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
       
        
    }
}
