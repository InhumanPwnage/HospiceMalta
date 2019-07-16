$(document).ready(function () {
    var theme = '';
    var test = [
        "Invalidity  Pension",
        "None",
        "OAP",
        "Others",
        "Relief",
        "Sickness",
        "Wage"
    ];
    $.ajax({
        type: "POST",
        url: ("/Patients/FSListbox/"),
        datatype: "json",
        data: {},
        cache: false,
        complete: function (data) {
       
            var lb = [];
            lb = data.responseJSON;


            $("#lBox1").jqxListBox({
                source: lb,
                displayMember: "Text",
                valueMember: "Value",
                allowDrop: true,
                allowDrag: true,
                width: 200,
                height: 250,
                theme: theme
            });

           // $("#lBox1").jqxListBox({ allowDrop: true, allowDrag: true, source: lb, width: 200, height: 250, theme: theme });
            $("#lBox2").jqxListBox({ allowDrop: true, allowDrag: true, source: "", width: 200, height: 250, theme: theme });
        }
    });
   

});

function populatingListbox(data) {
    
}