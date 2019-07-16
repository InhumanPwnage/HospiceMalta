using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (TempData["LoginInvalid"] != null)
            {
                ViewBag.LoginInvalid = true;
            }

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            List<SelectListItem> FileStatusList = (from fileStatus
                                          in patient.GetFileStatuses().ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = fileStatus.FileStatusName,
                                                       Value = fileStatus.FileStatusId.ToString()

                                                   }).ToList();
            ViewBag.FileStatus = FileStatusList;

            BusinessLayer.Roles role = new BusinessLayer.Roles();
            List<SelectListItem> WorkerList = (from worker
                                          in role.GetEmployeeWithRole("DOC").ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = worker.Person.FirstName + " " + worker.Person.LastName,
                                                   Value = worker.EmployeesId.ToString()

                                               }).ToList();
            ViewBag.KeyWorkers = WorkerList;

            return View();
        }

        
    }
}