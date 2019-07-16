using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class CarePlanHandler : ConnectionClass
    {
        public CarePlanHandler() : base() { }

        public IQueryable<CarePlan> GetCarePlans()
        {
            return Entities.CarePlans;
        }

        public IQueryable<CarePlanType> GetCarePlanTypes()
        {
            return Entities.CarePlanTypes;
        }

        public IQueryable<CarePlanStatus> GetCarePlanStatuses()
        {
            return Entities.CarePlanStatuses;
        }

        public void AddCarePlan(Common.CarePlan cp)
        {
            this.Entities.CarePlans.Add(cp);
            this.Entities.SaveChanges();
        }


        //load assessment on page
        public CarePlan GetCarePlan(Guid cpid)
        {
            return this.Entities.CarePlans.FirstOrDefault(carep => carep.CarePlanID == cpid);
        }

        //get particular assessments
        public IQueryable<CarePlan> GetCarePlansOfPatient(int patid)
        {
            return this.Entities.CarePlans.Where(u => u.PatientId_fk == patid);
        }

        public void UpdateCarePlan(CarePlan cp)
        {
            CarePlan ExistingCarePlan = this.GetCarePlan(cp.CarePlanID);

            Entities.Entry(ExistingCarePlan).CurrentValues.SetValues(cp);
            Entities.SaveChanges();
        }
    }
}
