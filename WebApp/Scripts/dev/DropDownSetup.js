$(document).ready(function () {
    var $el1 = $("#LocalityDD");
    $el1.append($("<option disabled selected></option>").attr("value", '').text('Island Needs To be Selected first'));
    var $el2 = $("#StreetDD");
    $el2.append($("<option disabled selected></option>").attr("value", '').text('Locality Needs To be Selected first'));
    var $el3 = $("#PropertyDD");
    $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

    document.getElementById("btnAddStreet").disabled = true;
    document.getElementById("btnAddProperty").disabled = true;
    document.getElementById("btnNOKAddStreet").disabled = true;
    document.getElementById("btnNOKAddProperty").disabled = true;


    var $el1 = $("#LocalityNOKDD");
    $el1.append($("<option disabled selected></option>").attr("value", '').text('Island Needs To be Selected first'));
    var $el2 = $("#StreetNOKDD");
    $el2.append($("<option disabled selected></option>").attr("value", '').text('Locality Needs To be Selected first'));
    var $el3 = $("#PropertyNOKDD");
    $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

    $("#txtAddStreet").hide();

    $("#txtAddProperty").hide();

    $("#txtNOKAddStreet").hide();

    $("#txtNOKAddProperty").hide();

    $("#ddFamilyDoctor").hide();

    $("#ddConsultant").hide();

    $("#ddOncologist").hide();


});

