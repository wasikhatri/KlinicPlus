using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicPlusAPI.Models
{
    public class Update
    {
        public int HomePhone { get; set; }
        public int CellPhone { get; set; }
        public int CNIC { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string EmergencyName{ get; set; }
        public int EmergencyNumber { get; set; }
        public string[] Allergies { get; set; }
        public string[] MedicalHistory { get; set; }
        public string[] FamilyHistory { get; set; }
        public string[] Symptoms{ get; set; }
        public string Treatments { get; set; }
        public string Habits { get; set; }
        public int UserID { get; set; }
        public bool UpdateRecord(Update update)
        {
            string medical = string.Join(", ", MedicalHistory);
            string family = string.Join(", ", FamilyHistory);
            string sypmtoms = string.Join(", ", Symptoms);
            string allergies = string.Join(", ", Allergies);
            KlinicPlusEntities dbEntity = new KlinicPlusEntities();
            tbl_member member = dbEntity.tbl_member.Single(p => p.user_id == UserID);
            member.home_phone = HomePhone;
            member.cell_phone = CellPhone;
            member.cnic = CNIC;
            member.bloodgroup = BloodGroup;
            member.maritalstatus = MaritalStatus;
            member.e_contactName = EmergencyName;
            member.e_contactNumber = EmergencyNumber;
            member.allergies = allergies;
            member.medicalHistory = medical;
            member.familyHistory = family;
            member.symptoms = sypmtoms;
            member.habits = Habits;
            member.user_id = UserID;
            member.treatments = Treatments;
            try
            {
                dbEntity.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }    
}