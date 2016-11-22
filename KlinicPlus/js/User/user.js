

//if close button is clicked


//if mask is clicked
//$('#mask').click(function () {
//    $(this).hide();
//    $('.window').hide();
//});

//var array = null;
//function useReturnData(data) {
//    array = data;
//};


var highlighter = {
    "border-color": "red",
    "border-width": "2px"
};
var value = document.cookie;
var cookie = value.substr(5);
//Pop Window

$(document).ready(function () {
    
    var PatientDoctor = {};
    PatientDoctor.Id = cookie;
    PatientDoctor.Type = "Pat";
    $.ajax({
        method: 'POST',
        url: "http://localhost:6887/api/PatDoc/",
        dataType: 'json',
        data: PatientDoctor,
        success: function (data) {
            var records = JSON.parse(data)
            if(records == false)
            {
                $("body").css("overflow", "hidden");
                var id = '#dialog';
                //Get the screen height and width
                var maskHeight = $(document).height();
                var maskWidth = $(window).width();

                //Set heigth and width to mask to fill up the whole screen
                $('#mask').css({ 'width': maskWidth, 'height': maskHeight });

                //transition effect
                $('#mask').fadeIn(500);
                $('#mask').fadeTo("slow", 0.9);

                //Get the window height and width
                var winH = $(window).height();
                var winW = $(window).width();

                //Set the popup window to center
                $(id).css('top', winH / 2 - $(id).height() / 2);
                $(id).css('left', winW / 2 - $(id).width() / 2);

                //transition effect
                $(id).fadeIn(2000);
            }
            else {
                document.getElementById("nameView").innerHTML = records[0].firstname + " " + records[0].lastname;
                document.getElementById("genderView").innerHTML = records[0].gender;
                document.getElementById("dobView").innerHTML = records[0].dob;
                document.getElementById("locationView").innerHTML = records[0].city + ", " + records[0].country;
                document.getElementById("emailView").innerHTML = records[0].email;
                document.getElementById("homePhoneView").innerHTML = records[0].home_phone;
                document.getElementById("cellPhoneView").innerHTML = records[0].cell_phone;
                document.getElementById("bloodGroupView").innerHTML = records[0].bloodgroup;
                document.getElementById("martialStatusView").innerHTML = records[0].martialstatus;
                document.getElementById("e_contactNameView").innerHTML = records[0].e_contactName;
                document.getElementById("e_contactNumberView").innerHTML = records[0].e_contactNumber;
                document.getElementById("medicalHistoryView").innerHTML = records[0].medicalHistory;
                document.getElementById("familyHistoryView").innerHTML = records[0].familyHistory;
                document.getElementById("allergiesView").innerHTML = records[0].allergies;
                document.getElementById("symptomsView").innerHTML = records[0].symptoms;
                document.getElementById("treatmentsView").innerHTML = records[0].treatments;
                document.getElementById("habitsView").innerHTML = records[0].habits;
            }
        },
        error: function (data) {
            alert("error");
        }
    });
    
});
//End of Pop window

//storing values..
$("#okay").click(function () {
    var details = {};
    details.userid = cookie;
    details.homephone = $("#home_phone").val();
    details.cellphone = $("#cell_phone").val();
    details.cnic = $("#cnic").val();
    details.bloodgroup = $("#blood_group").val();
    details.maritalstatus = $("#marital_status").val();
    details.emergencyName = $("#e_contactName").val();
    details.emergencyNumber = $("#e_contactNumber").val();
    details.medicalhistory = $("#medical_history").val();
    details.treatments = $("#treatments").val();
    details.familyhistory = $("#family_history").val();
    details.allergies = $("#allergies").val();
    details.symptoms = $("#symptoms").val();
    details.habits = $("#habit").val();

    if (details.homephone == "") {
        $("#home_phone").css(highlighter);
        $("#home_phone").focus();
        return false;
    }
    else if (details.cellphone == "") {
        $("#cell_phone").css(highlighter);
        $("#cell_phone").focus();
        return false;
    }
    else if (details.cnic == "") {
        $("#cnic").css(highlighter);
        $("#cnic").focus();
        return false;
    }
    else if (details.bloodgroup == "Select a BloodGroup") {
        $("#blood_group").css(highlighter);
        $("#blood_group").focus();
        return false;
    }
    else if (details.maritalstatus == "Marital Status") {
        $("#marital_status").css(highlighter);
        $("#marital_status").focus();
        return false;
    }
    else if (details.emergencyName == "") {
        $("#e_contactName").css(highlighter);
        $("#e_contactName").focus();
        return false;
    }
    else if (details.emergencyNumber == "") {
        $("#e_contactNumber").css(highlighter);
        $("#e_contactNumber").focus();
        return false;
    }
    else if (details.medicalhistory == null) {
        $("#medical_history").css(highlighter);
        $("#medical_history").focus();
        return false;
    }
    else if (details.familyhistory == null) {
        $("#family_history").css(highlighter);
        $("#family_history").focus();
        return false;
    }
    else if (details.allergies == null) {
        $("#allergies").css(highlighter);
        $("#allergies").focus();
        return false;
    }
    else if (details.symptoms == null) {
        $("#symptoms").css(highlighter);
        $("#symptoms").focus();
        return false;
    }
    else if (details.habits == "") {
        $("#habit").css(highlighter);
        $("#habit").focus();
        return false;
    }
    else {
        var url = "http://localhost:6887/api/Update/";
        $.ajax({
            method: 'POST',
            url: url,
            dataType: 'json',
            data: details,
            success: function (data) {
                alert("DOne");
            },
            error: function (data) {
                alert("error");
            }
        });
        $("body").css("overflow", "auto");
        $('#mask').hide();
        $('.window').hide();
    }
});