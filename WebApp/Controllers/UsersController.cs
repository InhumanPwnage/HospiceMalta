using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common;
using BusinessLayer;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [Authorize(Roles = "ADM")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (TempData["LoginInvalid"] != null)
            {
                ViewBag.LoginInvalid = true;
            }
            return View();
        }


        [HttpGet]
        [Authorize]
        public ActionResult LogOut()
        {
            TempData["LoginInvalid"] = true;
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string username, string password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8236/");//8509 = WebApp

            //client.DefaultRequestHeaders.Add("apikey", "9CBC3820-D12B-4532-811A-427212AAF3E6");

            string result = await client.GetStringAsync("api/UsersApi/GetAuthenticateUser/?username=" + username + "&password=" + password);
            BusinessLayer.Roles userroles = new BusinessLayer.Roles();
            

            if (result == "true")
            {
                FormsAuthentication.SetAuthCookie(username, true);
                //UsersBL users = new UsersBL();
                //Employee emp = users.GetUserByUsername(emp.Username);
                //userroles.GetUserRoles(username);


                FormsAuthentication.SetAuthCookie(GetSingleRole(userroles.GetUserRoles(username)), true);
                return RedirectToAction("Index", "Assessments");
            }
            else
            {
                ViewBag.Message = "Login failed!";
            }

            return View();
        }


        public string GetSingleRole(IQueryable<Role> roles)
        {
            return roles.ToList()[0].RoleCode;
        }
    }
}