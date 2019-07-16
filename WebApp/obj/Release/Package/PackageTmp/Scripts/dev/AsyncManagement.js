$(document).ready(function () {
    getAssessments();
    getAssessmentTypes();
    getAssessmentOrigins();
    getAssessmentWorkers();

    getPatientAssessments();
    getPatientAssessmentTypes();

    getCarePlans();
    getCarePlanTypes();
    getCarePlanStatuses();
});


//populate drop-downs
function getAssessmentTypes()
{
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessmentTypes';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlTypes\" name=\"assddlTypes\">";

        dropd += "<option value=\"-1\">Pick Assessment Type</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.TypeId + "\">" + val.TypeName + "</option>";

        });

        dropd += "</select>";

        $('#assdivType').html(dropd);
    });
}

function getAssessmentOrigins() {
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessmentOrigins';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlOrigins\" name=\"assddlOrigins\">";

        dropd += "<option value=\"-1\">Select Origin</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.OriginId + "\">" + val.OriginName + "</option>";

        });

        dropd += "</select>";

        $('#assdivOrigin').html(dropd);
    });
}

function getAssessmentWorkers() {
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessmentWorkers';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlWorkers\" name=\"assddlWorkers\">";

        dropd += "<option value=\"-1\">Select Worker</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.WorkerId + "\">" + val.WorkerName + " " + val.WorkerSurname + "</option>";

        });

        dropd += "</select>";

        $('#assdivWorker').html(dropd);
    });
}


function getPatientAssessmentTypes() {
    var url = 'http://localhost:8236/api/PatientAssessmentsApi/GetPatientAssessmentTypes';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"patddlTypes\" onchange=\"getPatientAssessmentGrades()\" name=\"patddlTypes\">";

        dropd += "<option value=\"-1\">Select this first!</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.TypeId + "\">" + val.TypeName + "</option>";

        });

        dropd += "</select>";

        $('#patType').html(dropd);
    });
}

function getPatientAssessmentGrades() {

    var val = $('#patddlTypes').val();

    var url = 'http://localhost:8236/api/PatientAssessmentsApi/GetPatientAssessmentTypeGrades?typeid=' + val;

    $('#patddlGrades').empty();
    var dropd = "<option value=\"-1\">Select Type First!</option>";

    $.getJSON(url, function (data) {

        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.GradeId + "\">" + val.GradeName + "</option>";

        });

        $('#patddlGrades').append(dropd);
    });
}


function getCarePlanTypes() {
    var url = 'http://localhost:8236/api/CarePlanApi/GetCarePlanTypes';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"carddlType\" name=\"carddlType\">";

        dropd += "<option value=\"-1\">Select Type</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.TypeId + "\">" + val.TypeName + "</option>";

        });

        dropd += "</select>";

        $('#carType').html(dropd);
    });
}

function getCarePlanStatuses() {
    var url = 'http://localhost:8236/api/CarePlanApi/GetCarePlanStatuses';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"carddlStatus\" name=\"carddlStatus\">";

        dropd += "<option value=\"-1\">Select Status</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.StatusId + "\">" + val.StatusName + "</option>";

        });

        dropd += "</select>";

        $('#carStatus').html(dropd);
    });
}


//populate tables
function getAssessments()
{
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessments';

    $.getJSON(url, function (data) {
        var tabl = "";

        $.each(data, function (key, val) {
            tabl += "<tr>";
            tabl += "<td>" + FormatDate(new Date(val.Date)) + "</td>";
            tabl += "<td>" + FormatDate(new Date(val.DateConfirmed)) + "</td>";
            tabl += "<td>" + val.Type + "</td>";
            tabl += "<td>" + val.Worker + "</td>";
            tabl += "<td><button type=\"button\" onclick=\"getAssessment('"+val.AssessmentId+"')\" class=\"btn btn-default btn-xs\" id=\"btnOpenAssessment\">Open</button></td>";
            tabl += "</tr>";
        });

        $('#assAssessments tbody').html(tabl);
    });
}

