﻿using KlinicPlusAPI.Models;
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

namespace KlinicPlusAPI.Controllers
{
       
    public class RegisterController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get([FromBody]string id)
        {
            return "value";
        }

        // POST: api/Register
        public string Post([FromBody]Register register)
        {
            string result = register.GetRegister(register);
            return result;
        }
        // PUT: api/Login/5
        public void Put(int id)
        {
            
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
        
    }
}
