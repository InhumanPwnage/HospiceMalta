using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataLayer;

namespace BusinessLayer
{
    public class UsersBL
    {
        public IQueryable<Employee> GetUsers()
        {
            return new UsersHandler().GetUsers();
        }

        public IQueryable<Employee> GetUserByKeyword(string keyword)
        {
            return new UsersHandler().GetUserByKeyword(keyword);
        }

        public Employee GetUserById(Guid userid)
        {
            return new UsersHandler().GetUserById(userid);
        }

        public string GetNameById(Guid userid)
        {
            return new UsersHandler().GetNameById(userid);
        }

        public Employee GetUserByUsername(string username)
        {
            return new UsersHandler().GetUserByUsername(username);
        }

        public IQueryable<Employee> GetWorkerEmails()
        {
            return new UsersHandler().GetWorkerEmails();
        }


        public Common.DoctorType GetDoctorType(string TypeName)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDoctorTypes(TypeName);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.Doctor> GetDoctors(Guid DoctorTypeId)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDoctors(DoctorTypeId);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public Common.Doctor GetDoctor(Guid? DoctorId)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDoctor(DoctorId);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Doctor> GetDoctors()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDoctor();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }


        ///Returns true if account exists
        public bool Login(string Username, string Password)
        {
            try
            {
                Employee e = this.GetUserByUsername(Username);
                if (e != null)
                {
                    if (Password.Equals(e.Password))
                    {
                        return true;
                    }

                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
