using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KlinicPlusAPI.Models
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public string GetRegister(Register register)
        {
            var id = 0;
            var type = "";
            var no = 0;
            var password = EncryptData.CryptorEngine.Encrypt(register.Password, true);
            KlinicPlusEntities dbEntities = new KlinicPlusEntities();
            tbl_users user = new tbl_users();
            user.email = register.Email;
            user.password = password;
            user.type = register.Type;
            user.firstname = register.FirstName;
            user.lastname = register.LastName;
            user.gender = register.Gender;
            user.dob = Convert.ToDateTime(register.DOB);
            //user.image = register.Image;
            user.country = register.Country;
            user.city = register.City;
            try
            {
                dbEntities.tbl_users.Add(user);
                dbEntities.SaveChanges();
                id = dbEntities.tbl_users.Where(p => p.email == register.Email).Select(p => p.user_id).First();
                type = dbEntities.tbl_users.Where(p => p.email == register.Email).Select(p => p.type).First(); // type = Pat || Doc
                no = dbEntities.tbl_users.Count();
            }
            catch (Exception exc)
            {
                
            }
            if(type == "Pat")
            {
                tbl_member member = new tbl_member();
                member.user_id = id;
                try
                {
                    dbEntities.tbl_member.Add(member);
                    dbEntities.SaveChanges();
                    return type + id.ToString(); 
                }
                catch(Exception exc)
                {

                }
            }
            if(type == "Doc")
            {
                tbl_doctor doctor = new tbl_doctor();
                doctor.user_id = id;
                try
                {
                    dbEntities.tbl_doctor.Add(doctor);
                    dbEntities.SaveChanges();
                    return type + id.ToString();
                }
                catch(Exception exc)
                {

                }
            }
            return "";   
        }        
    }
}