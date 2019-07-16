
function toggleOncologist(button) {
    if (button == "OFF") {//show TXT

        $("#txtOncologist").show();
        $("#ddOncologist").hide();
        var types = document.getElementById("ddOncologist");//taking the dropdown from html 
        for (var i = 0; i < types.options.length; i++)//for loop that loops through the variable types(dropdownlist)
        {
            if (types.options[i].value === "None")//as soon as it hits the correct value
            {
                types.selectedIndex = i; //sets the <option> to selected
                break;
            }
        }
        document.getElementById("btnOncologist").setAttribute("name", "ON");

    }

    else if (button == "ON") {//show DD
        $("#txtOncologist").hide();
        document.getElementById("txtOncologist").value = "";
        $("#ddOncologist").show();
        document.getElementById("btnOncologist").setAttribute("name", "OFF");
    }
}

function toggleConsultant(button) {
    if (button == "OFF") {//show TXT

        $("#txtConsultant").show();
        $("#ddConsultant").hide();
        var types = document.getElementById("ddConsultant");//taking the dropdown from html 
        for (var i = 0; i < types.options.length; i++)//for loop that loops through the variable types(dropdownlist)
        {
            if (types.options[i].value === "None")//as soon as it hits the correct value
            {
                types.selectedIndex = i; //sets the <option> to selected
                break;
            }
        }
        document.getElementById("btnConsultant").setAttribute("name", "ON");

    }

    else if (button == "ON") {//show DD
        $("#txtConsultant").hide();
        document.getElementById("txtConsultant").value = "";
        $("#ddConsultant").show();
        document.getElementById("btnConsultant").setAttribute("name", "OFF");
    }
}

function toggleFamilyDoctor(button) {
    if (button == "OFF") {//show TXT
      
        $("#txtFamilyDoctor").show();
        document.getElementById("txtFamilyDoctor").value = "";
        $("#ddFamilyDoctor").hide();
        var types = document.getElementById("ddFamilyDoctor");//taking the dropdown from html 
        for (var i = 0; i < types.options.length; i++)//for loop that loops through the variable types(dropdownlist)
        {
            if (types.options[i].value === "None")//as soon as it hits the correct value
            {
                types.selectedIndex = i; //sets the <option> to selected
                break;
            }
        }
        document.getElementById("btnFamilyDoctor").setAttribute("name", "ON");

    }

    else if (button == "ON") {//show DD
        $("#txtFamilyDoctor").hide();
        $("#ddFamilyDoctor").show();
        document.getElementById("btnFamilyDoctor").setAttribute("name", "OFF");
    }
}

function toggleNOKStreet(button) {
    if (button == "ON") {//show TXT
        var localityNOK = document.getElementById("LocalityNOKDD").value;
        getNOKStreet(localityNOK);
        $("#txtNOKAddStreet").show();
        $("#StreetNOKDD").hide();

        $("#txtNOKAddProperty").show();
        $("#PropertyNOKDD").hide();
        document.getElementById("btnNOKAddStreet").setAttribute("name", "OFF");

    }

    else if (button == "OFF") {//show DD
        $("#StreetNOKDD").show();
        $("#txtNOKAddStreet").hide();
        document.getElementById("txtNOKAddStreet").value = "";
        document.getElementById("txtNOKAddProperty").value = "";
        $("#txtNOKAddProperty").hide();
        $("#PropertyNOKDD").show();
        document.getElementById("btnNOKAddStreet").setAttribute("name", "ON");
    }
}

function toggleNOKProperty(button) {
    var otherButton = document.getElementById("btnNOKAddStreet").getAttribute("name");
    if (button == "ON") {//show TXT
        var streetNOK = document.getElementById("StreetNOKDD").value;
        getNOKProperty(streetNOK);
        $("#txtNOKAddProperty").show();
        $("#PropertyNOKDD").hide();
        document.getElementById("btnNOKAddProperty").setAttribute("name", "OFF");
    }

    else if (button == "OFF" && otherButton == "ON") {//show DD

        $("#txtNOKAddProperty").hide();
        $("#PropertyNOKDD").show();
        document.getElementById("txtNOKAddProperty").value = "";
        document.getElementById("btnNOKAddProperty").setAttribute("name", "ON");
    }
}
/////////////////////////////////////////////////
function toggleStreet(button) {
    if (button == "ON") {//show TXT
        var localityP = document.getElementById("LocalityDD").value;
        getStreet(localityP);
        $("#txtAddStreet").show();
        $("#StreetDD").hide();

        $("#txtAddProperty").show();
        $("#PropertyDD").hide();
        document.getElementById("btnAddStreet").setAttribute("name", "OFF");
    }

    else if (button == "OFF") {//show DD
        $("#StreetDD").show();
        $("#txtAddStreet").hide();
        document.getElementById("txtAddStreet").value = "";
        document.getElementById("txtAddProperty").value = "";
        $("#txtAddProperty").hide();
        $("#PropertyDD").show();
        document.getElementById("btnAddStreet").setAttribute("name", "ON");
    }
}

