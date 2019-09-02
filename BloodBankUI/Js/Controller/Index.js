var alertX = null;
var serverName = '168.63.38.132:90';
var geoServerName = '168.63.38.132:81';
$(document).ready(function () {

    $('#phone').mask('(999)-999-99-99');
    getCityByCountryCode('90');

    var alertX = $.dialog.alert;

    $('.slider-control').click(function () {
        $('.slider-control').removeClass('active');
        $(this).addClass('active');

        $('.slider-content').css('display', 'none');
        $('.slider-content').css('opacity', '0');

        var index = $('.slider-control').index(this);

        $('.slider-content').eq(index).css('display', 'block');
        $('.slider-content').eq(index).css('opacity', '1');
    });

    $('#city').change(function () {
        $('#city-span').text($("#city option:selected").text());
        if ($(this).val() != '') {
            getDistrictByCityCode($(this).val());
        }
    });

    $('#district').change(function () {
        $('#district-span').text($("#district option:selected").text());
    });

    $('#blood').change(function () {
        $('#blood-span').text($("#blood option:selected").text());
    });

    $('#gender').change(function () {
        $('#gender-span').text($("#gender option:selected").text());
    });

    $('#register-blood').change(function () {
        $('#register-blood-span').text($("#register-blood option:selected").text());
    });

    $('#register-gender').change(function () {
        $('#register-gender-span').text($("#register-gender option:selected").text());
    });

    $('#register-city').change(function () {
        $('#register-city-span').text($("#register-city option:selected").text());
        if ($(this).val() != '') {
            getRegisterDistrictByCityCode($(this).val());
        }
    });

    $('#register-district').change(function () {
        $('#register-district-span').text($("#register-district option:selected").text());
    });

    $('#mail').change(function () {
        if (!validEmailAddress($(this).val())) {
            $('#mail-column-validation').html("Gecerli bir e-posta adresi giriniz");
            $("#mail-column-validation").fadeIn("slow");
        }
        else {
            avaliableEmail($(this).val());
        }
    });

    $('#enquiry-button').click(function () {
        if (validateInputs()) {
            retrieveContacBySearchCriteriaResult($('#city').val(), $('#district').val(), $('#blood').val(), $('#gender').val());
        }
        return false;
    });

    $('#register-button').click(function () {
        if (validateRegisterInputs()) {
            addContact($('#name').val(), $('#surname').val(), $('#mail').val(), $('#phone').val().replace("(", "").replace(")", "").replace("-", "").replace("-", "").replace("-", ""), "null", $('#register-blood').val(), $('#register-gender').val(), $('#register-city').val(), $("#register-city option:selected").text(), $('#register-district').val(), $("#register-district option:selected").text());
        }
        return false;
    });
});

