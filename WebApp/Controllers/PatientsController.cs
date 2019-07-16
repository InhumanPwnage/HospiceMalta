using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class PatientsController : Controller
    {
        // GET: Patients
        public ActionResult Index()
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            List<SelectListItem> GenderList = (from gender
                                             in patient.GetGenders().ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = gender.GenderName,
                                                   Value = gender.GenderId.ToString()

                                               }).ToList();
            ViewBag.Gender = GenderList;

            List<SelectListItem> TitleList = (from title
                                             in patient.GetTitles().ToList()
                                              select new SelectListItem()
                                              {
                                                  Text = title.TitleName,
                                                  Value = title.TitleId.ToString()

                                              }).ToList();
            ViewBag.Titles = TitleList;


            List<SelectListItem> IslandList = (from island
                                          in patient.GetIslands().ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = island.IslandName,
                                                   Value = island.IslandId.ToString()

                                               }).ToList();
            ViewBag.Island = IslandList;
            List<SelectListItem> tempList = new List<SelectListItem>();
            ViewBag.Locality = tempList;

            BusinessLayer.Roles role = new BusinessLayer.Roles();
            List<SelectListItem> WorkerList = (from worker
                                          in role.GetEmployeeWithRole("DOC").ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = worker.Person.FirstName + " " + worker.Person.LastName,
                                                   Value = worker.EmployeesId.ToString()

                                               }).ToList();
            ViewBag.KeyWorkers = WorkerList;

            List<SelectListItem> OriginOfReferralList = (from originOfReferral
                                          in patient.GetOriginOfReferrals().ToList()
                                                         select new SelectListItem()
                                                         {
                                                             Text = originOfReferral.OriginOfReferralName,
                                                             Value = originOfReferral.OriginOfReferralId.ToString()

                                                         }).ToList();
            ViewBag.OriginOfReferral = OriginOfReferralList;

            List<SelectListItem> DiagnosisList = (from diagnosis
                                          in patient.GetDiagnosisType().ToList()
                                                  select new SelectListItem()
                                                  {
                                                      Text = diagnosis.DiagnosisName,
                                                      Value = diagnosis.DiagnosisId.ToString()

                                                  }).ToList();
            ViewBag.Diagnosis = DiagnosisList;


            List<SelectListItem> RelativesAwareList = (from rAware
                                          in patient.GetRelativeAwareness().ToList()
                                                       select new SelectListItem()
                                                       {
                                                           Text = rAware.RelativeAwareName,
                                                           Value = rAware.RelativeAwareId.ToString()

                                                       }).ToList();
            ViewBag.RAware = RelativesAwareList;

            List<SelectListItem> PatientsAwareList = (from pAware
                                          in patient.GetPatientAwareness().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = pAware.PatientAwareName,
                                                          Value = pAware.PatientAwareId.ToString()

                                                      }).ToList();
            ViewBag.PAware = PatientsAwareList;

            List<SelectListItem> DecPlaceList = (from decPlace
                                          in patient.GetDeceasedPlaces().ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = decPlace.DeceasedPlaceName,
                                                     Value = decPlace.DeceasedplaceId.ToString()

                                                 }).ToList();
            ViewBag.DecPlace = DecPlaceList;


            List<SelectListItem> FileStatusList = (from fileStatus
                                          in patient.GetFileStatuses().ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = fileStatus.FileStatusName,
                                                       Value = fileStatus.FileStatusId.ToString()

                                                   }).ToList();
            ViewBag.FileStatus = FileStatusList;

            List<SelectListItem> PatientStatusList = (from patientStatus
                                          in patient.GetPatientStatuses().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = patientStatus.PatientStatusName,
                                                          Value = patientStatus.PatientStatusId.ToString()

                                                      }).ToList();
            ViewBag.PatientStatus = PatientStatusList;

            List<SelectListItem> OccupationList = (from occupation
                                           in patient.GetOccupations().ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = occupation.OccupationName,
                                                       Value = occupation.OccupationId.ToString()

                                                   }).ToList();
            ViewBag.Occupation = OccupationList;

            List<SelectListItem> AccomodationList = (from accomodation
                                            in patient.GetAccommodations().ToList()
                                                     select new SelectListItem()
                                                     {
                                                         Text = accomodation.AccommmodationName,
                                                         Value = accomodation.AccommodationId.ToString()

                                                     }).ToList();
            ViewBag.Accomodation = AccomodationList;

            List<SelectListItem> MedicalTypeList = (from mType
                                            in patient.GetMedicalTypes().ToList()
                                                    select new SelectListItem()
                                                    {
                                                        Text = mType.MedicalTypeName,
                                                        Value = mType.MedicalTypeId.ToString()

                                                    }).ToList();
            ViewBag.MedicalType = MedicalTypeList;

            List<SelectListItem> RelationList = (from relation
                                in patient.GetRelations().ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = relation.RelationName,
                                                     Value = relation.RelationId.ToString()

                                                 }).ToList();
            ViewBag.Relation = RelationList;

            List<SelectListItem> EquipmentTypeList = (from equipmentType
                         in patient.GetEquipmentTypes().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = equipmentType.EquipmentTypeName,
                                                          Value = equipmentType.EquipmentTypeId.ToString()

                                                      }).ToList();
            ViewBag.EquipmentType = EquipmentTypeList;

            BusinessLayer.UsersBL employees = new BusinessLayer.UsersBL();


            //This is how to only take unique values from the selected list item :) Not neccessary
            //List<SelectListItem> DoctorList = (from doctor
            // in employees.GetDoctors(employees.GetDoctorType("Consultant").DoctorTypeId).ToList()
            //                                   join emp in employees.GetEmployees() on doctor.EmployeeId equals emp.EmployeesId
            //                                   select new SelectListItem()
            //                                   {
            //                                       Text = emp.Person.FirstName + " " + doctor.Employee.Person.LastName,
            //                                       Value = emp.EmployeesId.ToString()

            //                                   }).ToList();
            //ViewBag.DoctorC = DoctorList.GroupBy(test => test.Value).Select(grp => grp.First()).ToList();
            List<SelectListItem> DoctorList = (from doctor
                                          in role.GetEmployeeWithRole("DOC").ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = doctor.Person.FirstName + " " + doctor.Person.LastName,
                                                   Value = doctor.EmployeesId.ToString()

                                               }).ToList();
            ViewBag.DoctorC = DoctorList;

            List<SelectListItem> FamilyDoctorList = (from familyDoctor
                              in role.GetEmployeeWithRole("DOC").ToList()
                                                     select new SelectListItem()
                                                     {
                                                         Text = familyDoctor.Person.FirstName + " " + familyDoctor.Person.LastName,
                                                         Value = familyDoctor.EmployeesId.ToString()

                                                     }).ToList();
            ViewBag.FamilyDoctor = FamilyDoctorList;

            List<SelectListItem> OncologistList = (from oncologist
                   in role.GetEmployeeWithRole("DOC").ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = oncologist.Person.FirstName + " " + oncologist.Person.LastName,
                                                       Value = oncologist.EmployeesId.ToString()

                                                   }).ToList();
            ViewBag.Oncologist = OncologistList;



            return View();
        }


        [HttpGet]
        public ActionResult PatientEdit(int id)
        {
            //insert dropdowns

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            List<SelectListItem> GenderList = (from gender
                                             in patient.GetGenders().ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = gender.GenderName,
                                                   Value = gender.GenderId.ToString()

                                               }).ToList();
            ViewBag.Gender = GenderList;

            List<SelectListItem> TitleList = (from title
                                             in patient.GetTitles().ToList()
                                              select new SelectListItem()
                                              {
                                                  Text = title.TitleName,
                                                  Value = title.TitleId.ToString()

                                              }).ToList();
            ViewBag.Titles = TitleList;


            List<SelectListItem> IslandList = (from island
                                          in patient.GetIslands().ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = island.IslandName,
                                                   Value = island.IslandId.ToString()

                                               }).ToList();
            ViewBag.Island = IslandList;
            List<SelectListItem> tempList = new List<SelectListItem>();
            ViewBag.Locality = tempList;

            BusinessLayer.Roles role = new BusinessLayer.Roles();
            List<SelectListItem> WorkerList = (from worker
                                          in role.GetEmployeeWithRole("DOC").ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = worker.Person.FirstName + " " + worker.Person.LastName,
                                                   Value = worker.EmployeesId.ToString()

                                               }).ToList();
            ViewBag.KeyWorkers = WorkerList;

            List<SelectListItem> OriginOfReferralList = (from originOfReferral
                                          in patient.GetOriginOfReferrals().ToList()
                                                         select new SelectListItem()
                                                         {
                                                             Text = originOfReferral.OriginOfReferralName,
                                                             Value = originOfReferral.OriginOfReferralId.ToString()

                                                         }).ToList();
            ViewBag.OriginOfReferral = OriginOfReferralList;

            List<SelectListItem> DiagnosisList = (from diagnosis
                                          in patient.GetDiagnosisType().ToList()
                                                  select new SelectListItem()
                                                  {
                                                      Text = diagnosis.DiagnosisName,
                                                      Value = diagnosis.DiagnosisId.ToString()

                                                  }).ToList();
            ViewBag.Diagnosis = DiagnosisList;


            List<SelectListItem> RelativesAwareList = (from rAware
                                          in patient.GetRelativeAwareness().ToList()
                                                       select new SelectListItem()
                                                       {
                                                           Text = rAware.RelativeAwareName,
                                                           Value = rAware.RelativeAwareId.ToString()

                                                       }).ToList();
            ViewBag.RAware = RelativesAwareList;

            List<SelectListItem> PatientsAwareList = (from pAware
                                          in patient.GetPatientAwareness().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = pAware.PatientAwareName,
                                                          Value = pAware.PatientAwareId.ToString()

                                                      }).ToList();
            ViewBag.PAware = PatientsAwareList;

            List<SelectListItem> DecPlaceList = (from decPlace
                                          in patient.GetDeceasedPlaces().ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = decPlace.DeceasedPlaceName,
                                                     Value = decPlace.DeceasedplaceId.ToString()

                                                 }).ToList();
            ViewBag.DecPlace = DecPlaceList;


            List<SelectListItem> FileStatusList = (from fileStatus
                                          in patient.GetFileStatuses().ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = fileStatus.FileStatusName,
                                                       Value = fileStatus.FileStatusId.ToString()

                                                   }).ToList();
            ViewBag.FileStatus = FileStatusList;

            List<SelectListItem> PatientStatusList = (from patientStatus
                                          in patient.GetPatientStatuses().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = patientStatus.PatientStatusName,
                                                          Value = patientStatus.PatientStatusId.ToString()

                                                      }).ToList();
            ViewBag.PatientStatus = PatientStatusList;

            List<SelectListItem> OccupationList = (from occupation
                                           in patient.GetOccupations().ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = occupation.OccupationName,
                                                       Value = occupation.OccupationId.ToString()

                                                   }).ToList();
            ViewBag.Occupation = OccupationList;

            List<SelectListItem> AccomodationList = (from accomodation
                                            in patient.GetAccommodations().ToList()
                                                     select new SelectListItem()
                                                     {
                                                         Text = accomodation.AccommmodationName,
                                                         Value = accomodation.AccommodationId.ToString()

                                                     }).ToList();
            ViewBag.Accomodation = AccomodationList;

            List<SelectListItem> MedicalTypeList = (from mType
                                            in patient.GetMedicalTypes().ToList()
                                                    select new SelectListItem()
                                                    {
                                                        Text = mType.MedicalTypeName,
                                                        Value = mType.MedicalTypeId.ToString()

                                                    }).ToList();
            ViewBag.MedicalType = MedicalTypeList;

            List<SelectListItem> RelationList = (from relation
                                in patient.GetRelations().ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = relation.RelationName,
                                                     Value = relation.RelationId.ToString()

                                                 }).ToList();
            ViewBag.Relation = RelationList;

            List<SelectListItem> EquipmentTypeList = (from equipmentType
                         in patient.GetEquipmentTypes().ToList()
                                                      select new SelectListItem()
                                                      {
                                                          Text = equipmentType.EquipmentTypeName,
                                                          Value = equipmentType.EquipmentTypeId.ToString()

                                                      }).ToList();
            ViewBag.EquipmentType = EquipmentTypeList;

            BusinessLayer.UsersBL employees = new BusinessLayer.UsersBL();


            List<SelectListItem> DoctorList = (from doctor
                                          in role.GetEmployeeWithRole("DOC").ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = doctor.Person.FirstName + " " + doctor.Person.LastName,
                                                   Value = doctor.EmployeesId.ToString()

                                               }).ToList();
            ViewBag.DoctorC = DoctorList;

            List<SelectListItem> FamilyDoctorList = (from familyDoctor
                              in role.GetEmployeeWithRole("DOC").ToList()
                                                     select new SelectListItem()
                                                     {
                                                         Text = familyDoctor.Person.FirstName + " " + familyDoctor.Person.LastName,
                                                         Value = familyDoctor.EmployeesId.ToString()

                                                     }).ToList();
            ViewBag.FamilyDoctor = FamilyDoctorList;

            List<SelectListItem> OncologistList = (from oncologist
                   in role.GetEmployeeWithRole("DOC").ToList()
                                                   select new SelectListItem()
                                                   {
                                                       Text = oncologist.Person.FirstName + " " + oncologist.Person.LastName,
                                                       Value = oncologist.EmployeesId.ToString()

                                                   }).ToList();
            ViewBag.Oncologist = OncologistList;


            Common.Patient CurrPat = patient.GetPatient(id);
            BusinessLayer.PatientsBL p = new BusinessLayer.PatientsBL();
            
            Models.UIModel.PatientModel Model = new Models.UIModel.PatientModel();
            Model.Patient = p.GetPatient(id);
            Model.Person = p.GetPerson(CurrPat.Personfk);
            Model.FamilySocial = p.GetFamilySocial(id);
            Model.Medication = p.GetMedication(id);
            Model.AllergiesSpiritual = p.GetAllergiesSpiritual(id);
            Model.IllnessesMedical = p.GetIllnessesMedical(id);
            Model.NextOfKin = p.GetNextOfKin(id);
            Model.CaseConferance = p.GetCaseConferance(id);
            Model.Equipment = p.GetEquipment(id);





            return View(Model);
        }


        [HttpGet]
        public ActionResult getLocality(Guid id)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            List<SelectListItem> LocalityList = (from locality
                        in patient.GetLocalities(id).ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = locality.LocalityName,
                                                     Value = locality.LocalityId.ToString()

                                                 }).ToList();
            //ViewBag.Locality = LocalityList;

            return Json(LocalityList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getStreet(Guid id)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            List<SelectListItem> StreetList = (from street
                        in patient.GetStreets(id).ToList()
                                               select new SelectListItem()
                                               {
                                                   Text = street.StreetName,
                                                   Value = street.StreetId.ToString()

                                               }).ToList();
            //ViewBag.Locality = LocalityList;




            return Json(StreetList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getProperty(Guid id)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            IQueryable<Common.Property> p = patient.GetProperties(id);
            List<SelectListItem> PropertyList = (from property
                        in patient.GetProperties(id).ToList()
                                                 select new SelectListItem()
                                                 {
                                                     Text = property.PropertyName,
                                                     Value = property.PropertyId.ToString()

                                                 }).ToList();
            //ViewBag.Locality = LocalityList;




            return Json(PropertyList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddPatient(Common.Doctor d, Common.DiagnosisPatient dp, Common.PatientsEmployee pe, Common.Patient pat, Common.Person per, string txtStreetP, string txtPropertyP, Guid? locality, Guid? street, string txtOnc, Guid? ddOnc, string txtCon, Guid? ddCon, string txtFD, Guid? ddFD)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            try
            {
                if (per.IdCardNumber != null)
                {
                    if (patient.CheckRegister(per.IdCardNumber))
                    {
                        patient.RegisterPerson(per, txtStreetP, txtPropertyP, locality, street);
                        pat.Personfk = per.PersonID;
                        patient.RegisterPatient(pat);
                        if (pe.EmployeeId_fk != Guid.Empty)
                        {
                            patient.AddKeyWorker(pe);
                        }
                        if (dp.DiagnosisType_fk != Guid.Empty && dp.DiagnosisType_fk != null)//Issue Fix it
                        {
                            patient.AddDiagnosis(dp);
                        }

                        patient.AddDoctor(d, txtCon, txtOnc, txtFD, ddCon, ddFD, ddOnc);

                    }
                }
                else
                {
                    patient.RegisterPerson(per, txtStreetP, txtPropertyP, locality, street);
                    pat.Personfk = per.PersonID;
                    patient.RegisterPatient(pat);
                    if (pe.EmployeeId_fk != Guid.Empty)
                    {
                        patient.AddKeyWorker(pe);
                    }
                    if (dp.DiagnosisType_fk != Guid.Empty && dp.DiagnosisType_fk != null)//Issue Fix it
                    {
                        patient.AddDiagnosis(dp);
                    }

                    patient.AddDoctor(d, txtCon, txtOnc, txtFD, ddCon, ddFD, ddOnc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("Valid", JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidatePatient(string email, string Filenumber, string DOFC, string DOB, string DOD, string DecD)
        {
            BusinessLayer.PatientsBL p = new BusinessLayer.PatientsBL();

            if (p.ValidRegister(Filenumber, DOFC, email, DOB, DOD, DecD))
            {
                return Json("Pass", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SearchPatients(string fileNumber, string govId, string name, string surname, string fileStatus, string keyWorker)
        {
            int fn = 0;
            Guid fs = Guid.Empty;
            Guid kw = Guid.Empty;

            if (fileNumber != "")
                fn = Convert.ToInt32(fileNumber);
            if (fileStatus != "Select File Status")
                fs = new Guid(fileStatus);
            if (keyWorker != "Select Key Worker")
                kw = new Guid(keyWorker);

            try
            {
                List<Common.Patient> patients = new BusinessLayer.PatientsBL().GetPatients(fn, govId, name, surname, fs, kw).ToList();
                List<Common.PatientsEmployee> patientsEmp = new BusinessLayer.PatientsBL().PatientsEmployees().ToList();
                BusinessLayer.UsersBL employees = new BusinessLayer.UsersBL();
                var result = from p in patients
                             join emp in patientsEmp on p.FileNumber equals emp.PatientFileNumber_fk into gj
                             from final in gj.DefaultIfEmpty()
                             select new
                             {
                                 FileNumber = p.FileNumber,
                                 Firstname = p.Person.FirstName != null ? p.Person.FirstName : "None",
                                 Surname = p.Person.LastName != null ? p.Person.LastName : "None",
                                 GovermentId = p.Person.IdCardNumber != null ? p.Person.IdCardNumber : "None",
                                 FileStatus = p.FileStatus != null ? p.FileStatus.FileStatusName : "None",
                                 KeyWorker = final != null ? final.Employee.Person.FirstName + " " + final.Employee.Person.LastName : "None"
                             };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddFamilySocial(Common.FamilySocial fs, string PatientIds, string[] incomeItems)
        {
            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            try
            {
                fs.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddFamilySocial(fs);
                if (incomeItems != null)
                {
                    for (int i = 0; i < incomeItems.Length; i++)
                    {
                        patient.AddIncome(incomeItems[i], fs.FamilySocialId);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FSListbox()
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            List<SelectListItem> incomes = (from i
                                in patient.GetIncomes().ToList()
                                            select new SelectListItem()
                                            {
                                                Text = i.IncomeName,
                                                Value = i.IncomeId.ToString()

                                            }).ToList();
            string[] sIncomes = new string[incomes.Count()];

            for (int i = 0; i < incomes.Count(); i++)
            {
                sIncomes[i] = incomes[i].Text.ToString();
            }
            return Json(incomes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddMedication(Common.Medication m, string PatientIds)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            try
            {

                m.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddMedication(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAllergiesSpiritual(Common.AllergiesSpiritual allspr, string PatientIds)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            try
            {
                allspr.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddAllergiesSpiritual(allspr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddIllnessesMedical(Common.IllnessesMedical im, string PatientIds)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();
            try
            {

                im.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddIllnessesMedical(im);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddNextOfKin(Common.NextOfKin nok, Common.Person personNOK, string txtStreetNOK, string txtPropertyNOK, Guid? localityNOK, Guid? streetNOK)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            try
            {

                //nok.PatientId_fk = Int32.Parse(PatientIds);

                patient.RegisterPerson(personNOK, txtStreetNOK, txtPropertyNOK, localityNOK, streetNOK);
                nok.Personfk = personNOK.PersonID;
                patient.AddNextOfKin(nok);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCaseConferance(Common.CaseConferance cc, string PatientIds)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            try
            {

                cc.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddCaseConferance(cc);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddEquipment(Common.Equipment e, string PatientIds)
        {

            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            try
            {
                e.PatientId_fk = Int32.Parse(PatientIds);

                patient.AddEquipment(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getDropDowns(int id)
        {
            BusinessLayer.PatientsBL patient = new BusinessLayer.PatientsBL();

            Common.Patient CurrPat = patient.GetPatient(id);

            BusinessLayer.PatientsBL p = new BusinessLayer.PatientsBL();
            Models.UIModel.StoreDropDown Model = new Models.UIModel.StoreDropDown();
            Model.DecPlace = CurrPat.DeceasedPlace_fk;//Guid
            if (CurrPat.DiagnosisPatient != null)
            {
                Model.Diagnosis = CurrPat.DiagnosisPatient.DiagnosisType_fk;//Guid
            }
            if (CurrPat.DiagnosisPatient != null)
            {
                Model.DiagnosisDate = CurrPat.DiagnosisPatient.DiagnosisDate;
            }
            Model.FileStatus = CurrPat.FileStatus_fk;//Guid
            Model.Gender = CurrPat.Person.Gender_fk;
            if (CurrPat.Person.Property != null)
            {
                Model.Island = CurrPat.Person.Property.Street.Locality.Island_fk;//Guid
                Model.Locality = CurrPat.Person.Property.Street.Locality_fk;//Guid
                Model.Property = CurrPat.Person.Property_fk;//Guid
                Model.Street = CurrPat.Person.Property.Street_fk;//Guid
            }
            Model.OriginReferral = CurrPat.OriginOfReferral_fk;//Guid
            Model.PatientAware = CurrPat.PatientAware_fk;//Guid
            Model.RelativesAware = CurrPat.RelativesAware_fk;//Guid
            Model.Title = CurrPat.Person.Title_fk;//Guid
            if (CurrPat.PatientsEmployees.SingleOrDefault(pat => pat.PatientFileNumber_fk == id) != null)
            {
                Model.KeyWorker = CurrPat.PatientsEmployees.SingleOrDefault(pat => pat.PatientFileNumber_fk == id).EmployeeId_fk;
            }

            BusinessLayer.UsersBL emp = new BusinessLayer.UsersBL();
            Common.Doctor d = new Common.Doctor();
            if (CurrPat.FamilyDoctor_fk != null)
            {
                Model.FamilyDoctorEmp = emp.GetDoctor(CurrPat.FamilyDoctor_fk).DEmployeeId_FK;
                Model.FamilyDoctorName = emp.GetDoctor(CurrPat.FamilyDoctor_fk).DoctorName;
            }
            if (CurrPat.Oncologist_fk != null)
            {
                Model.OncologistEmp = emp.GetDoctor(CurrPat.Oncologist_fk).DEmployeeId_FK;
                Model.OncologistName = emp.GetDoctor(CurrPat.Oncologist_fk).DoctorName;
            }
            if (CurrPat.Consultant_fk != null)
            {
                Model.ConsultantEmp = emp.GetDoctor(CurrPat.Consultant_fk).DEmployeeId_FK;
                Model.ConsultantName = emp.GetDoctor(CurrPat.Consultant_fk).DoctorName;
            }
            return Json(Model, JsonRequestBehavior.AllowGet);
        }
    }
}