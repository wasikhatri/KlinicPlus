using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using KlinicPlusAPI.Models;

namespace KlinicPlusAPI.Controllers
{
    public class ResetPasswordController : ApiController
    {   // POST: api/ResetPassword
        public void Post([FromBody] ResetPasword Email)
        {

        }
    }
}
