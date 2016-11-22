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
    //ALways check the scope of the function...
    // if you write the code here... to Email keh blur execute hoga..
});//is it okay?


//yahan se start kero..ok i though i was out of this function..

//$("#password").blur(function () {

//    //var pass = $("#password").val();
//    if ($("#password").filter(function () {
//        return this.value.match(/^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])([a-zA-Z0-9]{8})$/);
//    })) {
//        $("div").text("pass");
//    } else {
//        $("div").text("fail");
//    }
//});

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