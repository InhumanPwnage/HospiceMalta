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
    public class CarePlanApiController : ApiController
    {
        //http://localhost:8236/api/CarePlanApi/GetCarePlans

        /// <summary>
        /// Returns all the Care Plans in the database.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCarePlans()
        {
            HttpResponseMessage message;

            try
            {
                List<CarePlan> carep = new CarePlanBL().GetCarePlans().ToList();

                var result = from a in carep select new { CarePlanId = a.CarePlanID, Status = a.CarePlanStatus, Remarks = a.CarePlanRemarks, CarePlanDate = a.CarePlanDate, CarePlanType = a.CarePlanType };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Care Plan types to populate the Drop down list of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCarePlanTypes()
        {
            HttpResponseMessage message;

            try
            {
                List<CarePlanType> carep = new CarePlanBL().GetCarePlanTypes().ToList();

                var result = from a in carep select new { TypeId = a.CarePlanTypeId, TypeName = a.CareplanTypeName  };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Care Plan statuses to populate the Drop down list of the same name.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetCarePlanStatuses()
        {
            HttpResponseMessage message;

            try
            {
                List<CarePlanStatus> carep = new CarePlanBL().GetCarePlanStatuses().ToList();

                var result = from a in carep select new { StatusId = a.CarePlanStatusId, StatusName = a.CarePlanStatusName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns a Care Plan with the matching Care Plan ID from the database to fill the input fields on the page with.
        /// </summary>
        /// <param name="cpid">The Care Plan ID to search for.</param>
        /// <returns></returns>
        public HttpResponseMessage GetCarePlan(Guid cpid)
        {
            HttpResponseMessage message;

            try
            {
                CarePlan cp = new CarePlanBL().GetCarePlan(cpid);

                var result = new { PatientId = cp.PatientId_fk, Date = cp.CarePlanDate, CarePlanId = cp.CarePlanID, Remark = cp.CarePlanRemarks, Status = cp.CarePlanStatus, Type = cp.CarePlanType };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Returns all the Care Plans of a particular patient.
        /// </summary>
        /// <param name="patid">The Patient's file number to filter by.</param>
        /// <returns></returns>
        public HttpResponseMessage GetCarePlansOfPatient(int patid)
        {
            HttpResponseMessage message;

            try
            {
                List<CarePlan> carepl = new CarePlanBL().GetCarePlansOfPatient(patid).ToList();

                var result = from cp in carepl select new { PatientId = cp.PatientId_fk, Date = cp.CarePlanDate, CarePlanId = cp.CarePlanID, Remark = cp.CarePlanRemarks, Status = cp.CarePlanStatus, Type = cp.CarePlanType };
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
