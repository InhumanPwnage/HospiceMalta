using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Net.Mail;

namespace BusinessLayer
{
    public class PatientsBL
    {
        /// <summary>
        /// Returns all users/
        /// </summary>
        /// <returns>All users</returns>
        public IQueryable<Patient> GetPatients()
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetPatients();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public bool ValidRegister(string fileNum, string DOFC, string email, string DOB, string DOD, string DecD)
        {
            bool check = false;
            int fNum = 0;
            DateTime firstContact = new DateTime(1, 1, 1);
            DateTime birthday = new DateTime(1, 1, 1);

            DateTime diagnosisDate = new DateTime(1, 1, 1);
            DateTime decDate = new DateTime(1, 1, 1);
            bool messageMain = true;
            bool messageEmail = true;
            bool messageDateofBirth = true;
            bool messageDecDate = true;
            bool messageDiagnosisDate = true;

            if (DOD != "")
            {
                diagnosisDate = Convert.ToDateTime(DOD);
            }
            if (DecD != "")
            {
                decDate = Convert.ToDateTime(DecD);
            }
            if (fileNum != "")
            {
                fNum = Convert.ToInt32(fileNum);
            }
            if (DOFC != "")
            {
                firstContact = Convert.ToDateTime(DOFC);
            }
            if (DOB != "")
            {
                birthday = Convert.ToDateTime(DOB);
            }
            if (fNum < 0 || !IsValidSqlDatetime(firstContact.ToString()) || firstContact.ToString() == "01/01/0001 00:00:00")
            {
                messageMain = false;

            }
            if (email != "")
            {
                if (!IsValidEamil(email))
                {
                    messageEmail = false;

                }
            }
            if (birthday.ToString() != "01/01/0001 00:00:00")
            {
                if (birthday > DateTime.Today || birthday >= firstContact || !IsValidSqlDatetime(birthday.ToString()))
                {
                    messageDateofBirth = false;

                }
            }
            if (decDate.ToString() != "01/01/0001 00:00:00")
            {
                if (decDate >= firstContact || !IsValidSqlDatetime(decDate.ToString()))
                {
                    messageDecDate = false;

                }
            }
            if (diagnosisDate.ToString() != "01/01/0001 00:00:00")
            {
                if (!IsValidSqlDatetime(diagnosisDate.ToString()))
                {
                    messageDiagnosisDate = false;

                }
            }

            if (messageDateofBirth == true && messageMain == true && messageEmail == true && messageDecDate == true && messageDiagnosisDate == true)
            {
                check = true;
            }
            return check;
        }

        static bool IsValidSqlDatetime(string someval)
        {
            bool valid = false;
            DateTime testDate = DateTime.MinValue;
            DateTime minDateTime = DateTime.MaxValue;
            DateTime maxDateTime = DateTime.MinValue;

            minDateTime = new DateTime(1753, 1, 1);
            maxDateTime = new DateTime(9999, 12, 31, 23, 59, 59, 997);

            if (DateTime.TryParse(someval, out testDate))
            {
                if (testDate >= minDateTime && testDate <= maxDateTime)
                {
                    valid = true;
                }
            }

            return valid;
        }


