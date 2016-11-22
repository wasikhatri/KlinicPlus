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

namespace KlinicPlusAPI.Controllers
{
    public class UpdateController : ApiController
    {
        // GET: api/Update
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Update/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Update
        public void Post([FromBody] Update update)
        {
            bool result = update.UpdateRecord(update);

        }

        // PUT: api/Update/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Update/5
        public void Delete(int id)
        {
        }
    }
}
