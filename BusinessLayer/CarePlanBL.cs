using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataLayer;

namespace BusinessLayer
{
    public class CarePlanBL
    {
        public IQueryable<CarePlan> GetCarePlans()
        {
            return new CarePlanHandler().GetCarePlans();
        }

        public IQueryable<CarePlanType> GetCarePlanTypes()
        {
            return new CarePlanHandler().GetCarePlanTypes();
        }

        public IQueryable<CarePlanStatus> GetCarePlanStatuses()
        {
            return new CarePlanHandler().GetCarePlanStatuses();
        }

        public void AddCarePlan(CarePlan cp)
        {
            new DataLayer.CarePlanHandler().AddCarePlan(cp);
        }


        public CarePlan GetCarePlan(Guid cpid)
        {
            return new CarePlanHandler().GetCarePlan(cpid);
        }

        public IQueryable<CarePlan> GetCarePlansOfPatient(int patid)
        {
            return new CarePlanHandler().GetCarePlansOfPatient(patid);
        }

        public void UpdateCarePlan(CarePlan cp)
        {
            new CarePlanHandler().UpdateCarePlan(cp);
        }
    }
}
