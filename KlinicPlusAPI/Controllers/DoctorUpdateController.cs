using KlinicPlusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace KlinicPlusAPI.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [System.Web.Http.RoutePrefix("")]
    public class DoctorUpdateController : ApiController
    {
       

        // POST: api/DoctorUpdate
        public void Post([FromBody] DoctorUpdate docUpdate)
        {
            bool result = docUpdate.Update(docUpdate);
        }
    }
}
