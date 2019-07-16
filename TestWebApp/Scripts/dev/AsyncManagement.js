$(document).ready(function () {
    getAssessmentTypes();
    getAssessmentOrigins();
    getAssessmentWorkers();

    getPatientAssessmentTypes();

    getCarePlanTypes();
    getCarePlanStatuses();
});

function getAssessmentTypes()
{
    var url = 'http://localhost:8236/api/AssessmentsApi/GetAssessmentTypes';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlTypes\">";

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
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlOrigins\">";

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
        var dropd = "<select class=\"form-control form-control-inline\" id=\"assddlWorkers\">";

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
        var dropd = "<select class=\"form-control form-control-inline\" id=\"patddlTypes\" onchange=\"getPatientAssessmentGrades()\">";

        dropd += "<option value=\"-1\">Select this first</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.TypeId + "\">" + val.TypeName + "</option>";

        });

        dropd += "</select>";

        $('#patType').html(dropd);
    });
}

function getPatientAssessmentGrades() {
    //for the text:
    //$("#patddlTypes option:selected").text();

    var val = $('#patddlTypes').val();

    var url = 'http://localhost:8236/api/PatientAssessmentsApi/GetPatientAssessmentTypeGrades?typeid=' + val;

    $.getJSON(url, function (data) {
        var dropd = "";

        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.TypeId + "\">" + val.TypeName + "</option>";

        });

        dropd += "</select>";

        $('#patddlTypes').append(dropd);
    });
}


function getCarePlanTypes() {
    var url = 'http://localhost:8236/api/CarePlanApi/GetCarePlanTypes';

    $.getJSON(url, function (data) {
        var dropd = "<select class=\"form-control form-control-inline\" id=\"carddlType\" >";

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
        var dropd = "<select class=\"form-control form-control-inline\" id=\"carddlStatus\" >";

        dropd += "<option value=\"-1\">Select Status</option>";
        $.each(data, function (key, val) {
            dropd += "<option value=\"" + val.StatusId + "\">" + val.StatusName + "</option>";

        });

        dropd += "</select>";

        $('#carStatus').html(dropd);
    });
}