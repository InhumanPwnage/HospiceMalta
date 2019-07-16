function getPatients()
{
    var EMPTY = '00000000-0000-0000-0000-000000000000'
    var fileNumber = document.getElementById("searchFileNumber").value;
    var govId = document.getElementById("searchIdCardNumber").value;
    var name = document.getElementById("searchName").value;
    var surname = document.getElementById("searchSurname").value;
    var fileStatus = document.getElementById("searchFileStatus").value;
    var KeyWorker = document.getElementById("searchKeyWorker").value;

    $.ajax({
        type: "POST",
        url: ("/Patients/SearchPatients/"),
        datatype: "json",
        data: { fileNumber:fileNumber, govId: govId ,name: name ,surname:surname ,fileStatus: fileStatus ,keyWorker: KeyWorker },
        cache: false,
        complete: function (data) {
            
            var obj = data.responseJSON;
            var table = "<table class='table'>";
            table += "<thead>";
            table += "<tr><th>File Number &nbsp;</th><th>Goverment Id &nbsp;</th><th>Name &nbsp;</th><th>Surname &nbsp;</th><th>File Status &nbsp;</th><th>Key Worker &nbsp;</th></tr>"
            table += "</thead>";
            table += "<tbody>";
            $.each(obj, function (key, val) {
                
                table += "<tr>";
                table += "<td>" + val.FileNumber + "</td>";
                table += "<td>" + val.GovermentId + "</td>";
                table += "<td>" + val.Firstname  + "</td>";
                table += "<td>" + val.Surname + "</td>";
                table += "<td>" + val.FileStatus + "</td>";
                table += "<td>" + val.KeyWorker + "</td>";
                table += "<td><a href=" + "/PatientInformation/PatientEdit/" + val.FileNumber + " class='btn btn-xs btn-primary'>" + "Edit" + "</a></td>";//<a href="/patient/details/@patient.PatientId" class="btn btn-primary">View</a>

                table += "</tr>";
            
            });
            table += "</tbody>";
            table += "</table>";

            $("#pRecords").html(table);
        }
    });
        
    
}



function getAll() {
   
    var url = 'http://localhost:51275/api/PatientsApi/Get';
    $.getJSON(url, function (data) {

        var table = "<table>"
        table += "<tr><th>File Number &nbsp;</th><th>Goverment Id &nbsp;</th><th>Name &nbsp;</th><th>Surname &nbsp;</th><th>File Status &nbsp;</th></tr>"
        $.each(data, function (key, val) {

            table += "<tr>";
            table += "<td>" + val.FileNumber + "</td>";
            table += "<td>" + val.GovermentId + "</td>";
            table += "<td>" + val.Firstname  + "</td>";
            table += "<td>" + val.Surname + "</td>";
            table += "<td>" + val.FileStatus + "</td>";
            table += "<td>" + val.KeyWorker + "</td>";
            table += "</tr>";

        });
        table += "</table>"
        $("#pRecords").html(table);
    });
}