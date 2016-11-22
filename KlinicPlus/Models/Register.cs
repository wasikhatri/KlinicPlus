using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KlinicPlus.Models
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
    }
}