function getCityByCountryCode(countryCode) {
    $('body').loadingIndicator();
    $('#city').find('option').remove();
    $('#register-city').find('option').remove();
    $.ajax({
        url: 'http://'+geoServerName+'/GeoServiceEnquiryServiceImpl.svc/JSONCityByCountryCodeEnquiry/' + countryCode,
        success: function (data) {
            $('#city').append("<option></option>");
            $('#register-city').append("<option></option>");
            $.each(data, function (key, value) {
                $.each(value, function (objectKey, objectValue) {
                    $('#city').append("<option value=\"" + objectValue.CityCode + "\">" + objectValue.CityName + "</option>");
                    $('#register-city').append("<option value=\"" + objectValue.CityCode + "\">" + objectValue.CityName + "</option>");
                });

            });
        },
        error: function (data) {

        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function getDistrictByCityCode(cityCode) {
    $('.loading-indicator-wrapper').show();
    $('#district').find('option').remove();
    $.ajax({
        url: 'http://'+geoServerName+'/GeoServiceEnquiryServiceImpl.svc/JSONDistrictListByCityCodeEnquiry/' + cityCode,
        success: function (data) {
            $('#district-span').text('Seciniz');
            $('#district').append("<option></option>");
            $.each(data, function (key, value) {
                $.each(value, function (objectKey, objectValue) {
                    $('#district').append("<option value=\"" + objectValue.DistrictCode + "\">" + objectValue.DistrictName + "</option>");
                });

            });
        },
        error: function (data) {

        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function getRegisterDistrictByCityCode(cityCode) {
    $('.loading-indicator-wrapper').show();
    $('#register-district').find('option').remove();
    $.ajax({
        url: 'http://'+geoServerName+'/GeoServiceEnquiryServiceImpl.svc/JSONDistrictListByCityCodeEnquiry/' + cityCode,
        success: function (data) {
            $('#register-district-span').text('Seciniz');
            $('#register-district').append("<option></option>");
            $.each(data, function (key, value) {
                $.each(value, function (objectKey, objectValue) {
                    $('#register-district').append("<option value=\"" + objectValue.DistrictCode + "\">" + objectValue.DistrictName + "</option>");
                });

            });
        },
        error: function (data) {

        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function avaliableEmail(email) {
    $('.loading-indicator-wrapper').show();
    $.ajax({
        url: 'http://'+serverName+'/BloodServiceServiceImpl.svc/JSONAvaliableEmail/' + email,
        success: function (data) {
            $.each(data, function (key, value) {
                if (!value) {
                    $('#mail-column-validation').html("Girmis oldugunuz e-posta adresi kullanilmaktadir");
                    $("#mail-column-validation").fadeIn("slow");
                }
                else {
                    $("#mail-column-validation").fadeOut("slow");
                    $('#mail-column-validation').html("E-posta zorunludur");
                }
            });
        },
        error: function (data) {
            return false;
        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function addContact(name, surname, email, phone, otherPhone, bloodGroup, gender, cityCode, cityName, districtCode, districtName) {
    $('.loading-indicator-wrapper').show();
    $.ajax({
        url: 'http://'+serverName+'/BloodServiceServiceImpl.svc/JSONAddContact/' + name + '/' + surname + '/' + email + '/' + phone + '/' + otherPhone + '/' + bloodGroup + '/' + gender + '/' + cityCode + '/' + cityName + '/' + districtCode + '/' + districtName,
        success: function (data) {
            $.dialog.alert('', 'Kayit islemi basarili bir sekilde gerceklesti', function () {
                $.dialog.alert("Sonuc", "");
            });
            clearRegisterForm();
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
        }
    });
}

function retrieveContacBySearchCriteriaResult(cityCode, districtCode, bloodGroup, gender) {
    $('.loading-indicator-wrapper').show();
    $.ajax({
        url: 'http://'+serverName+'/BloodServiceServiceImpl.svc/JSONRetrieveContacBySearchCriteriaResult/' + cityCode + '/' + districtCode + '/' + bloodGroup + '/' + gender,
        success: function (data) {
            $.each(data, function (key, value) {
                if (parseInt(value.Count) > 0) {
                    window.location = "../../Result.html?count=" + value.Count + '&announcementId=' + value.AnnouncementId + '&bloodGroup=' + bloodGroup;
                }
                else {
                    $.dialog.alert('', 'Aradiginiz kriterlere uygun sonuc bulunamamistir', function () {
                        $.dialog.alert("Sonuc", "");
                    });
                    setTimeout("$.dialog._hide('popup_container_alert', 'overflow_alert')", 5000);
                }
            });
        },

        error: function (data) {
            $.dialog.alert('', 'Islem sirasinda hata meydana geldi', function () {
                $.dialog.alert("Sonuc", "");
            });
            setTimeout("$.dialog._hide('popup_container_alert', 'overflow_alert')", 5000);
            return false;
        },
        complete: function (data) {
            $('.loading-indicator-wrapper').hide();
        }
    });
}

function clearRegisterForm() {
    $('#mail').val('');
    $('#register-blood-span').text('Seciniz');
    $('#register-blood').val('0');
    $('#register-gender-span').text('Seciniz');
    $('#register-gender').val('0');
    $('#name').val('');
    $('#surname').val('');
    $('#register-city-span').text('Seciniz');
    $('#register-city').val('0');
    $('#register-district-span').text('Seciniz');
    $('#register-district').val('0');
    $('#phone').val('');
}

function validateInputs() {

    var validForm = true;
    if ($('#city').val() == null || $('#city').val() == "") {
        validForm = false;
        $("#city-column-validation").fadeIn("slow");
    }
    else {
        $("#city-column-validation").fadeOut("slow");
    }
    if ($('#district').val() == null || $('#district').val() == "") {
        validForm = false;
        $("#district-column-validation").fadeIn("slow");
    }
    else {
        $("#district-column-validation").fadeOut("slow");
    }
    if ($('#blood').val() == null || $('#blood').val() == "") {
        validForm = false;
        $("#blood-column-validation").fadeIn("slow");
    }
    else {
        $("#blood-column-validation").fadeOut("slow");
    }
    return validForm;

}

function validateRegisterInputs() {
    var validForm = true;
    if ($('#mail').val() == null || $('#mail').val() == "") {
        $("#mail-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#mail-column-validation").fadeOut("slow");
    }
    if ($('#register-blood').val() == null || $('#register-blood').val() == "") {
        $("#register-blood-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#register-blood-column-validation").fadeOut("slow");
    }
    if ($('#register-gender').val() == null || $('#register-gender').val() == "") {
        $("#register-gender-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#register-gender-column-validation").fadeOut("slow");
    }
    if ($('#name').val() == null || $('#name').val() == "") {
        $("#name-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#name-column-validation").fadeOut("slow");
    }
    if ($('#surname').val() == null || $('#surname').val() == "") {
        $("#surname-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#surname-column-validation").fadeOut("slow");
    }
    if ($('#register-city').val() == null || $('#register-city').val() == "") {
        $("#register-city-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#register-city-column-validation").fadeOut("slow");
    }
    if ($('#register-district').val() == null || $('#register-district').val() == "") {
        $("#register-district-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#register-district-column-validation").fadeOut("slow");
    }
    if ($('#phone').val() == null || $('#phone').val() == "") {
        $("#phone-column-validation").fadeIn("slow");
        validForm = false;
    }
    else {
        $("#phone-column-validation").fadeOut("slow");
    }
    return validForm;
}

function validEmailAddress(emailAddress) {
    var pattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
    return pattern.test(emailAddress);
};