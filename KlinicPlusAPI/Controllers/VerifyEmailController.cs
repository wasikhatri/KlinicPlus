using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using KlinicPlusAPI.Models;
namespace KlinicPlusAPI.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [System.Web.Http.RoutePrefix("")]
    public class VerifyEmailController : ApiController
    {
        
        // POST: api/VerifyEmail
        public bool Post([FromBody]VerifyEmail verify)
        {
            bool result = verify.Verify(verify);
            return result;
        }       
    }
}
