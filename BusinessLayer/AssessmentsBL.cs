using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DataLayer;

namespace BusinessLayer
{
    public class AssessmentsBL
    {
        public IQueryable<Assessment> GetAssessments()
        {
            return new AssessmentsHandler().GetAssessments();
        }

        public IQueryable<AssessmentType> GetAssessmentTypes()
        {
            return new AssessmentsHandler().GetAssessmentTypes();
        }

        public IQueryable<AssessmentOrigin> GetAssessmentOrigins()
        {
            return new AssessmentsHandler().GetAssessmentOrigins();
        }

        public IQueryable<Employee> GetAssessmentWorkers()
        {
            return new AssessmentsHandler().GetAssessmentWorkers();
        }

        public void AddAssessment(Common.Assessment ass)
        {
            new AssessmentsHandler().AddAssessment(ass);
        }


        public Assessment GetAssessment(Guid assid)
        {
            return new AssessmentsHandler().GetAssessment(assid);
        }

        public IQueryable<Assessment> GetAssessmentsOfPatient(int patid)
        {
            return new AssessmentsHandler().GetAssessmentsOfPatient(patid);
        }

        public void UpdateAssessment(Assessment a)
        {
            new AssessmentsHandler().UpdateAssessment(a);
        }
    }
}
