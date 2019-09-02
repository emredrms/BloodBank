using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodBankScheduler.Controllers
{
    public class HomeController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        public IHttpActionResult Index()
        {
            using (TextWriter writer = File.CreateText("C:\\read\\read.txt"))
            {
                //
                // Write one line.
                //
                writer.WriteLine(DateTime.Now.ToString());
                writer.Close();
            }

            return Ok();
        }
    }
}
