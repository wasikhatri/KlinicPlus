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
    public class PatientDoctor
    {
        public string Id { get; set; }
        public string Type { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [System.Web.Http.RoutePrefix("")]
    public class PatDocController : ApiController
    {

        // POST: api/PatDoc
        [System.Web.Http.HttpPost]
        public string Post([FromBody]PatientDoctor patdoc)
        {
            int? result;
            int userID = Convert.ToInt32(patdoc.Id);
            KlinicPlusEntities dbEntities = new KlinicPlusEntities();
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (patdoc.Type == "Pat")
            {
                result = dbEntities.tbl_member.Where(p => p.user_id == userID).Select(p => p.home_phone).First();
            }
            else
            {
                result = dbEntities.tbl_doctor.Where(p => p.user_id == userID).Select(p => p.contactNumber).First();
            }

            if (result == null)
            {
                return "false";
            }
            if(patdoc.Type=="Doc")
            {
               var records = from user in dbEntities.tbl_users
                              join doc in dbEntities.tbl_doctor on user.user_id equals doc.user_id
                              where doc.user_id == userID
                              select new { doc.hopitalName, doc.contactNumber, doc.speciality, doc.qualification,
                                           user.gender, user.dob, user.country, user.city, user.email};
                return js.Serialize(records);
            }
            else
            {
                var records = from user in dbEntities.tbl_users
                              join mem in dbEntities.tbl_member on user.user_id equals mem.user_id
                              where mem.user_id == userID
                              select new
                              {
                                  user.firstname,
                                  user.lastname,
                                  user.gender,
                                  user.dob,
                                  user.country,
                                  user.city,
                                  user.email,
                                  mem.home_phone,
                                  mem.cell_phone,
                                  mem.cnic,
                                  mem.bloodgroup,
                                  mem.maritalstatus,
                                  mem.e_contactName,
                                  mem.e_contactNumber,
                                  mem.medicalHistory,
                                  mem.familyHistory,
                                  mem.allergies,
                                  mem.symptoms,
                                  mem.treatments,
                                  mem.habits
                              };

                return js.Serialize(records);
            }
        }
    }
}