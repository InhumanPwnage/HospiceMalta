$(function () {
    $("#sortable1, #sortable2").sortable({
        connectWith: ".connectedSortable"
    }).disableSelection();
});

function SendEmail(val)
{
    GetEmails();
    if (val == 1)
        $("#sendEmail").attr("onclick", "getAllInformation('assessm')");
    if (val == 2)
        $("#sendEmail").attr("onclick", "getAllInformation('patient')");
    if (val == 3)
        $("#sendEmail").attr("onclick", "getAllInformation('carepla')");
    $("#emailmodal").modal("show");
}

function GetEmails() {
    
    var url = "http://localhost:8236/api/UsersApi/GetWorkerEmails";
    var listb = "";
    $('#sortable1').empty();

    $.getJSON(url, function (data) {

        $.each(data, function (key, val) {
            //ui-state-default
            listb += "<li class=\"item btn btn-default\" data-email=\"" + val.Email + "\" >" + val.Name + " " + val.Surname + "</li>";
            
        });
        $('#sortable1').append(listb);
        //makeDraggable();
    });
    
    
}

function getAllInformation(val) {
    //get checked checkboxes
    var message = "";
    $('#'+val+' input').each(function () {
        message += "<strong>" + $(this).attr('name') + ":</strong> " + $(this).attr('value') + "<br />";
    });
    var recipients = [];
    $('#sortable2 li').each(function () {
        recipients.push($(this).attr('data-email'));
    });

    var obj = { emailmessage: message, emaillist: recipients };

    $.ajax({
        type: "POST",
        url: "/Assessments/SendingEmail", // the method we are calling
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(obj),//{ emailmessage: message }, //
        dataType: "json",
        cache: false,
        success: function (result) {
            $('#resp').html(result);//$("#lblMessage").text(message);
        },
        error: function (result) {
            $('#resp').html(result);
            //alert('Email not sent, check your internet connection!' + result.name);
        }
    });

}


jQuery.fn.outerHTML = function () {
    return jQuery('<div />').append(this.eq(0).clone()).html();
};