$(document).ready(function () {
    $("#imgLoading").hide();
});

function enterChecker(e) {
    if (e.keyCode == 13) {
        $("#btnSubmit").click();
        return false;
    }
}

function ValidateLogin() {
    var username = document.getElementById("txtUsername").value;
    var password = document.getElementById("txtPassword").value;
    $("#imgLoading").show();
    $.ajax({
        type: "GET",
        url: ("/Home/ValidateLogin"),
        datatype: "json",
        data: { username: username, password: password },
        cache: false,
        success: function (data) {
            $("#imgLoading").show();

            if (data != "error") {
                window.location.href = data;
            }
            else {
                document.getElementById("lblError").innerHTML = ("Error Invalid Login");
                document.getElementById("txtUsername").value = "";
                document.getElementById("txtPassword").value = "";
                $("#imgLoading").fadeOut(800);
            }



        }
    });
    
}