$(document).ready(function () {
    //Populate Drop down
    var id = document.getElementById("txtFileNumber").value;
    $.ajax({
        type: "GET",
        url: ("/PatientInformation/getDropDowns/"),
        datatype: "json",
        data: { id: id },
        cache: false,
        success: function (data) {
            var details = data;
            if (details.Gender != null) {
                $("#PatientGender").val(details.Gender);
            }

            if (details.Property != null) {
                $("#IslandDD").val(details.Island);
                getLocality(details.Island);


                $("#LocalityDD").val(details.Locality);
                getStreet(details.Street);

                $("#StreetDD").val(details.Street);
                getProperty(details.Property);

                $("#PropertyDD").val(details.Property);
            }
            else {
                DropDownSettingup();
            }
            if (details.Title != null) {
                $("#patientTitle").val(details.Title);
            }
            if (details.KeyWorker != null) {
                $("#patientkeyWorker").val(details.KeyWorker);
            }
            if (details.OriginReferral != null) {
                $("#patientOriginOfReferral").val(details.OriginReferral);
            }
            if (details.Diagnosis != null) {
                $("#patientDiagnosis").val(details.Diagnosis);
            }
            if (details.DiagnosisDate != null) {
                var dateString = details.DiagnosisDate.substr(6);
                var currentTime = new Date(parseInt(dateString));
                var month = currentTime.getMonth() + 1;
                var day = currentTime.getDate();
                var year = currentTime.getFullYear();
                var date = day + "/" + month + "/" + year;
                $("#txtDateofDiagnosis").val(date);
            }
            
            if (details.PatientAware != null) {
                $("#patientPAware").val(details.PatientAware);
            }
            if (details.RelativesAware != null) {
                $("#patientRAware").val(details.RelativesAware);
            }
            if (details.DecPlace != null) {
                $("#patientDeceasedPlace").val(details.DecPlace);
            }
            if (details.FileStatus != null) {
                $("#patientFileStatus").val(details.FileStatus);
            }
            if (details.FamilyDoctorEmp != "") {
                var check = false;
                var fd = document.getElementById("ddFamilyDoctor");

                for (var i = 0; i < fd.length; i++) {
                    if (details.FamilyDoctorEmp === fd.options[i].value) {
                        $("#txtFamilyDoctor").hide();
                        $("#ddFamilyDoctor").val(details.FamilyDoctorEmp);
                        check = true;
                    }
                    //       alert(fd.options[i].text + " " + fd.options[i].value)
                }
                if (check == false) {
                    $("#ddFamilyDoctor").hide();
                    $("#txtFamilyDoctor").val(details.FamilyDoctorName);

                }

            }

            if (details.OncologistEmp != "") {
                var check = false;
                var onc = document.getElementById("ddOncologist");

                for (var i = 0; i < onc.length; i++) {
                    if (details.OncologistEmp === onc.options[i].value) {
                        $("#txtOncologist").hide();
                        $("#ddOncologist").val(details.OncologistEmp);
                        check = true;
                    }
                    //     alert(onc.options[i].text + " " + onc.options[i].value)
                }
                if (check == false) {
                    $("#ddOncologist").hide();
                    $("#txtOncologist").val(details.OncologistName);

                }
            }

            if (details.ConsultantEmp != "") {
                var check = false;
                var con = document.getElementById("ddConsultant");

                for (var i = 0; i < con.length; i++) {
                    if (details.ConsultantEmp === con.options[i].value) {
                        $("#txtConsultant").hide();
                        $("#ddConsultant").val(details.ConsultantEmp);
                        check = true;
                    }
                    //   alert(con.options[i].text + " " + con.options[i].value)
                }
                if (check == false) {
                    $("#ddConsultant").hide();
                    $("#txtConsultant").val(details.ConsultantName);

                }
            }
        }
    });
});
function DropDownSettingup() {
    var $el1 = $("#LocalityDD");
    $el1.append($("<option disabled selected></option>").attr("value", '').text('Island Needs To be Selected first'));
    var $el2 = $("#StreetDD");
    $el2.append($("<option disabled selected></option>").attr("value", '').text('Locality Needs To be Selected first'));
    var $el3 = $("#PropertyDD");
    $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

    document.getElementById("btnAddStreet").disabled = true;
    document.getElementById("btnAddProperty").disabled = true;



    $("#txtAddStreet").hide();

    $("#txtAddProperty").hide();






}

function formatDate(aname) {
    return aname.getFullYear() + '-' + pad(aname.getMonth, 2) + '-' + pad(aname.getDate(), 2);
}
function pad(num, size) {
    var s = num + "";
    while (s.length < size) {
        s = "0" + s;
       
    }
    return s;
}