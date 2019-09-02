var serverName = '168.63.38.132:90';

$(document).ready(function () {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        if (i == 0) {
            getContentById(hash[1]);
        }
    }
});

function getContentById(contentId) {

    $('body').loadingIndicator();
    $.ajax({
        url: 'http://' + serverName + '/BloodServiceServiceImpl.svc/JSONgetContentById/' + contentId,
        success: function (data) {
            $.each(data, function (key, value) {
                $('#title').html(value.Title);
                $('#html-content').html(value.ContentText);
                $('.main-menu').removeClass('current-menu-item');
                $('.main-menu').each(function () {
                    if ($(this).attr('data-id') == value.ContentId) {
                        $(this).addClass('current-menu-item');
                    }
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