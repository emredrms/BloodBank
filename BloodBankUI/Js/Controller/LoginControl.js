function loginControl() {
    if (typeof($.cookie('blood_bank_user')) === "undefined") {
        window.location = "../../Admin/Login.html";
    }
    else {
        if ($.cookie('blood_bank_user') != $.cookie('blood_bank_admin')) {
            window.location = "../../Admin/Login.html";
        }
        else {
            $('#user-name').text($.cookie('blood_bank_name'));
            $('#user-surname').text($.cookie('blood_bank_surname'));
        }
    }
}