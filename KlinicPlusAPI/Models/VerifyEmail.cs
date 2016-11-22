using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicPlusAPI.Models
{
    public class VerifyEmail
    {
        public string Email { get; set; }
        public bool Verify(VerifyEmail email)
        {
            int? result = null;
            KlinicPlusEntities dbEntities = new KlinicPlusEntities();
            result = dbEntities.tbl_users.Where(p => p.email == email.Email).Select(p => p.user_id).Count();
            if (result > 0)
                return false;
            else
                return true;
        }
    }
}