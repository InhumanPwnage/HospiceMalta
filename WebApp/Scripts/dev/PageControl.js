

function Next() {
    $(".nav-tabs > .active").next("li").find("a").trigger("click");
}

function Previous() {
    $(".nav-tabs > .active").prev("li").find("a").trigger("click");
}


function ResetTabs()
{
    $("#sympTab").removeAttr("data-toggle");
    $("#sympTab").attr('class', 'disabled');
    $("#sympTab").css("cursor", "not-allowed");
    $("#sympTab").css("background-color", "#eeeeee");
    $("#sympTab").css("color", "#bfbfbf");

    $('#funcTab').removeAttr("data-toggle");
    $("#funcTab").attr('class', 'disabled');
    $("#funcTab").css("cursor", "not-allowed");
    $("#funcTab").css("background-color", "#eeeeee");
    $("#funcTab").css("color", "#bfbfbf");

    $('#geneTab').removeAttr("data-toggle");
    $("#geneTab").attr('class', 'disabled');
    $("#geneTab").css("cursor", "not-allowed");
    $("#geneTab").css("background-color", "#eeeeee");
    $("#geneTab").css("color", "#bfbfbf");

    $('#physTab').removeAttr("data-toggle");
    $("#physTab").attr('class', 'disabled');
    $("#physTab").css("cursor", "not-allowed");
    $("#physTab").css("background-color", "#eeeeee");
    $("#physTab").css("color", "#bfbfbf");

    $('#probTab').removeAttr("data-toggle");
    $("#probTab").attr('class', 'disabled');
    $("#probTab").css("cursor", "not-allowed");
    $("#probTab").css("background-color", "#eeeeee");
    $("#probTab").css("color", "#bfbfbf");
}



Date.prototype.timeNow = function () {
    return ((this.getHours() < 10) ? "0" : "") + this.getHours() + ":" + ((this.getMinutes() < 10) ? "0" : "") + this.getMinutes();
}

function GetNewCurrentTime() {
    $("#assTime").val(new Date().timeNow());
}


/*var mint = 0;

function GetCurrentTime() {
    var dt = new Date();
    var hour = dt.getHours();
    mint = dt.getMinutes();
    checkMinute();

    if (hour > 12) {
        $("#assTime").val((hour - 12) + ":" + mint + "pm");
    }
    else if (hour == 12) {
        $("#assTime").val(hour + ":" + mint + "pm");
    }
    else {
        if (hour == 0)
            hour = 12;

        $("#assTime").val(hour + ":" + mint + "am");
    }
}

function checkMinute() {
    if (mint < 10)
        mint = "0" + mint;
}

*/