function getPatientAssessments() {

    var url = 'http://localhost:8236/api/AssessmentsApi/GetPatientAssessments';

    $.getJSON(url, function (data) {
        var tabl = "";

        $.each(data, function (key, val) {
            tabl += "<tr>";
            tabl += "<td>" + val.TypeId + "</td>";
            tabl += "<td>" + val.Grade + "</td>";
            tabl += "<td><button type=\"button\" onclick=\"getPatientAssessment('" + val.PatientAssessmentId + "')\" class=\"btn btn-default btn-xs\" id=\"btnOpenPatientAssessment\">Open</button></td>";
            tabl += "</tr>";
        });

        $('#patAssessments tbody').html(tabl);
    });
}

function getCarePlans() {
    var url = 'http://localhost:8236/api/CarePlanApi/GetCarePlans';

    $.getJSON(url, function (data) {
        var tabl = "";

        $.each(data, function (key, val) {
            tabl += "<tr>";
            tabl += "<td>" + FormatDate(new Date(val.CarePlanDate)) + "</td>";
            tabl += "<td>" + val.CarePlanType + "</td>";
            tabl += "<td>" + val.Status + "</td>";
            tabl += "<td><button type=\"button\" onclick=\"getCarePlan('" + val.CarePlanId + "')\" class=\"btn btn-default btn-xs\" id=\"btnOpenCarePlan\">Open</button></td>";
            tabl += "</tr>";
        });

        $('#carePlans tbody').html(tabl);
    });
}

//http://localhost:8236/api/AssessmentsApi/GetAssessmentsOfPatient?patid=
function getAssessmentsOfPatient(val)
{ }

//open assessment/care plan
function getAssessment(valr)
{
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessment?assid=' + valr;

    $.getJSON(url, function (data) {
            $("#assDate").val(FormatDate(new Date(data.Date)));
            $("#assDuration").val(data.Duration);
            $("#assddlTypes").val(data.Type);
            $("#assConfirmed").val(data.Confirmed);
            $("#assTime").val(data.Time);
            $("#assddlOrigins").val(data.Origin);
            $("#assddlWorkers").val(data.Worker);
            $("#assConfirmDate").val(FormatDate(new Date(data.DateConfirmed)));
            $("#assDescription").val(data.Description);
            $("#AssesmentId").val(data.AssessmentId);
            $("#assPatient").val(data.PatientId);
    });
}

function getPatientAssessment(valr) {
    var url = 'http://localhost:8236/api/PatientAssessmentsApi/GetPatientAssessment?patid=' + valr;

    $.getJSON(url, function (data) {
        $("#patRemarks").val(data.Remark);
        $("#patddlTypes").val(data.Type);
        $("#patddlGrades").val(data.Grade);
        $("#PatientAssesmentId").val(data.PatAssId);
        $("#patPatient").val(data.PatientId);
    });
}

function getCarePlan(valr) {
    var url = 'http://localhost:8236/api/CarePlanApi/GetCarePlan?cpid=' + valr;

    $.getJSON(url, function (data) {
        $("#carRemarks").val(data.Remark);
        $("#carddlType").val(data.Type);
        $("#carddlStatus").val(data.Status);
        $("#carDate").val(FormatDate(new Date(data.Date)));
        $("#CarePlanId").val(data.CarePlanId);
        $("#carPatient").val(data.PatientId);
    });
}


//formatting for Date input field
function FormatDate(Date) {
    return Date.getFullYear() + '-' + pad(Date.getMonth(), 2) + '-' + pad(Date.getDate(), 2);
}

function pad(num, size) {
    var s = num + "";
    while (s.length < size) s = "0" + s;
    return s;
}

/*
$(data).each(function () {
    $("<option />", {
        val: this.value,
        text: this.text
    }).appendTo(dropdown);
});
*/