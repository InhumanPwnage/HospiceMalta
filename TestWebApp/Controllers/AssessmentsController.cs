using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace TestWebApp.Controllers
{
    public class AssessmentsController : Controller
    {
        // GET: Assessments
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public bool IsTime(string thetime)
        {
            Regex checktime =
                new Regex(@"^(20|21|22|23|[01]d|d)(([:][0-5]d){1,2})$");

            return checktime.IsMatch(thetime);
        }
    }
}