        public bool IsValidEamil(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        public IQueryable<Common.Patient> GetPatients(int fileNumber, string govId, string name, string surname, Guid fileStatus, Guid KeyWorker)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();

            return dapatient.GetPatients(fileNumber, govId, name, surname, fileStatus, KeyWorker);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        /// <summary>
        /// Gets a user for a specific id passed.
        /// </summary>
        /// <param name="PatientId">Id for which user will be returned.</param>
        /// <returns>One single user matching the id passed.</returns>
        public Common.Patient GetPatient(int PatientId)
        {
            return new DataLayer.PatientsHandler().GetPatient(PatientId);

        }

        /// <summary>
        /// Gets a user for a specific id passed.
        /// </summary>
        /// <param name="patientEmail">Id for which user will be returned.</param>
        /// <returns>One single user matching the id passed.</returns>
        public Common.Patient GetPatient(Guid PersonId)
        {
            return new DataLayer.PatientsHandler().GetPatient(PersonId);

        }

        /// <summary>
        /// Adds a new to the database.
        /// </summary>
        /// <param name="User">user instance to be added.</param>
        private void AddPatientToDatabase(Common.Patient Patient)
        {

            new DataLayer.PatientsHandler().AddPatient(Patient);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="User">User to be added.</param>
        public void RegisterPatient(Common.Patient patient)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();

            if (CheckRegister(patient))
            {
                this.AddPatientToDatabase(patient);
            }


        }

        public Boolean CheckRegister(Common.Patient patient)
        {
            Common.Patient p = this.GetPatient(patient.FileNumber);
            if (p == null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public void UpdatePatient(Common.Patient patient)
        {
            new DataLayer.PatientsHandler().UpdatePatient(patient);
        }
        /// <summary>
        /// Gets a user for a specific id passed.
        /// </summary>
        /// <param name="PatientId">Id for which user will be returned.</param>
        /// <returns>One single user matching the id passed.</returns>
        public Common.Person GetPerson(string PersonId)
        {
            return new DataLayer.PatientsHandler().GetPerson(PersonId);

        }

        public Common.Person GetPerson(Guid? PersonId)
        {
            return new DataLayer.PatientsHandler().GetPerson(PersonId);

        }

        private void AddFamilySocialToDatabase(Common.FamilySocial familySocial)
        {

            new DataLayer.PatientsHandler().AddFamilySocial(familySocial);
        }

        private void AddPatientIncomeToDatabase(Common.PatientsIncome patientIncome)
        {

            new DataLayer.PatientsHandler().AddPatientIncome(patientIncome);
        }

        public void AddFamilySocial(Common.FamilySocial fs)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();

            fs.FamilySocialId = Guid.NewGuid();

            this.AddFamilySocialToDatabase(fs);


        }
        public void AddIncome(string incomeItems, Guid fsId)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            Common.PatientsIncome pi = new Common.PatientsIncome();

            pi.IncomeIdFk = new Guid(incomeItems);
            pi.FamilySocialIdFk = fsId;
            pi.LogDate = DateTime.Now;
            this.AddPatientIncomeToDatabase(pi);






        }

        private void AddMedicationToDatabase(Common.Medication medication)
        {

            new DataLayer.PatientsHandler().AddMedication(medication);
        }

        public void AddMedication(Common.Medication m)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            m.MedicationId = Guid.NewGuid();
            this.AddMedicationToDatabase(m);


        }
        private void AddAllergiesSpiritualToDatabase(Common.AllergiesSpiritual allergiesSpiritual)
        {

            new DataLayer.PatientsHandler().AddAllergiesSpiritual(allergiesSpiritual);
        }
        public void AddAllergiesSpiritual(Common.AllergiesSpiritual allSpi)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            allSpi.AllergiesSpiritualId = Guid.NewGuid();
            this.AddAllergiesSpiritualToDatabase(allSpi);
        }
        private void AddIllnessesMedicalToDatabase(Common.IllnessesMedical illnessesMedical)
        {

            new DataLayer.PatientsHandler().AddIllnessesMedical(illnessesMedical);
        }
        public void AddIllnessesMedical(Common.IllnessesMedical im)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            im.IllnessesMedicalId = Guid.NewGuid();
            this.AddIllnessesMedicalToDatabase(im);
        }
        private void AddNextOfKinToDatabase(Common.NextOfKin nextOfKin)
        {

            new DataLayer.PatientsHandler().AddNextOfKin(nextOfKin);
        }
        public void AddNextOfKin(Common.NextOfKin nok)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            nok.NextOfKinId = Guid.NewGuid();
            this.AddNextOfKinToDatabase(nok);
        }
        private void AddCaseConferanceToDatabase(Common.CaseConferance caseConferance)
        {

            new DataLayer.PatientsHandler().AddCaseConferance(caseConferance);
        }
        public void AddCaseConferance(Common.CaseConferance cc)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            cc.CaseConferanceId = Guid.NewGuid();
            this.AddCaseConferanceToDatabase(cc);
        }
        private void AddEquipmentToDatabase(Common.Equipment equipment)
        {

            new DataLayer.PatientsHandler().AddEquipment(equipment);
        }
        private void AddDoctorToDatabase(Common.Doctor doctor)
        {

            new DataLayer.PatientsHandler().AddDoctor(doctor);
        }
        private void AddDiagnosisToDatabase(Common.DiagnosisPatient diagnosis)
        {

            new DataLayer.PatientsHandler().AddDiagnosis(diagnosis);
        }

        private void AddKeyWorkerToDatabase(Common.PatientsEmployee employee)
        {

            new DataLayer.PatientsHandler().AddKeyWorker(employee);
        }
        public void AddEquipment(Common.Equipment e)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            e.EquipmentId = Guid.NewGuid();
            this.AddEquipmentToDatabase(e);
        }

        public void AddDoctor(Common.Doctor doctor, string txtCon, string txtOnc, string txtFD, Guid? ddCon, Guid? ddFD, Guid? ddOnc)
        {
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            BusinessLayer.UsersBL emp = new UsersBL();
            int tempPId = (int)doctor.PatientId_FK;
            Common.Patient pat = new Common.Patient();
            if (txtOnc != "" || ddOnc != null)
            {
                if (txtOnc != "")
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("Oncologist").DoctorTypeId;
                    d.DoctorName = txtOnc;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.Oncologist_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
                else
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("Oncologist").DoctorTypeId;
                    d.DEmployeeId_FK = ddOnc;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.Oncologist_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
            }
            if (txtCon != "" || ddCon != null)
            {
                if (txtCon != "")
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("Consultant").DoctorTypeId;
                    d.DoctorName = txtCon;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.Consultant_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
                else
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("Consultant").DoctorTypeId;
                    d.DEmployeeId_FK = ddCon;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.Consultant_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
            }
            if (txtFD != "" || ddFD != null)
            {
                if (txtFD != "")
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("FamilyDoctor").DoctorTypeId;
                    d.DoctorName = txtFD;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.FamilyDoctor_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
                else
                {
                    Common.Doctor d = new Common.Doctor();
                    d.PatientId_FK = tempPId;
                    d.DoctorType_FK = emp.GetDoctorType("FamilyDoctor").DoctorTypeId;
                    d.DEmployeeId_FK = ddFD;
                    d.DoctorDate = DateTime.Today;
                    d.DoctorID = Guid.NewGuid();
                    this.AddDoctorToDatabase(d);

                    pat = GetPatient((int)d.PatientId_FK);
                    pat.FamilyDoctor_fk = d.DoctorID;
                    this.UpdatePatient(pat);
                }
            }

        }

        public void AddDiagnosis(Common.DiagnosisPatient diagnosis)
        {
            Common.Patient pat = new Common.Patient();
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
            diagnosis.DiagnosisId = Guid.NewGuid();
            diagnosis.LogDate = DateTime.Today;
            this.AddDiagnosisToDatabase(diagnosis);

            pat = GetPatient(diagnosis.PatientId_fk);
            pat.Diagnosis_fk = diagnosis.DiagnosisId;
            this.UpdatePatient(pat);
        }

        public void AddKeyWorker(Common.PatientsEmployee employee)
        {
            Common.Patient pat = new Common.Patient();
            DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();

            employee.PatientDate = DateTime.Today;
            this.AddKeyWorkerToDatabase(employee);
        }

        /// <summary>
        /// Adds a new to the database.
        /// </summary>
        /// <param name="User">user instance to be added.</param>
        private void AddPersonToDatabase(Common.Person Person)
        {

            new DataLayer.PatientsHandler().AddPerson(Person);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="User">User to be added.</param>
        public void RegisterPerson(Common.Person Person, string street, string property, Guid? ddLocality, Guid? ddStreet)
        {
            if (Person.IdCardNumber != null)
            {
                if (CheckRegister(Person.IdCardNumber))
                {
                    if (Person.Gender_fk == "None")
                    {
                        Person.Gender_fk = null;
                    }
                    Person.PersonID = Guid.NewGuid();
                    DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
                    if (property == "")
                    {


                        this.AddPersonToDatabase(Person);

                    }
                    else
                    {
                        if (street == "")
                        {

                            Common.Property p = new Common.Property();
                            p.PropertyName = property;
                            p.Street_fk = ddStreet;
                            p.PropertyId = Guid.NewGuid();
                            dap.AddProperty(p);
                            Person.Property_fk = p.PropertyId;
                            this.AddPersonToDatabase(Person);
                        }
                        else
                        {

                            Common.Street s = new Common.Street();
                            s.StreetName = street;
                            s.Locality_fk = ddLocality;
                            s.StreetId = Guid.NewGuid();
                            dap.AddStreet(s);

                            Common.Property p = new Common.Property();
                            p.PropertyName = property;
                            p.Street_fk = s.StreetId;
                            p.PropertyId = Guid.NewGuid();
                            dap.AddProperty(p);
                            Person.Property_fk = p.PropertyId;
                            this.AddPersonToDatabase(Person);
                        }
                    }
                }
            }
            else
            {
                if (Person.Gender_fk == "None")
                {
                    Person.Gender_fk = null;
                }
                Person.PersonID = Guid.NewGuid();
                DataLayer.PatientsHandler dap = new DataLayer.PatientsHandler();
                if (property == "")
                {


                    this.AddPersonToDatabase(Person);

                }
                else
                {
                    if (street == "")
                    {

                        Common.Property p = new Common.Property();
                        p.PropertyName = property;
                        p.Street_fk = ddStreet;
                        p.PropertyId = Guid.NewGuid();
                        dap.AddProperty(p);
                        Person.Property_fk = p.PropertyId;
                        this.AddPersonToDatabase(Person);
                    }
                    else
                    {

                        Common.Street s = new Common.Street();
                        s.StreetName = street;
                        s.Locality_fk = ddLocality;
                        s.StreetId = Guid.NewGuid();
                        dap.AddStreet(s);

                        Common.Property p = new Common.Property();
                        p.PropertyName = property;
                        p.Street_fk = s.StreetId;
                        p.PropertyId = Guid.NewGuid();
                        dap.AddProperty(p);
                        Person.Property_fk = p.PropertyId;
                        this.AddPersonToDatabase(Person);
                    }
                }
            }


        }
        public Common.FamilySocial GetFamilySocial(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetFamilySocial(id);

        }
        public Common.Medication GetMedication(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetMedication(id);

        }
        public Common.AllergiesSpiritual GetAllergiesSpiritual(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetAllergiesSpiritual(id);

        }

        public Common.IllnessesMedical GetIllnessesMedical(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetIllnessesMedical(id);

        }

        public Common.NextOfKin GetNextOfKin(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetNextOfKin(id);

        }

        public Common.CaseConferance GetCaseConferance(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetCaseConferance(id);

        }

        public Common.Equipment GetEquipment(int id)
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();
            return dapatient.GetEquipment(id);

        }

        public Boolean CheckRegister(string idCardNumber)
        {
            Common.Person p = this.GetPerson(idCardNumber);
            if (p == null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        public IQueryable<Common.PatientsEmployee> PatientsEmployees()
        {
            DataLayer.PatientsHandler dapatient = new DataLayer.PatientsHandler();

            return dapatient.GetPatientEmployees();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.Title> GetTitles()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetTitles();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Income> GetIncomes()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetIncomes();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Gender> GetGenders()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetGenders();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Island> GetIslands()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetIslands();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.Locality> GetLocalities()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetLocalities();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Locality> GetLocalities(Guid id)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetLocalities(id);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Street> GetStreets()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetStreets();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Street> GetStreets(Guid id)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetStreets(id);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.Property> GetProperties()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetProperties();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Property> GetProperties(Guid id)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetProperties(id);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.OriginOfReferral> GetOriginOfReferrals(Guid id)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetOriginOfReferrals(id);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.OriginOfReferral> GetOriginOfReferrals()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetOriginOfReferrals();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.DiagnosisPatient> GetDiagnosis(Guid id)
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDiagnosis(id);

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.DiagnosisType> GetDiagnosisType()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDiagnosisType();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }


        public IQueryable<Common.RelativeAwareness> GetRelativeAwareness()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetRelativeAwareness();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.PatientAwareness> GetPatientAwareness()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetPatientAwareness();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.DeceasedPlace> GetDeceasedPlaces()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetDeceasedPlaces();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.FileStatus> GetFileStatuses()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetFileStatuses();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.PatientStatus> GetPatientStatuses()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetPatientStatuses();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Occupation> GetOccupations()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetOccupations();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.Accommodation> GetAccommodations()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetAccommodations();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }

        public IQueryable<Common.MedicalType> GetMedicalTypes()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetMedicalTypes();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.Relation> GetRelations()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetRelations();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
        public IQueryable<Common.EquipmentType> GetEquipmentTypes()
        {
            DataLayer.PatientsHandler dapat = new DataLayer.PatientsHandler();
            return dapat.GetEquipmentTypes();

            //2nd method which does the same thing
            //return new DataLayer.DAUsers().GetUsers();
        }
    }
}
