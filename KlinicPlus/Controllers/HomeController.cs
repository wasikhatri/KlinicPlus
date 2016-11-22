using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using KlinicPlus.Models;
namespace KlinicPlus.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> Index(string email, string password)
        {
            string result = "";
            int id = 0;
            string type = "";
            client.BaseAddress = new Uri("http://localhost:6887/");
            Login login = new Login() { UserName = email, PassWord = password };
            HttpContent content = new StringContent(login.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsJsonAsync("api/Login/Post", login).Result;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<string>();
                if(result == "" || result == null)
                {
                    Response.Redirect("http://localhost:6623/");
                    return "";
                }
                else
                {
                    id = Convert.ToInt32(result.Substring(3));
                    type = result.Substring(0, 3);
                }
            }
            if(type == "Pat")
            {
                var cookie = new HttpCookie("data", id.ToString());
                Response.Cookies.Add(cookie);
                Response.Redirect("http://localhost:6623/User/");
                return "";
            }
            else
                if(type=="Doc")
            {
                var cookie = new HttpCookie("data", id.ToString());
                Response.Cookies.Add(cookie);
                Response.Redirect("http://localhost:6623/Doctor/");
                return "";
            }
            return "";
        }
        
        [HttpPost]
        public async Task<string> Register(string email, string password, string type, string Firstname, string Lastname, string Gender, string dob, string country, string city)
        {
            string result = "";
            int id = 0;
            string Type = "";
            client.BaseAddress = new Uri("http://localhost:6887/");
            Register register = new Register()
            {
                Email = email,
                Password = password,
                Type = type,
                FirstName = Firstname,
                LastName = Lastname,
                Gender = Gender,
                DOB = dob,
                Country = country,
                City = city                 
            };
            HttpContent content = new StringContent(register.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsJsonAsync("api/Register/Post", register).Result;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<string>();
                //no = Convert.ToInt32(result);
                id = Convert.ToInt32(result.Substring(3));
                Type = result.Substring(0,3);
            }

            if (result == null || result == "")
            {
                Response.Redirect("http://localhost:6623/");
                return "";
            }
            else 
                if (Type == "Pat")
            {
                var cookie = new HttpCookie("data", id.ToString());
                Response.Cookies.Add(cookie);
                Response.Redirect("http://localhost:6623/User/");
                return "";
            }
            else
                if (Type == "Doc")
            {
                var cookie = new HttpCookie("data", id.ToString());
                Response.Cookies.Add(cookie);
                Response.Redirect("http://localhost:6623/Doctor/");
                return "";
            }
            return "";
        }
    }
}
