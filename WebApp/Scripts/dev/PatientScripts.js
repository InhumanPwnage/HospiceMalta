function addPatient() {
    ////Page 1 Patient
    
    var dpDateofDiagnosisP = document.getElementById("txtDateofDiagnosis").value;

    var dpDeceasedDateP = document.getElementById("txtDecDate").value;

    var dpDateOfBirthP = document.getElementById("dpDOB").value;

    var txtEmailP = document.getElementById("txtEmail").value;

    var txtFileNumberP = document.getElementById("txtFileNumber").value;

    var dpDateOfFirstContactP = document.getElementById("txtDofc").value;

    var dpDateP = document.getElementById("dpDate").value;

    var none = "None";
    $.ajax({
        type: "POST",
        url: ("/Patients/ValidatePatient/"),
        datatype: "json",
        data: { email: txtEmailP, Filenumber: txtFileNumberP.toString(), DOFC: dpDateOfFirstContactP.toString(), DOB: dpDateOfBirthP.toString(), DOD: dpDateofDiagnosisP.toString(), DecD: dpDeceasedDateP.toString() },
        cache: false,
        success: function (data) {

       
    
    if (txtFileNumberP != "" && dpDateOfFirstContactP != "" && dpDateP != "") {
        alert("Adding To Database");
        
        addPatients();
    }
    else {
        alert("Incorrect");
    }





    //document.getElementById("input:text").attr("checked", "checked");
    //document.getElementById("input:number").attr("checked", "checked");
    //document.getElementById("input:date").attr("checked", "checked");
        }
    });
}
function toggleRefresh() {
    do {
        name = document.getElementById("Refresh").getAttribute("name");
        if (name == "true") {//show TXT
            location.reload();
        }
    } while (name == "false");
}