using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;

namespace KlinicPlusAPI.Controllers
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginController : ApiController
    {
        public string Post([FromBody]Login login)
        {
            var id = 0;
            var type = "";
            var password = EncryptData.CryptorEngine.Encrypt(login.Password, true);

            KlinicPlusEntities dbEntity = new KlinicPlusEntities();
            try
            {
                id = dbEntity.tbl_users.Where(p => p.email == login.UserName && p.password == password).Select(p => p.user_id).First();
                type = dbEntity.tbl_users.Where(p => p.email == login.UserName && p.password == password).Select(p => p.type).First();
            }
            catch (Exception)
            {
                return "";
            }
            if (id > 0)
                return type + id.ToString();
            return "";
        }
    }
}
