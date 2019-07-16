function SaveAssessment()
{
    return isDate($('#assDate').val()) && isDate($('#assConfirmDate').val()) && isTime($('#assTime').val()) && isNumber($('#assDuration').val()) && isText($('#assDescription').val());
}

function SavePatient()
{
    return alert(isText($('#patRemarks').val()));
}

function SaveCarePlan()
{
    return alert(isText($('#carRemarks').val()) && isDate($('#carDate').val()));
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