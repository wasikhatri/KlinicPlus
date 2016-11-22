using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicPlusAPI.Models
{
    public class DoctorUpdate
    {
        public string HospitalName { get; set; }
        public int ContactNumber { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }
        public int UserID { get; set; }


        public bool Update(DoctorUpdate update)
        {
            KlinicPlusEntities dbEntities = new KlinicPlusEntities();
            tbl_doctor doctor = dbEntities.tbl_doctor.Single(p => p.user_id == UserID);
            doctor.hopitalName = HospitalName;
            doctor.contactNumber = ContactNumber;
            doctor.speciality = Speciality;
            doctor.qualification = Qualification;

            try
            {
                dbEntities.SaveChanges();
                return true;
            }
            catch(Exception exc)
            {

            }
            
            return false;
        }
    }
}