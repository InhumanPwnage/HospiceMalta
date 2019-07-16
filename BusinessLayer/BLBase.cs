using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLBase
    {
        public Common.HospiceSysEntities Entities { get; set; }

        public BLBase()
        {
            this.Entities = new Common.HospiceSysEntities();
        }

        public BLBase(Common.HospiceSysEntities Entity)
        {
            this.Entities = Entity;
        }
    }
}
