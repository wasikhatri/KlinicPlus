
$("#country").change(function () {
    var Country = {};
    Country.CountryName = $("#country").val();
    var url = "http://localhost:6887/api/GetCities/";
    var option = [];
    $.ajax({
        method: 'POST',
        url: url,
        dataType: 'json',
        data: Country,
        success: function (data) {
            var array = JSON.parse(data);
            //console.log(array);
            for (var i = 0; i < array.length; i++) {
                option.push('<option value="' + array[i] + '">' + array[i] + '</option>');
            }
            $("#city").html(option.join(''));
        },
        error: function (data) {//status is Error and the errorThrown is undefined
            alert();
        }
    });
});

$("#submitLogin").click(function () {
    if (($("#email").val() == "")) {
        toastr.error("Email cannot be left blank.");
        $("#email").focus();
        return false;
    }
    else if ($("#password").val() == "") {
        toastr.error("Password cannot be left blank.");
        $("#password").focus();
        return false;
    }
});


$("#emailReg").blur(function () {
    var url = "http://localhost:6887/api/VerifyEmail/";
    var VerifyEmail = {};
    VerifyEmail.Email = $("#email").val();
    $.ajax({
        method: 'POST',
        url: url,
        dataType: 'text',
        data: VerifyEmail,
        success: function (data) {
            if (data == "false") {
                toastr.warning("Email not available");
            }
        },
        error: function (data) {
            alert("false");
        }
    });
});


$("#btnRegister").click(function () {
    if ($("#emailReg").val() == "") {
        toastr.error("email cannot be left blank");
        $("#email").focus();
        return false;
    }
     else   if ($("#passwordReg").val() == "") {
            toastr.error("password cannot be left blank");
            $("#password").focus();
        return false;
        }
    
     else if ($("#type").val() == 0) {
            toastr.error("please select account type");
            $("#type").focus();
            return false;
     }
     else if ($("#txtFname").val() == "") {
         toastr.error("please enter your first name");
         $("#txtFname").focus();
         return false;
     }
     else if ($("#txtLname").val() == "") {
         toastr.error("please enter your last name");
         $("#txtLname").focus();
         return false;
     }
     else if ($("#gender").val() == 0) {
         toastr.error("please select gender");
         $("#gender").focus();
         return false;
     }
    
     else if ($("#gender").val() == 0) {
                toastr.error("please select gender");
                $("#gender").focus();
                return false;
            }
    
     else if ($("#dob").val() == "") {
                    toastr.error("please select Date of Birth");
                    $("#dob").focus();
                    return false;
                }
    
     else if ($("#country").val() == 0) {
                        toastr.error("please select country");
                        $("#country").focus();
                        return false;
                    }
                    
     else if ($("#city").val() == 0) {
                            toastr.error("please select city");
                            $("#city").focus();
                            return false;
                        }
});



$("#forgot").click(function () {
    var id = '#dialog';
    //Get the screen height and width
    var maskHeight = "  100%";
    var maskWidth = "100%";

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
    $(id).css("overflow", "hidden");
});