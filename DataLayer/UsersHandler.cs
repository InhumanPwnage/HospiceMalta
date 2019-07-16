using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class UsersHandler : ConnectionClass
    {
        public UsersHandler() : base() { }

        public IQueryable<Employee> GetUsers()
        {
            return Entities.Employees;
        }

        public Employee GetUserByUsername(string Usename)
        {
            return this.Entities.Employees.FirstOrDefault(u => u.Username.ToLower().Equals(Usename.ToLower()));
        }

        public Employee GetUserById(Guid userid)
        {
            return this.Entities.Employees.FirstOrDefault(u => u.EmployeesId == userid);
        }

        public string GetNameById(Guid userid)
        {
            Employee emp = this.Entities.Employees.FirstOrDefault(u => u.EmployeesId == userid);
            return emp.Person.FirstName + " "+ emp.Person.LastName;
        }

        public IQueryable<Employee> GetUserByKeyword(string keyword)
        {
            return Entities.Employees.Where(u =>
                u.Username.ToLower().Contains(keyword.ToLower()) ||
                u.Person.FirstName.ToLower().Contains(keyword.ToLower()) ||
                u.Person.LastName.ToLower().Contains(keyword.ToLower())
            );
        }

        public IQueryable<Employee> GetWorkerEmails()
        {
            return Entities.Employees;
        }



    }
}
