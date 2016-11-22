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
using System.Web.Script.Serialization;

namespace KlinicPlusAPI.Controllers
{
    public class Country
    {
        public string CountryName { get; set; }
    }


    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [System.Web.Http.RoutePrefix("")]
    public class GetCitiesController : ApiController
    {

        // POST: api/GetCities
        [System.Web.Http.HttpPost]
        public string Post([FromBody]Country country)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var result = new List<string>();
            KlinicPlusEntities dbEntity = new KlinicPlusEntities();
            result = dbEntity.tbl_countries.Where(p => p.name == country.CountryName).Select(p => p.city).ToList();
            return js.Serialize(result);
        }
    }
}
