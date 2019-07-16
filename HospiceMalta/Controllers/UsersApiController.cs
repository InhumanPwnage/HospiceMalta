using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using BusinessLayer;
using System.Web.Http.Cors;

namespace HospiceMalta.Controllers
{
    /// <summary>
    /// Handles User information
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersApiController : ApiController
    {
        /// <summary>
        /// Search for users that contain the passed string in their Username.
        /// </summary>
        /// <param name="username">The Username to search for.</param>
        /// <returns></returns>
        public HttpResponseMessage GetUserByUsername(string username)
        {
            HttpResponseMessage message;

            try
            {
                Employee e = new UsersBL().GetUserByUsername(username);

                var result = new { Username = e.Username, FirstName = e.Person.FirstName, Surname = e.Person.LastName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        /// <summary>
        /// Search for a user with the matching User ID in their User ID.
        /// </summary>
        /// <param name="userid">The User ID to search for.</param>
        /// <returns></returns>
        public HttpResponseMessage GetUserById(Guid userid)
        {
            HttpResponseMessage message;

            try
            {
                Employee e = new UsersBL().GetUserById(userid);

                var result = new { Id = e.EmployeesId, FirstName = e.Person.FirstName, Surname = e.Person.LastName };
                message = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                message = Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later."));
            }

            return message;
        }

        //http://localhost:8236/api/UsersApi/GetAuthenticateUser/?username=Admin&password=password
        /// <summary>
        /// Authenticates that the login credentials match and exist in the database.
        /// </summary>
        /// <param name="username">The username to match.</param>
        /// <param name="password">The password to match.</param>
        /// <returns></returns>
        public HttpResponseMessage GetAuthenticateUser(string username, string password)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                if (new UsersBL().GetUserByUsername(username).Password == password)
                {
                    message = Request.CreateResponse<bool>(HttpStatusCode.OK, true);
                }
                else
                {
                    message = Request.CreateResponse<bool>(HttpStatusCode.NotAcceptable, false);
                }
            }
            catch (Exception ex)
            {
                message = Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Error occurred. Please try again later!"));
            }

            return message;
        }

        /// <summary>
        /// Returns a list of Employee email addresses to use for the Staff list in the Email modal.
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage GetWorkerEmails()
        {
            HttpResponseMessage message;

            try
            {
                List<Employee> workers = new UsersBL().GetWorkerEmails().ToList();

                //UsersBL().GetUserByUsername(username);

                var result = from u in workers select new { Name = u.Person.FirstName, Surname = u.Person.LastName, Email = u.Person.Email };
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
