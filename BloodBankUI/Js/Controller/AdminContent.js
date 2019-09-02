var serverName = '168.63.38.132:90';
var editor = "";
var contentList = null;
$(document).ready(function () {
    loginControl();
    setTimeout('getValidContentType()', 500);
    setTimeout('setHTMLeditor()', 500);

});

function setHTMLeditor() {

    $("#editor").kendoEditor();
    editor = $("#editor").data("kendoEditor");

    $('#title').change(function () {
        $.each(contentList, function (key, value) {

            if (value.ContentId == $('option:selected', $('#title')).attr('id')) {
                editor.value(value.ContentText);
            }
        });
    });

    $('#save').click(function () {
        updateContent($('option:selected', $('#title')).attr('id'), editor.value());
        return false;
    });

}

function getValidContentType() {

    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONgetValidContentType',
        success: function (data) {
            $('#content-type').find('option').remove();
            var counter = 0;
            $.each(data, function (key, value) {
                $.each(value, function (objectKey, objectValue) {
                    $('#content-type').append("<option value=\"" + objectValue.TypeCode + "\">" + objectValue.TypeName + "</option>");
                    if (counter == 0) {
                        getContentByTypeCode(objectValue.TypeCode);
                    }
                    counter++;
                });

            });
        },
        error: function (data) {

        },
        complete: function (data) {

        }
    });
}

function getContentByTypeCode(typeCode) {

    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONgetContentByContentTypeCode/' + typeCode,
        success: function (data) {
            $('#title').find('option').remove();
            var counter = 0;
            $.each(data, function (key, value) {
                $.each(value, function (objectKey, objectValue) {
                    $('#title').append("<option id=\"" + objectValue.ContentId + "\" valid=\"" + objectValue.Valid + "\">" + objectValue.Title + "</option>");
                    if (counter == 0) {
                        editor.value(objectValue.ContentText);
                    }
                    counter++;
                });
                contentList = value;
            });
        },
        error: function (data) {

        },
        complete: function (data) {

        }
    });
}

function updateContent(contentId, text) {

    $('body').loadingIndicator();
    $('.loading-indicator-wrapper').show();
    var switchChar = '|';
    text = text.split('/').join(switchChar);

    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONUpdateContentById/' + contentId + '/' + text,
        success: function (data) {
            $.dialog.alert('', 'Islem Basarili', function () {
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
        }
    });
}