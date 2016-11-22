var value = document.cookie;
var cookie = value.substr(5);
$(document).ready(function () {
    var PatientDoctor = {};
    PatientDoctor.Id = cookie;
    PatientDoctor.Type = "Doc";
    $.ajax({
        method: 'POST',
        url: "http://localhost:6887/api/PatDoc/",
        dataType: 'json',
        data: PatientDoctor,
        success: function (data) {
            var records = JSON.parse(data);
            if (records == false) {
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
            else
            {
                //$("#hospitalNameView").val = records[0].hopitalName;
                //$("#contactNumberView").val = records[0].contactNumber;
                //$("#specialityView").val = records[0].speciality;
                //$("#qualificationView").val = records[0].qualification;
                document.getElementById("genderView").innerHTML = records[0].gender;
                document.getElementById("dobView").innerHTML = records[0].dob;
                document.getElementById("locationView").innerHTML = records[0].city + ", " + records[0].country;
                document.getElementById("emailView").innerHTML = records[0].email;
                document.getElementById("hospitalNameView").innerHTML = records[0].hopitalName;
                document.getElementById("contactNumberView").innerHTML = records[0].contactNumber;
                document.getElementById("specialityView").innerHTML = records[0].speciality;
                document.getElementById("qualificationView").innerHTML = records[0].qualification;

            }
        },
        error: function (data) {
            alert("error");
        }
    });
});


$("#okay").click(function () {
    var DoctorUpdate = {};
    DoctorUpdate.HospitalName = $("#hospitalName").val();
    DoctorUpdate.ContactNumber = $("#cellPhone").val();
    DoctorUpdate.Speciality = $("#speciality").val();
    DoctorUpdate.Qualification = $("#qualification").val();
    DoctorUpdate.UserId = cookie;

    if(DoctorUpdate.HospitalName == "")
    {
        toastr.warning("Hospital name cannot be left blank.");
        $("#hospitalName").focus();
        return false;
    }
    else if(DoctorUpdate.ContactNumber == "")
    {
        toastr.warning("Contact number cannot be left blank.");
        $("#cellPhone").focus();
        return false;
    }
    else if(DoctorUpdate.Speciality == "")
    {
        toastr.warning("Speciality cannot be left blank.");
        $("#speciality").focus();
        return false;
    }
    else if(DoctorUpdate.Qualification == 0)
    {
        toastr.warning("Please select your Qualifications");
        $("#qualification").focus();
        return false;
    }
    else
    {
        var url = "http://localhost:6887/api/DoctorUpdate/";
        $.ajax({
            method: 'POST',
            url: url,
            dataType: 'text',
            data: DoctorUpdate,
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
})