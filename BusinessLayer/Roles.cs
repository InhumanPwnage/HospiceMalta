using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataLayer;

namespace BusinessLayer
{
    public class Roles : BLBase
    {
        public Roles() : base() { }
        public Roles(HospiceSysEntities Entities) : base(Entities) { }

        public IQueryable<Role> GetUserRoles(Guid gud)
        {
            return new RolesHandler(this.Entities).GetUserRoles(gud);
        }

        public IQueryable<Role> GetUserRoles(string username)
        {
            return new RolesHandler(this.Entities).GetUserRoles(username);
        }

        public string GetRoleName(Guid userid)
        {
            List<Role> roles = GetUserRoles(userid).ToList();
            Role r = roles.FirstOrDefault();
            return r.RoleId;
        }

        public IQueryable<Employee> GetEmployeeWithRole(string Role)
        {
            return new DataLayer.RolesHandler(this.Entities).GetEmployeesinRole(Role);

        }
    }
}
