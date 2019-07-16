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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PatientAssessmentsApiController : ApiController
    {
        //http://localhost:8236/api/PatientAssessmentsApi/GetPatientAssessments

        /// <summary>
        /// Returns all Patient Assessments in the database.
        /// </summary>
        /// <returns></returns>
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
        }

        /// <summary>
        /// Returns all Patient Assessment types in the database to populate the Drop Down list of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetPatientAssessmentTypes()
        {
            HttpResponseMessage message;

            try
            {
                List<PatientAssessmentType> assess = new PatientAssessBL().GetPatientAssessmentTypes().ToList();

                var result = from a in assess select new { TypeId = a.PatientAssesmentTypeId, TypeName = a.PatientAssessmentTypeName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all Patient Assessment grades in the database to popluate the Drop Down list of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetPatientAssessmentGrades()
        {
            HttpResponseMessage message;

            try
            {
                List<PatientAssessmentGrade> assess = new PatientAssessBL().GetPatientAssessmentGrades().ToList();

                var result = from a in assess select new { GradeId = a.PatientAssessmentGradeId, GradeName = a.PatientAssessmentGradeName, GradeType = a.PatientAssessmentTypeId_fk };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all Patient Assessment grades associated with the Type ID passed, to populate the Drop Down list after a Type is chosen.
        /// </summary>
        /// <param name="typeid">The Type ID to filter the results by.</param>
        /// <returns></returns>
        public HttpResponseMessage GetPatientAssessmentTypeGrades(Guid typeid)
        {
            HttpResponseMessage message;

            try
            {
                List<PatientAssessmentGrade> assess = new PatientAssessBL().GetPatientAssessmentTypeGrades(typeid).ToList();

                var result = from a in assess select new { GradeId = a.PatientAssessmentGradeId, GradeName = a.PatientAssessmentGradeName, GradeType = a.PatientAssessmentTypeId_fk };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns a particular Patient Assessment from the database to fill every input field on the page.
        /// </summary>
        /// <param name="patid">The Patient Assessment's ID to searh for.</param>
        /// <returns></returns>
        public HttpResponseMessage GetPatientAssessment(Guid patid)
        {
            HttpResponseMessage message;

            try
            {
                PatientAssesment pa = new PatientAssessBL().GetPatientAssessment(patid);

                var result = new { PatientId = pa.PatientId_fk, Grade = pa.Grade, PatAssId = pa.PatientAssesmentId, Remark = pa.Remark, Type = pa.Type };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns the Patient Assessments of a particular Patient in the database.
        /// </summary>
        /// <param name="patid">The Patient ID to filter the results by.</param>
        /// <returns></returns>
        public HttpResponseMessage GetPatientAssessmentsOfPatient(int patid)
        {
            HttpResponseMessage message;

            try
            {
                List<PatientAssesment> patass = new PatientAssessBL().GetPatientAssessmentsOfPatient(patid).ToList();

                var result = from pa in patass select new { PatientId = pa.PatientId_fk, Grade = pa.Grade, PatAssId = pa.PatientAssesmentId, Remark = pa.Remark, Type = pa.Type };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }
    }
}
