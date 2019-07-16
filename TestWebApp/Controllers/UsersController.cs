using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TestWebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {

            //how to call WebAPI method from Controller
            //FormsAuthentication.SetAuthCookie(username, true);

            //how to call WebAPI method from AJAX
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8236/");//8509 = WebApp

            //Action Filter
            //client.DefaultRequestHeaders.Add("apikey", );

            //http://localhost:8236/api/UsersApi/GetAuthenticateUser/?username=Admin&password=password
            string result = await client.GetStringAsync("api/UsersApi/GetAuthenticateUser/?username=" + username + "&password=" + password);

            if (result == "true")
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Login failed!";
            }

            return View();
        }
    }
}