function toggleProperty(button) {
    var otherButton = document.getElementById("btnAddStreet").getAttribute("name");
    if (button == "ON") {//show TXT
        var streetP = document.getElementById("StreetDD").value;
        getProperty(streetP);
        $("#txtAddProperty").show();
        $("#PropertyDD").hide();
        document.getElementById("btnAddProperty").setAttribute("name", "OFF");
    }

    else if (button == "OFF" && otherButton == "ON") {//show DD

        $("#txtAddProperty").hide();
        $("#PropertyDD").show();
        document.getElementById("txtAddProperty").value = "";
        document.getElementById("btnAddProperty").setAttribute("name", "ON");
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

function getLocality(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getLocality/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            $("#txtAddProperty").hide();
            $("#PropertyDD").show();
            $("#StreetDD").show();
            $("#txtAddStreet").hide();
            var details = data;
            var $el2 = $("#StreetDD");
            $el2.empty(); // remove old options
            $el2.append($("<option disabled selected></option>").attr("value", '').text('Locality Needs To be Selected first'));
            var $el3 = $("#PropertyDD");
            $el3.empty(); // remove old options
            $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

            var $el = $("#LocalityDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });

            document.getElementById("btnAddStreet").disabled = true;
            document.getElementById("btnAddProperty").disabled = true;



        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}
function getStreet(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getStreet/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            var details = data;

            var $el3 = $("#PropertyDD");
            $el3.empty(); // remove old options
            $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

            var $el = $("#StreetDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });


            document.getElementById("btnAddStreet").disabled = false;
            document.getElementById("btnAddProperty").disabled = true;


        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}
function getProperty(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getProperty/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            var details = data;

            var $el = $("#PropertyDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });



            document.getElementById("btnAddStreet").disabled = false;
            document.getElementById("btnAddProperty").disabled = false;

        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}

///////


function getNOKLocality(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getLocality/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            $("#txtNOKAddProperty").hide();
            $("#PropertyNOKDD").show();
            $("#StreetNOKDD").show();
            $("#txtNOKAddStreet").hide();
            var details = data;
            var $el2 = $("#StreetNOKDD");
            $el2.empty(); // remove old options
            $el2.append($("<option disabled selected></option>").attr("value", '').text('Locality Needs To be Selected first'));
            var $el3 = $("#PropertyNOKDD");
            $el3.empty(); // remove old options
            $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

            var $el = $("#LocalityNOKDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });



            document.getElementById("btnNOKAddStreet").disabled = true;
            document.getElementById("btnNOKAddProperty").disabled = true;

        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}
function getNOKStreet(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getStreet/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            var details = data;

            var $el3 = $("#PropertyNOKDD");
            $el3.empty();
            $el3.append($("<option disabled selected></option>").attr("value", '').text('Street Needs To be Selected first'));

            var $el = $("#StreetNOKDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });


            document.getElementById("btnNOKAddStreet").disabled = false;
            document.getElementById("btnNOKAddProperty").disabled = true;


        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}
function getNOKProperty(id) {
    $.ajax({
        type: "GET",
        url: ("/Patients/getProperty/"),
        datatype: "Json",
        data: { id: id },
        cache: false,
        success: function (data) {
            var details = data;

            var $el = $("#PropertyNOKDD");
            $el.empty(); // remove old options
            $el.append($("<option disabled selected></option>").attr("value", '').text('Please Select'));
            $.each(details, function (index, object) {
                $el.append($("<option></option>").attr("value", object.Value).text(object.Text));
            });


            document.getElementById("btnNOKAddStreet").disabled = false;
            document.getElementById("btnNOKAddProperty").disabled = false;


        }
       , error: function (xhr, ajaxOptions, thrownError) {
       }
    });

}
