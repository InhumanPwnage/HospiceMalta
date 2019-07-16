using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BusinessLayer;
using Common;
using HospiceMalta.Models;

namespace HospiceMalta.Controllers
{
    /// <summary>
    /// Handles Assessment information.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssessmentsApiController : ApiController
    {
        //http://localhost:8236/api/AssessmentsApi/GetAssessments

        //[ApiVerifcation]
        /// <summary>
        /// Returns all the Asssessments in the database.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAssessments()
        {
            HttpResponseMessage message;

            try
            {
                List<Assessment> assess = new AssessmentsBL().GetAssessments().ToList();

                var result = from a in assess select new { PatientId = a.PatientId_fk, Confirmed = a.Confirmed, Worker = a.Worker_fk, Date = a.Date, DateConfirmed = a.ConfirmationDate, AssessmentId = a.AssesmentId, Description = a.Description, Time = a.time, Type = a.AssesmentType_fk, Origin = a.Origin_fk, Duration = a.duration };
                //FullName = a.Employee. + " " + a.Employee.Person.LastName, TypeName = a.AssessmentType.AssesmentTypeName
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Assessment Types in the database so as to populate the Dropdown of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAssessmentTypes()
        {
            HttpResponseMessage message;

            try
            {
                List<AssessmentType> assess = new AssessmentsBL().GetAssessmentTypes().ToList();

                var result = from a in assess select new { TypeId = a.AssesmentTypeId, TypeName = a.AssesmentTypeName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Assessment Origins in the database so as to popualte the Dropdown of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAssessmentOrigins()
        {
            HttpResponseMessage message;

            try
            {
                List<AssessmentOrigin> assess = new AssessmentsBL().GetAssessmentOrigins().ToList();

                var result = from a in assess select new { OriginId = a.AssesmentOriginId, OriginName = a.AssesmentOriginName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Employees in the database so as to populate the Dropdown of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetAssessmentWorkers()
        {
            HttpResponseMessage message;

            try
            {
                List<Employee> emp = new AssessmentsBL().GetAssessmentWorkers().ToList();

                var result = from e in emp select new { WorkerId = e.EmployeesId, WorkerName = e.Person.FirstName, WorkerSurname = e.Person.LastName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns an assessment with the corresponding Assessment ID, to fill the input fields on the page.
        /// </summary>
        /// <param name="assid">The Assessment's ID to to search for.</param>
        /// <returns></returns>
        public HttpResponseMessage GetAssessment(Guid assid)
        {
            HttpResponseMessage message;

            try
            {
                Assessment a = new AssessmentsBL().GetAssessment(assid);

                var result = new {  
                                    PatientId = a.PatientId_fk, Confirmed = a.Confirmed, Worker = a.Worker_fk, 
                                    Date = a.Date, DateConfirmed = a.ConfirmationDate, AssessmentId = a.AssesmentId, 
                                    Description = a.Description, Time = a.time, Type = a.AssesmentType_fk, 
                                    Origin = a.Origin_fk, Duration = a.duration
                                };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, 
                    new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Assessments of a particular Patient.
        /// </summary>
        /// <param name="patid">The Patient's file-number to use to filter the results returned.</param>
        /// <returns></returns>
        public HttpResponseMessage GetAssessmentsOfPatient(int patid)
        {
            HttpResponseMessage message;
            
            try
            {
                List<Assessment> assess = new AssessmentsBL().GetAssessmentsOfPatient(patid).ToList();
                UsersBL users = new UsersBL();
                Roles rol = new Roles();

                var result = from a in assess select new { AssessmentId = a.AssesmentId, Worker = users.GetNameById(a.Worker_fk), Date = a.Date, Time = a.time, Type = a.AssessmentType.AssesmentTypeName, Role = rol.GetRoleName(a.Worker_fk) };
                /*
                var result = from a in assess select new { PatientId = a.PatientId_fk, Confirmed = a.Confirmed, Worker = users.GetNameById(a.Worker_fk), Date = a.Date, DateConfirmed = a.ConfirmationDate, AssessmentId = a.AssesmentId, Description = a.Description, Time = a.time, Type = a.AssesmentType_fk, Origin = a.Origin_fk, Duration = a.duration, TypeName = a.AssessmentType.AssesmentTypeName };
                */
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }



        /*
        //http://stackoverflow.com/questions/27504256/mvc-web-api-no-access-control-allow-origin-header-is-present-on-the-requested
        public HttpResponseMessage GetPatientAssessments()
        {
            HttpResponseMessage message;

            try
            {
                List<PatientAssesment> assess = new PatientAssessBL().GetPatientAssessments().ToList();

                var result = from a in assess select new { PatientAssessmentId = a.PatientAssesmentId, Grade = a.PatientAssessmentGrade, Remark = a.Remark, TypeId = a.Type, PatientId = a.PatientId_fk };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }*/
    }

}
