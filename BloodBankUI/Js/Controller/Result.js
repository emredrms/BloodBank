var serverName = '168.63.38.132:90';

$(document).ready(function () {
    adjustData();
    $('#phone').mask('(999)-999-99-99');
    $('#send-message').click(function () {
        if (validateMessageInputs()) {
            updateAnnouncement($('#announcementId').val(), $('#message-content').html());
        }
        return false;
    });

    $('#preview-message').click(function () {
        if (validateMessageInputs()) {
            $('.box').slideDown("slow");
        }
        return false;
    });
});

function adjustData() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        if (i == 0) {
            $('#result-count').html(hash[1]);
        }
        else if (i == 1) {
            $('#announcementId').val(hash[1]);
        }
        else if (i == 2) {
            $('#blooad-group').val(hash[1]);
        }
    }
}

function updateAnnouncement(announcementId, text) {
    $('body').loadingIndicator();
    $.ajax({
        url: 'http://'+serverName+'/BloodServiceServiceImpl.svc/JSONUpdateAnnouncement/' + announcementId + '/' + text,
        success: function (data) {
            $.dialog.alert('', 'Mesajiniz gonderildi', function () {
                $.dialog.alert("Sonuc", "");
            });
            setTimeout("$.dialog._hide('popup_container_alert', 'overflow_alert')", 5000);
        },
        error: function (data) {
            $.dialog.alert('', 'Islem sirasinda hata meydana geldi', function () {
                $.dialog.alert("Sonuc", "");
            });
            setTimeout("$.dialog._hide('popup_container_alert', 'overflow_alert')", 5000);
        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
            $('#preview-message').hide();
            $('#send-message').hide();
        }
    });
}

function validateMessageInputs() {

    var validForm = true;

    if ($('#name').val() == null || $('#name').val() == "") {
        validForm = false;
        $("#name-validation").fadeIn("slow");
    }
    else {
        $("#name-validation").fadeOut("slow");
    }
    if ($('#surname').val() == null || $('#surname').val() == "") {
        validForm = false;
        $("#surname-validation").fadeIn("slow");
    }
    else {
        $("#surname-validation").fadeOut("slow");
    }
    if ($('#phone').val() == null || $('#phone').val() == "") {
        validForm = false;
        $("#phone-validation").fadeIn("slow");
    }
    else {
        $("#phone-validation").fadeOut("slow");
    }
    if ($('#sick-name').val() == null || $('#sick-name').val() == "") {
        validForm = false;
        $("#sick-validation").fadeIn("slow");
    }
    else {
        $("#sick-validation").fadeOut("slow");
    }
    if ($('#hospital-name').val() == null || $('#hospital-name').val() == "") {
        validForm = false;
        $("#hospital-validation").fadeIn("slow");
    }
    else {
        $("#hospital-validation").fadeOut("slow");
    }
    return validForm;
}