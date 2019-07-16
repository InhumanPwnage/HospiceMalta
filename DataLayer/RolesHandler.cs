using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class RolesHandler : ConnectionClass
    {
        public RolesHandler() : base() { }
        public RolesHandler(Common.HospiceSysEntities Entities) : base(Entities) { }

        public IQueryable<Role> GetRoles()
        {
            return this.Entities.Roles;
        }

        public IQueryable<Role> GetUserRoles(Guid UserId)
        {
            return (from users in this.Entities.Employees
                    from roles in users.Roles
                    where users.EmployeesId == UserId
                    select roles);
        }

        public IQueryable<Role> GetUserRoles(string username)
        {
            return (from users in this.Entities.Employees
                    from roles in users.Roles
                    where users.Username == username
                    select roles);
        }

        public Role GetRole(string RoleCode)
        {
            return this.Entities.Roles.FirstOrDefault(p => p.RoleCode == RoleCode);
        }

        public IQueryable<Common.Employee> GetEmployeesinRole(String RoleId)
        {
            return (from emp in this.Entities.Employees
                    from roles in emp.Roles
                    where roles.RoleCode == RoleId
                    select emp);
        }

    }
}
