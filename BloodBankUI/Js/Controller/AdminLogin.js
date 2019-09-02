var serverName = '168.63.38.132:90';

$(document).ready(function () {
    $('#login-button').click(function () {
        if (validateInputs()) {
            loginSystem($('#name').val(), $('#password').val());
        }
        return false;
    });


});

function sessionControl() {
    if (!(typeof ($.cookie('blood_bank_user')) === "undefined") && $.cookie('blood_bank_user') == $.cookie('blood_bank_admin')) {
        $('#name').val($.cookie('blood_bank_admin'));
        $('#password').val($.cookie('blood_bank_password'));
    }
}

function loginSystem(username, password) {
    $('body').loadingIndicator();
    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONLoginSystem/' + username + "/" + password,
        success: function (data) {
            $.each(data, function (key, value) {
                if (value) {
                    getUserByUserName(username,password);
                }
                else {
                    $.dialog.alert('', 'Girmis oldugunuz bilgiler sistemimizde kayitli degildir', function () {
                        $.dialog.alert("Sonuc", "");
                    });
                    setTimeout("$.dialog._hide('popup_container_alert', 'overflow_alert')", 5000);
                }
            });
        },
        error: function (data) {

        },
        complete: function (data) {

        }
    });
}

function getUserByUserName(username,password) {
    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONgetUserByUsername/' + username,
        success: function (data) {
            $.each(data, function (key, value) {
                $.removeCookie('blood_bank_user');
                $.removeCookie('blood_bank_admin');
                $.removeCookie('blood_bank_name');
                $.removeCookie('blood_bank_surname');
                $.removeCookie('blood_bank_password');
                if ($('#rememeber-me').is(':checked')) {
                    $.cookie('blood_bank_user', username, { expires: 365 });
                    $.cookie('blood_bank_admin', username, { expires: 365 });
                    $.cookie('blood_bank_name', value.Name, { expires: 365 });
                    $.cookie('blood_bank_surname', value.Surname, { expires: 365 });
                    $.cookie('blood_bank_password', password, { expires: 365 });
                }
                else {
                    $.cookie('blood_bank_user', username, { expires: 1 });
                    $.cookie('blood_bank_admin', username, { expires: 1 });
                    $.cookie('blood_bank_name', value.Name, { expires: 1 });
                    $.cookie('blood_bank_surname', value.Surname, { expires: 1 });
                    $.cookie('blood_bank_password', password, { expires: 1 });

                }
                window.location = "../../Admin/Index.html";
            });
        },
        error: function (data) {

        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function signOut() {
    $.removeCookie('blood_bank_user');
    $.removeCookie('blood_bank_admin');
    $.removeCookie('blood_bank_name');
    $.removeCookie('blood_bank_surname');
    window.location = "../../Index.html"
}
function validateInputs() {

    var validForm = true;
    if ($('#name').val() == null || $('#name').val() == "") {
        validForm = false;
        $("#user-name-validation").show();
    }
    else {
        $("#user-name-validation").hide();
    }
    if ($('#password').val() == null || $('#password').val() == "") {
        validForm = false;
        $("#password-validation").show();
    }
    else {
        $("#password-validation").hide();
    }
    return validForm;
}