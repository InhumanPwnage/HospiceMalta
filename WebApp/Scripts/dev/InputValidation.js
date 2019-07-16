function SaveAssessment()
{
    /*var checkflag = $('#assConfirmed').is(":checked");
    if(checkflag)
        $('#assConfirmed').val(true);
    else
        $('#assConfirmed').val(false);

    alert("Value: " + $('#assConfirmed').val() + " | Checked: " + checkflag);*/

    //get boolean values
    var flags = [isDate($('#assDate').val()), isNumber($('#assDuration').val()), isValidChoice($("#assddlTypes").val()), isTime($('#assTime').val()), isValidChoice($("#assddlOrigins").val()), isValidChoice($("#assddlWorkers").val()), isDate($('#assConfirmDate').val()), isText($('#assDescription').val())];
    //initialise array

    return validateFields("assess", flags);
    /*var labels = [];
    //get labels
    $('form#assessm label[id=assess]').each(function () {
        labels.push($(this).html());
    });

    var invalidflags = [];

    for (var i = 0; i < flags.length; i++)
    {
        if (!flags[i])
        {
            invalidflags.push(labels[i]);
        }
    }

    if (invalidflags.length == 0)
        return true;
    else
    {
        notifyUser(invalidflags);
        return false;
    }*/
        
}

function SavePatient()
{
    var flags = [isValidChoice($("#patddlTypes").val()), isValidChoice($("#patddlGrades").val()), isText($('#patRemarks').val())];

    return validateFields("patien", flags);
    //return alert(isText($('#patRemarks').val()));
}

function SaveCarePlan()
{
    var flags = [isValidChoice($("#carddlType").val()), isValidChoice($("#carddlStatus").val()), isDate($('#carDate').val()), isText($('#carRemarks').val())];

    return validateFields("carepl", flags);
    //return alert(isText($('#carRemarks').val()) && isDate($('#carDate').val()));
}


function isDate(val) {
    var d = new Date(val);
    return !isNaN(d.valueOf());
}

function isTime(val) {
    var result = false, m;
    var re = /^\s*([01]?\d|2[0-3]):?([0-5]\d)\s*$/;
    if ((m = val.match(re))) {
        return true;
    }
    else { return false; }
}

function isNumber(val)
{
    if ($.isNumeric(val)) {
        if (val <= 0 || val > 420)
            return false;
        else
            return true;
    }
    else { return false; }
}

function isText(val)
{
    if (val.length <= 1000)
        return true;
    else
        return false;
}

function isValidChoice(val)
{
    if (val != null && val != -1 && val.length > 0)
        return true;
    else
        return false;
}


function validateFields(type, flags)
{
    var labels = [];

    $("label[id="+type+"]").each(function () {
        labels.push($(this).html());
    });

    var invalidflags = [];

    for (var i = 0; i < flags.length; i++) {
        if (!flags[i]) {
            invalidflags.push(labels[i]);
        }
    }

    if (invalidflags.length == 0)
        return true;
    else
    {
        var inp = "<p>";

        for (var i = 0; i < invalidflags.length; i++)
            inp += "<strong>" + invalidflags[i] + "</strong><br />";

        $(".modal-body").html(inp + "</p>");
        $("#invalidinputs").modal("show");
        return false;
    }
}

//if false, open modal
function notifyUser(val)
{
    var inp = "<p>";

    for (var i = 0; i < val.length; i++)
        inp += "<strong>" + val[i] + "</strong><br />";

    $(".modal-body").html(inp + "</p>");
    $("#invalidinputs").modal("show");
}