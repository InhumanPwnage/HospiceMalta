
function addPatients() {
    var txtGovermentIdP = document.getElementById("txtGovernmentId").value;
    var txtPassportP = document.getElementById("txtPassport").value;
    var txtSurnameP = document.getElementById("txtSurname").value;
    var txtNameP = document.getElementById("txtName").value;
    var ddGenderP = document.getElementById("PatientGender").value;
    var dpDateOfBirthP = document.getElementById("dpDOB").value;
    var ddIslandP = document.getElementById("IslandDD").value;
    var ddLocalityP = document.getElementById("LocalityDD").value;

    var ddStreetP = document.getElementById("StreetDD").value;
    var txtStreetP = document.getElementById("txtAddStreet").value;

    var ddPropertyP = document.getElementById("PropertyDD").value;
    var txtPropertyP = document.getElementById("txtAddProperty").value;

    var txtTelephoneP = document.getElementById("txtTelephone").value;
    var txtMobileP = document.getElementById("txtMobile").value;
    var txtEmailP = document.getElementById("txtEmail").value;
    var ddTitleP = document.getElementById("patientTitle").value;
    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var dpDateOfFirstContactP = document.getElementById("txtDofc").value;
    var ddKeyWorkerP = document.getElementById("patientkeyWorker").value;
    var ddOriginOfReferralP = document.getElementById("patientOriginOfReferral").value;

    var txtFamilyDoctorP = document.getElementById("txtFamilyDoctor").value;
    var ddFamilyDoctorP = document.getElementById("ddFamilyDoctor").value;

    var txtConsultantP = document.getElementById("txtConsultant").value;
    var ddConsultantP = document.getElementById("ddConsultant").value;

    var txtOncologistP = document.getElementById("txtOncologist").value;
    var ddOncologistP = document.getElementById("ddOncologist").value;

    var txtReligionP = document.getElementById("txtReligion").value;
    var dpDateofDiagnosisP = document.getElementById("txtDateofDiagnosis").value;
    var ddDiagnosisP = document.getElementById("patientDiagnosis").value;
    var ddPatientAwareP = document.getElementById("patientPAware").value;
    var ddRelativesAwareP = document.getElementById("patientRAware").value;
    var dpDeceasedDateP = document.getElementById("txtDecDate").value;
    var ddDeceasedPlaceP = document.getElementById("patientDeceasedPlace").value;
    var txtDeceasedPlaceOtherP = document.getElementById("txtDecPlaceOther").value;
    var ddFileStatusP = document.getElementById("patientFileStatus").value;
    var dpDateP = document.getElementById("dpDate").value;
    $.ajax({
        type: "POST",
        url: ("/Patients/AddPatient/"),
        datatype: "json",
        data: { PatientId_FK: txtFileNumberP,/**/ DiagnosisDate: dpDateofDiagnosisP, PatientId_fk: txtFileNumberP, DiagnosisType_fk: ddDiagnosisP,/**/PatientFileNumber_fk: txtFileNumberP, EmployeeId_fk: ddKeyWorkerP,/**/ FileNumber: txtFileNumberP, DateOfFirstContact: dpDateOfFirstContactP, OriginOfReferral_fk: ddOriginOfReferralP, DeceasedPlace_fk: ddDeceasedPlaceP, DeceasedDate: dpDeceasedDateP, DeceasedPlaceOther: txtDeceasedPlaceOtherP, Religion: txtReligionP, PatientAware_fk: ddPatientAwareP, RelativesAware_fk: ddRelativesAwareP, DateCreated: dpDateP, FileStatus_fk: ddFileStatusP,/**/ IdCardNumber: txtGovermentIdP, FirstName: txtNameP, LastName: txtSurnameP, DOB: dpDateOfBirthP, Gender_fk: ddGenderP, PassportNumber: txtPassportP, TelephoneNo: txtTelephoneP, MobileNo: txtMobileP, Email: txtEmailP, Property_fk: ddPropertyP, Title_fk: ddTitleP, txtStreetP: txtStreetP, txtPropertyP: txtPropertyP, locality: ddLocalityP, street: ddStreetP,/**/ txtOnc: txtOncologistP, ddOnc: ddOncologistP, txtCon: txtConsultantP, ddCon: ddConsultantP, txtFD: txtFamilyDoctorP, ddFD: ddFamilyDoctorP },
        cache: false,
        success: function (data) {

            addFamilySocial();
            addMedication();
            addAllergySpiritual();
            addIllnessesMedical();
            addNextOfKin();
            addCaseConferance();
            addEquipment();
            document.getElementById("test").setAttribute("content", "1");

        }
    });
    
}

