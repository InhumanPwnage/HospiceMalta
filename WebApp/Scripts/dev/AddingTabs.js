function addFamilySocial() {
    var taFamilyHistoryFS = document.getElementById("taFamilyHistory").value;
    var ddPatientStatusFS = document.getElementById("fsPatientStatus").value;
    var txtNoOfChildrenFS = document.getElementById("txtNoOfChildren").value;
    var txtOccupationFS = document.getElementById("fsOccupation").value;
    var ddAccomodationFS = document.getElementById("fsAccomodation").value;
    var txtNoOfFloorsFS = document.getElementById("txtNoOfFloors").value;
    var txtProblemsFS = document.getElementById("txtProblems").value;
    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var lBoxIncomeFS = $("#lBox2").jqxListBox('getItems');
    var test = [];
    for (var key in lBoxIncomeFS) {
        var value = lBoxIncomeFS[key].value;
        test.push(value);
    }
    var none = "None";
    if (ddPatientStatusFS != none || txtOccupationFS != none || ddAccomodationFS != none || txtNoOfChildrenFS != "" || txtProblemsFS != "" || taFamilyHistoryFS != "" || txtNoOfFloorsFS != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddFamilySocial/"),
            datatype: "json",
            data: { SocialPatientStatus_fk: ddPatientStatusFS, SocialOccupation_fk: txtOccupationFS, SocialAccommodations_fk: ddAccomodationFS, SocialNoOfChildren: txtNoOfChildrenFS, SocialProblems: txtProblemsFS, incomeItems: test, FamilyHistory: taFamilyHistoryFS, PatientIds: txtFileNumberP, SocialNumberOfFloors: txtNoOfFloorsFS },
            cache: false,
            success: function (data) {



            }
        });
    }
}
function addMedication() {
    var dpMedicationM = document.getElementById("dpMedication").value;
    var taDescriptionM = document.getElementById("taDescriptionMedication").value;
    var none = "None";
    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    if (dpMedicationM != "" || taDescriptionM != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddMedication/"),
            datatype: "json",
            data: { MedicationDate: dpMedicationM, MedicationDescription: taDescriptionM, PatientIds: txtFileNumberP },
            cache: false,
            success: function (data) {



            }
        });
    }
}
function addAllergySpiritual() {
    var txtTypeAllergiesAS = document.getElementById("txtTypeAllergies").value;
    var taDescriptionAllergiesAS = document.getElementById("taDescriptionAllergies").value;
    var dpDateSpiritualAS = document.getElementById("dateSpiritual").value;
    var taDescriptionSpiritualAS = document.getElementById("taDescriptionSpiritual").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var none = "None";
    if (txtTypeAllergiesAS != "" || taDescriptionAllergiesAS != "" || dpDateSpiritualAS != "" || taDescriptionSpiritualAS != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddAllergiesSpiritual/"),
            datatype: "json",
            data: { AllergyType: txtTypeAllergiesAS, AllergyDescription: taDescriptionAllergiesAS, SpiritualDate: dpDateSpiritualAS, SpiritualDescription: taDescriptionSpiritualAS, PatientIds: txtFileNumberP },
            cache: false,
            success: function (data) {



            }
        });
    }
}
function addIllnessesMedical() {
    var dpDateIllnessIM = document.getElementById("dateIllness").value;
    var taEventsOfRelevanceIllnessIM = document.getElementById("taEventsOfRelevanceIllness").value;
    var ddTypeMedical = document.getElementById("medicalType").value;
    var taDescriptionMedical = document.getElementById("taDescriptionMedical").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var none = "None";
    if (dpDateIllnessIM != "" || taEventsOfRelevanceIllnessIM != "" || ddTypeMedical != none || taDescriptionMedical != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddIllnessesMedical/"),
            datatype: "json",
            data: { IllnessesDate: dpDateIllnessIM, IllnessesEventsOfRevelance: taEventsOfRelevanceIllnessIM, MedicalType_fk: ddTypeMedical, MedicalDescription: taDescriptionMedical, PatientIds: txtFileNumberP },
            cache: false,
            success: function (data) {



            }
        });
    }
}
function addNextOfKin() {
    var txtGovernmentIdNOK = document.getElementById("txtGovernmentIdNOK").value;
    var txtPassportNOK = document.getElementById("txtPassportNOK").value;
    var txtSurnameNOK = document.getElementById("txtSurnameNOK").value;
    var txtNameNOK = document.getElementById("txtNameNOK").value;
    var ddGenderNOK = document.getElementById("GenderNOK").value;
    var dpDOBNOK = document.getElementById("dpDOBNOK").value;
    var ddIslandNOK = document.getElementById("IslandNOKDD").value;
    var ddLocalityNOK = document.getElementById("LocalityNOKDD").value;

    var ddStreetNOK = document.getElementById("StreetNOKDD").value;
    var txtStreetNOK = document.getElementById("txtNOKAddStreet").value;

    var ddPropertyNOK = document.getElementById("PropertyNOKDD").value;
    var txtPropertyNOK = document.getElementById("txtNOKAddProperty").value;

    var txtTelephoneNOK = document.getElementById("txtTelephoneNOK").value;
    var txtMobileNOK = document.getElementById("txtMobileNOK").value;
    var txtEmailNOK = document.getElementById("txtEmailNOK").value;
    var ddTitleNOK = document.getElementById("nextOfKinTitle").value;
    var ddRelationNOK = document.getElementById("nextOfKinRelation").value;
    var txtOtherRelationNOK = document.getElementById("txtOtherRelation").value;
    var txtRemarksNOK = document.getElementById("txtNOKRemarks").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    if (txtGovernmentIdNOK != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddNextOfKin/"),
            datatype: "json",
            data: { Relation_fk: ddRelationNOK, OtherRelationship: txtOtherRelationNOK, NextOfKinRemark: txtRemarksNOK, PrimaryRelation: "Null", supportNetworkRelation: "Null", ContactRelation: "Null", PatientId_fk: txtFileNumberP, IdCardNumber: txtGovernmentIdNOK, FirstName: txtNameNOK, LastName: txtSurnameNOK, DOB: dpDOBNOK, Gender_fk: ddGenderNOK, PassportNumber: txtPassportNOK, TelephoneNo: txtTelephoneNOK, MobileNo: txtMobileNOK, Email: txtEmailNOK, Property_fk: ddPropertyNOK, Title_fk: ddTitleNOK, txtStreetNOK: txtStreetNOK, txtPropertyNOK: txtPropertyNOK, localityNOK: ddLocalityNOK, streetNOK: ddStreetNOK },
            cache: false,
            success: function (data) {



            }
        });
    }
}
function addCaseConferance() {
    var dpDateCC = document.getElementById("dateCaseConferance").value;
    var taPointCaseConferance = document.getElementById("pointCaseConferance").value;
    var taResolutionCC = document.getElementById("resolutionCaseConferance").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var none = "None";
    if (dpDateCC != "" || taPointCaseConferance != "" || taResolutionCC != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddCaseConferance/"),
            datatype: "json",
            data: { CaseConferanceDate: dpDateCC, CaseConferancePoint: taPointCaseConferance, CaseConferanceResolution: taResolutionCC, PatientIds: txtFileNumberP },
            cache: false,
            success: function (data) {



            }
        });
    }
}

function addEquipment() {

    var dpDateE = document.getElementById("dpEquipment").value;
    var ddTypeE = document.getElementById("EquipmentType").value;
    var taRemarksE = document.getElementById("EquipmentRemarks").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;
    var none = "None";
    if (dpDateE != "" || ddTypeE != none || taRemarksE != "") {
        $.ajax({
            type: "POST",
            url: ("/Patients/AddEquipment/"),
            datatype: "json",
            data: { EquipmentDate: dpDateE, EquipmentType_fk: ddTypeE, EquipmentRemarks: taRemarksE, PatientIds: txtFileNumberP },
            cache: false,
            success: function (data) {



            }
        });
    }
}