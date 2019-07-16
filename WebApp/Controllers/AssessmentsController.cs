using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using Common;
using BusinessLayer;
using System.IO;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Net.Mime;

namespace WebApp.Controllers
{
    public class AssessmentsController : Controller
    {
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            if (TempData["InvalidData"] != null)
            {
                ViewBag.InvalidData = true;
            }
            /*BusinessLayer.AssessmentsBL ass = new BusinessLayer.AssessmentsBL();

            List<SelectListItem> asstype = (from p in ass.GetAssessmentTypes().ToList()
                                            select new SelectListItem()
                                            {
                                                Text = p.AssesmentTypeName,
                                                Value = p.AssesmentTypeId.ToString()
                                            }).ToList();
            ViewBag.asstypes = asstype;*/

            return View();
        }

        [HttpPost] [Authorize]
        [MultipleButton(Name = "action", Argument = "SaveAssessment")]
        public ActionResult Assessments(DateTime assDate, int assDuration, Guid assddlTypes,  string assTime, Guid assddlOrigins, Guid assddlWorkers, DateTime assConfirmDate, string assDescription, string AssesmentId, int assPatient )
        {
            if (IsTime(assTime) && IsDate(assDate) && IsDate(assConfirmDate) && IsValidNumber(assDuration) && checkDropdowns(assddlTypes, 1) && checkDropdowns(assddlOrigins, 2) && checkDropdowns(assddlWorkers, 3) && IsValidText(assDescription))
            {
                Assessment a = new Assessment() { Date = assDate, duration = assDuration, time = assTime, AssesmentType_fk = assddlTypes, Worker_fk = assddlWorkers, Origin_fk = assddlOrigins, Description = assDescription, ConfirmationDate = assConfirmDate, PatientId_fk = assPatient };

                //if completely new
                if (AssesmentId == null || AssesmentId.Equals(""))
                {
                    a.AssesmentId = Guid.NewGuid();
                    new BusinessLayer.AssessmentsBL().AddAssessment(a);
                }
                else
                {
                    try
                    {
                        a.AssesmentId = new Guid(AssesmentId);
                        new BusinessLayer.AssessmentsBL().UpdateAssessment(a);
                    }
                    catch(FormatException)
                    {
                        a.AssesmentId = Guid.Empty;
                        TempData["InvalidData"] = true;
                        return RedirectToAction("Index", "Assessments");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Invalid data sent!";
            }

            return RedirectToAction("Index", "Assessments");
            //return RedirectToAction("Index", "Assessments", new { prodid = aid, qty = pqty });
        }

        [HttpPost] [Authorize]
        [MultipleButton(Name = "action", Argument = "SavePatientAssessment")]
        public ActionResult Assessments(Guid patddlTypes, Guid patddlGrades, string patRemarks, string PatientAssessmentId, int patPatient)
        {
            if (checkDropdowns(patddlTypes, 4) && checkDropdowns(patddlGrades, 5)  && IsValidText(patRemarks))
            {
                PatientAssesment pa = new PatientAssesment() { Remark = patRemarks, Grade = patddlGrades, Type = patddlTypes, PatientId_fk = patPatient };

                //if completely new
                if (PatientAssessmentId == null || PatientAssessmentId.Equals(""))
                {
                    pa.PatientAssesmentId = Guid.NewGuid();
                    new BusinessLayer.PatientAssessBL().AddPatientAssessment(pa);
                }
                else
                { //if update
                    try
                    {
                        pa.PatientAssesmentId = new Guid(PatientAssessmentId);
                        new BusinessLayer.PatientAssessBL().UpdatePatientAssessment(pa);
                    }
                    catch (FormatException)
                    {
                        pa.PatientAssesmentId = Guid.Empty;
                        TempData["InvalidData"] = true;
                        return RedirectToAction("Index", "Assessments");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Invalid data sent!";
            }

            return RedirectToAction("Index", "Assessments");
            //return RedirectToAction("Index", "Assessments", new { prodid = aid, qty = pqty });
        }

        [HttpPost] [Authorize]
        [MultipleButton(Name = "action", Argument = "SaveCarePlan")]
        public ActionResult Assessments(Guid carddlType, Guid carddlStatus, DateTime carDate, string carRemarks, string CarePlanId, int carPatient)
        {
            if (checkDropdowns(carddlType, 6) && checkDropdowns(carddlStatus, 7) && IsDate(carDate) && IsValidText(carRemarks))
            {
                CarePlan cp = new CarePlan() {  CarePlanDate = carDate, CarePlanRemarks = carRemarks, CarePlanStatus = carddlStatus, CarePlanType = carddlType, PatientId_fk = carPatient };
                //if completely new
                if (CarePlanId == null || CarePlanId.Equals(""))
                {
                    cp.CarePlanID = Guid.NewGuid();
                    new BusinessLayer.CarePlanBL().AddCarePlan(cp);
                }
                else
                { //if update
                    try
                    {
                        cp.CarePlanID = new Guid(CarePlanId);
                        new BusinessLayer.CarePlanBL().UpdateCarePlan(cp);
                    }
                    catch (FormatException)
                    {
                        cp.CarePlanID = Guid.Empty;
                        TempData["InvalidData"] = true;
                        return RedirectToAction("Index", "Assessments");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Invalid data sent!";
            }

            return RedirectToAction("Index", "Assessments");
            //return RedirectToAction("Index", "Assessments", new { prodid = aid, qty = pqty });
        }

        [Authorize]
        public ActionResult SendingEmail(string emailmessage, string[] emaillist)
        {
            sendMail(emaillist, emailmessage);
            return RedirectToAction("Index", "Assessments");
        }

        public bool IsTime(string thetime)
        {
            Regex checktime = new Regex(@"^(?:[01][0-9]|2[0-3]):[0-5][0-9]$");

            return checktime.IsMatch(thetime);
        }

        public bool IsDate(DateTime date)
        {
            if (DateTime.TryParse(date.ToString(), out date))//"MM/dd/yyyy"
                return true;
            else 
                return false;
        }

        public bool IsValidNumber(int val)
        {
            if (val <= 420 && val > 0)
                return true;
            else
                return false;
        }

        public bool IsValidText(string val)
        {
            if (val == null)
                return true;
            else if ((val.Length <= 1000))
                return true;
            else
                return false;
        }


        //type is the list selector
        public bool checkDropdowns(Guid val, int type)
        {
            bool flag = false;

            //Assessment
            if (type == 1)
            {
                List<AssessmentType> assessments = new AssessmentsBL().GetAssessmentTypes().ToList();

                foreach(AssessmentType at in assessments)
                    if (at.AssesmentTypeId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            if (type == 2)
            {
                List<AssessmentOrigin> assessments = new AssessmentsBL().GetAssessmentOrigins().ToList();

                foreach (AssessmentOrigin ao in assessments)
                    if (ao.AssesmentOriginId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            if (type == 3)
            {
                List<Employee> emp = new AssessmentsBL().GetAssessmentWorkers().ToList();

                foreach (Employee e in emp)
                    if (e.EmployeesId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            //patient Assessments
            if (type == 4)
            {
                List<PatientAssessmentType> patients = new PatientAssessBL().GetPatientAssessmentTypes().ToList();

                foreach (PatientAssessmentType at in patients)
                    if (at.PatientAssesmentTypeId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            if (type == 5)
            {
                List<PatientAssessmentGrade> patients = new PatientAssessBL().GetPatientAssessmentGrades().ToList();

                foreach (PatientAssessmentGrade at in patients)
                    if (at.PatientAssessmentGradeId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            //Care Plan
            if (type == 6)
            {
                List<CarePlanType> careplan = new CarePlanBL().GetCarePlanTypes().ToList();

                foreach (CarePlanType at in careplan)
                    if (at.CarePlanTypeId == val)
                    {
                        flag = true;
                        break;
                    }
            }
            if (type == 7)
            {
                List<CarePlanStatus> careplan = new CarePlanBL().GetCarePlanStatuses().ToList();

                foreach (CarePlanStatus at in careplan)
                    if (at.CarePlanStatusId == val)
                    {
                        flag = true;
                        break;
                    }
            }

            return flag;    
        }


        public void sendMail(string[] recipients, string body)
        {
            StringReader sr = new StringReader(body);

            Document pdfDoc = new Document(PageSize.A4);//, 10f, 10f, 10f, 0f                                                                                                                              

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            MemoryStream memorystream = new MemoryStream();

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memorystream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            byte[] bytes = memorystream.ToArray();
            memorystream.Close();

            foreach(string s in recipients)
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");//("smtp-mail.outlook.com");
                var mail = new MailMessage();

                mail.From = new MailAddress("julian.brincat.a100652@mcast.edu.mt");
                mail.To.Add(s);
                mail.Subject = "Nichpls";
                mail.Body = "iTextSharp PDF Attachment";
                mail.Attachments.Add(new Attachment(new MemoryStream(bytes), "iTextSharpPDF.pdf"));
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("julian.brincat.a100652@mcast.edu.mt", "mcast86793");
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }

            
        }
    }
}