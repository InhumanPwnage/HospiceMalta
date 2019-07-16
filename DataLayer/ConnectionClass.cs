using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ConnectionClass
    {
        public Common.HospiceSysEntities Entities { get; set; }

        public ConnectionClass()
        {
            this.Entities = new Common.HospiceSysEntities();
        }

        public ConnectionClass(Common.HospiceSysEntities Entity)
        {
            this.Entities = Entity;
        }
    }
}
