using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataLayer
{
    public class PatientsHandler: ConnectionClass
    {
        public PatientsHandler() : base() { }

        /// <summary>
        /// Returns all users/
        /// </summary>
        /// <returns>All users</returns>
        public IQueryable<Patient> GetPatients()
        {
            return this.Entities.Patients;
        }

        /// <summary>
        /// Use in Api Getting patients by search
        /// </summary>
        /// <returns></returns>
        /// 
        public IQueryable<Patient> GetPatients(int fileNumber, string govId, string name, string surname, Guid fileStatus, Guid KeyWorker)
        {
            IQueryable<Patient> patients = null;

            if (KeyWorker != Guid.Empty)
            {
                patients = from p in this.GetPatients()
                           join pe in this.GetPatientEmployees() on p.FileNumber equals pe.PatientFileNumber_fk
                           where pe.EmployeeId_fk == KeyWorker

                           select p;
            }
            else
            {
                patients = from p in this.GetPatients() select p;
            }

            if (fileNumber != 0)
            {
                patients = patients.Where(s => s.FileNumber == fileNumber);

            }
            if (govId != "")
            {
                patients = patients.Where(s => s.Person.IdCardNumber.Contains(govId));

            }
            if (name != "")
            {
                patients = patients.Where(s => s.Person.FirstName.Contains(name));

            }
            if (surname != "")
            {
                patients = patients.Where(s => s.Person.LastName.Contains(surname));

            }
            if (fileStatus != Guid.Empty)
            {
                patients = patients.Where(s => s.FileStatus_fk == fileStatus);

            }

            return (patients);
        }

        public IQueryable<Common.PatientsEmployee> GetPatientEmployees()
        {//system.collections.generic.list

            //return this.Entities.PatientsEmployees.Where(p => p.EmployeeId_fk==KeyWorker && p.PatientFileNumber_fk==fileNumber);
            var result = from pe in this.Entities.PatientsEmployees
                         group pe by pe.PatientFileNumber_fk into g

                         select g.OrderByDescending(r => r.PatientDate).FirstOrDefault();
            return (result);
        }

        /// <summary>
        /// Returns all users/
        /// </summary>
        /// <returns>All users</returns>
        public int GetPatientsCount()
        {
            return this.Entities.Patients.Count();
        }
        /// <summary>
        /// Gets a user for a specific id passed.
        /// </summary>
        /// <param name="PatientId">Id for which user will be returned.</param>
        /// <returns>One single user matching the id passed.</returns>
        public Common.Patient GetPatient(int PatientId)
        {
            return this.Entities.Patients.SingleOrDefault(p => p.FileNumber.Equals(PatientId));
        }
        public IQueryable<Common.Person> GetPersons(string id)
        {
            return this.Entities.Persons.Where(p => p.IdCardNumber == id);
        }
        public Common.Person GetPerson(string id)
        {
            return this.Entities.Persons.SingleOrDefault(p => p.IdCardNumber == id);
        }
        public Common.Person GetPerson(Guid? id)
        {
            return this.Entities.Persons.SingleOrDefault(p => p.PersonID == id);
        }
        public Common.Patient GetPatient(Guid PersonId)
        {
            return this.Entities.Patients.SingleOrDefault(p => p.Personfk.Equals(PersonId));
        }
        public Common.FamilySocial GetFamilySocial(int patientId)
        {
            return this.Entities.FamilySocials.SingleOrDefault(fs => fs.PatientId_fk == patientId);
        }
        public Common.Medication GetMedication(int patientId)
        {
            return this.Entities.Medications.SingleOrDefault(m => m.PatientId_fk == patientId);
        }
        public Common.AllergiesSpiritual GetAllergiesSpiritual(int patientId)
        {
            return this.Entities.AllergiesSpirituals.SingleOrDefault(alsp => alsp.PatientId_fk == patientId);
        }
        public Common.IllnessesMedical GetIllnessesMedical(int patientId)
        {
            return this.Entities.IllnessesMedicals.SingleOrDefault(im => im.PatientId_fk == patientId);
        }
        public Common.NextOfKin GetNextOfKin(int patientId)
        {
            return this.Entities.NextOfKins.SingleOrDefault(nok => nok.PatientId_fk == patientId);
        }
        public Common.CaseConferance GetCaseConferance(int patientId)
        {
            return this.Entities.CaseConferances.SingleOrDefault(cc => cc.PatientId_fk == patientId);
        }
        public Common.Equipment GetEquipment(int patientId)
        {
            return this.Entities.Equipments.SingleOrDefault(cc => cc.PatientId_fk == patientId);
        }



        /// <summary>
        /// Adds a new to the database.
        /// </summary>
        /// <param name="Patient">user instance to be added.</param>
        public void AddPatient(Common.Patient Patient)
        {
            this.Entities.Patients.Add(Patient);
            this.Entities.SaveChanges();
        }
        /// <summary>
        /// Adds a new to the database.
        /// </summary>
        /// <param name="Patient">user instance to be added.</param>
        public void AddPerson(Common.Person Person)
        {
            this.Entities.Persons.Add(Person);
            this.Entities.SaveChanges();
        }
        public void AddFamilySocial(Common.FamilySocial familySocial)
        {
            this.Entities.FamilySocials.Add(familySocial);
            this.Entities.SaveChanges();
        }
        public void AddPatientIncome(Common.PatientsIncome patientsIncome)
        {
            this.Entities.PatientsIncomes.Add(patientsIncome);
            this.Entities.SaveChanges();
        }
        public void AddMedication(Common.Medication medication)
        {
            this.Entities.Medications.Add(medication);
            this.Entities.SaveChanges();
        }
        public void AddAllergiesSpiritual(Common.AllergiesSpiritual allergiesSpiritual)
        {
            this.Entities.AllergiesSpirituals.Add(allergiesSpiritual);
            this.Entities.SaveChanges();
        }
        public void AddIllnessesMedical(Common.IllnessesMedical illnessesMedical)
        {
            this.Entities.IllnessesMedicals.Add(illnessesMedical);
            this.Entities.SaveChanges();
        }
        public void AddNextOfKin(Common.NextOfKin nextOfKin)
        {
            this.Entities.NextOfKins.Add(nextOfKin);
            this.Entities.SaveChanges();
        }
        public void AddCaseConferance(Common.CaseConferance caseConferance)
        {
            this.Entities.CaseConferances.Add(caseConferance);
            this.Entities.SaveChanges();
        }
        public void AddEquipment(Common.Equipment equipment)
        {
            this.Entities.Equipments.Add(equipment);
            this.Entities.SaveChanges();
        }
        public void AddDoctor(Common.Doctor doctor)
        {
            this.Entities.Doctors.Add(doctor);
            this.Entities.SaveChanges();
        }

        public void AddDiagnosis(Common.DiagnosisPatient diagnosis)
        {
            this.Entities.DiagnosisPatients.Add(diagnosis);
            this.Entities.SaveChanges();
        }
        public void AddKeyWorker(Common.PatientsEmployee employee)
        {
            this.Entities.PatientsEmployees.Add(employee);
            this.Entities.SaveChanges();
        }
        public void AddStreet(Common.Street street)
        {
            this.Entities.Streets.Add(street);
            this.Entities.SaveChanges();
        }
        public void AddProperty(Common.Property property)
        {
            this.Entities.Properties.Add(property);
            this.Entities.SaveChanges();
        }

        public void UpdatePatient(Common.Patient patient)
        {
            Common.Patient ExistingUser = this.GetPatient(patient.FileNumber);
            this.Entities.Entry(ExistingUser).CurrentValues.SetValues(patient);
            this.Entities.SaveChanges();
        }


        public IQueryable<Common.Gender> GetGenders()
        {
            return this.Entities.Genders;
        }
        public IQueryable<Common.Income> GetIncomes()
        {
            return this.Entities.Incomes;
        }
        public IQueryable<Common.Title> GetTitles()
        {
            return this.Entities.Titles;
        }
        public IQueryable<Common.Island> GetIslands()
        {
            return this.Entities.Islands;
        }
        public IQueryable<Common.Locality> GetLocalities(Guid id)
        {
            return this.Entities.Localities.Where(l => l.Island_fk == id);
        }
        public IQueryable<Common.Locality> GetLocalities()
        {
            return this.Entities.Localities;
        }
        public IQueryable<Common.Street> GetStreets(Guid id)
        {
            return this.Entities.Streets.Where(s => s.Locality_fk == id);
        }
        public IQueryable<Common.Street> GetStreets()
        {
            return this.Entities.Streets;
        }

        public IQueryable<Common.Property> GetProperties(Guid id)
        {
            return this.Entities.Properties.Where(s => s.Street_fk == id);
        }
        public IQueryable<Common.Property> GetProperties()
        {
            return this.Entities.Properties;
        }

        public IQueryable<Common.OriginOfReferral> GetOriginOfReferrals(Guid id)
        {
            return this.Entities.OriginOfReferrals.Where(oor => oor.OriginOfReferralId == id);
        }
        public IQueryable<Common.OriginOfReferral> GetOriginOfReferrals()
        {
            return this.Entities.OriginOfReferrals;
        }

        public IQueryable<Common.DiagnosisPatient> GetDiagnosis(Guid id)
        {
            return this.Entities.DiagnosisPatients.Where(oor => oor.DiagnosisId == id);
        }
        public IQueryable<Common.DiagnosisType> GetDiagnosisType()
        {
            return this.Entities.DiagnosisTypes;
        }
        public IQueryable<Common.RelativeAwareness> GetRelativeAwareness()
        {
            return this.Entities.RelativeAwarenesses;
        }
        public IQueryable<Common.PatientAwareness> GetPatientAwareness()
        {
            return this.Entities.PatientAwarenesses;
        }
        public IQueryable<Common.DeceasedPlace> GetDeceasedPlaces()
        {
            return this.Entities.DeceasedPlaces;
        }
        public IQueryable<Common.FileStatus> GetFileStatuses()
        {
            return this.Entities.FileStatuses;
        }

        public IQueryable<Common.PatientStatus> GetPatientStatuses()
        {
            return this.Entities.PatientStatuses;
        }
        public IQueryable<Common.Occupation> GetOccupations()
        {
            return this.Entities.Occupations;
        }
        public IQueryable<Common.Accommodation> GetAccommodations()
        {
            return this.Entities.Accommodations;
        }
        public IQueryable<Common.MedicalType> GetMedicalTypes()
        {
            return this.Entities.MedicalTypes;
        }
        public IQueryable<Common.Relation> GetRelations()
        {
            return this.Entities.Relations;
        }
        public IQueryable<Common.EquipmentType> GetEquipmentTypes()
        {
            return this.Entities.EquipmentTypes;
        }

        public DoctorType GetDoctorTypes(string DoctorTypeName)
        {
            return this.Entities.DoctorTypes.SingleOrDefault(d => d.DoctorTypeName == DoctorTypeName);
        }

        public IQueryable<Common.Doctor> GetDoctors(Guid DoctorTypeId)
        {
            return this.Entities.Doctors.Where(d => d.DoctorType_FK == DoctorTypeId);
        }
        public Doctor GetDoctor(Guid? DoctorId)
        {
            return this.Entities.Doctors.SingleOrDefault(d => d.DoctorID == DoctorId);
        }
        public IQueryable<Common.Doctor> GetDoctor()
        {
            return this.Entities.Doctors;
        }
    }
}
