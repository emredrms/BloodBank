var serverName = '168.63.38.132:90';
var authUser = $.cookie('blood_bank_admin');
var amp = '&';
var equal = '=';
$(document).ready(function () {
    loginControl();

});

function adjustTextAreaCounter() {

    $('.k-grid-Edit').on("click", function () {
        alert('zssddsd');
        $('#message-area').keyup(function () {
            $('#message-count').html($(this).val().length);
        });
    });

}

function getWrapperMessage() {

    $("#message-grid").kendoGrid({
        dataSource: {
            type: "json",
            transport: {
                read: {
                    url: "http://" + serverName + "/BloodServiceServiceImpl.svc/JSONRetrievePendingApprovalAnnouncement",
                    dataType: "json"
                },
                update: {
                    url: "http://" + serverName + "/BloodServiceServiceImpl.svc/JSONAddMessageByChannel/req",
                    dataType: "json"
                },
                parameterMap: function (options, operation) {
                    if (operation == "update" && options.models) {
                        var reqURL = kendo.stringify('announcementId' + equal + options.models[0].AnnouncementId + amp + 'contactIds' + equal + options.models[0].ContactIds + amp + 'messageText' + equal + options.models[0].Text + amp + 'authUser' + equal + authUser + amp + 'facebook' + equal + options.models[0].Facebook + amp + 'twitter' + equal + options.models[0].Twitter + amp + 'phone' + equal + options.models[0].Phone);
                        return reqURL.replace('"', '').replace('"', '')
                    }
                }
            },
            schema: {
                data: "JSONRetrievePendingApprovalAnnouncementResult.Announcements",
                total: "JSONRetrievePendingApprovalAnnouncementResult.TotalCount",
                model: {
                    id: "AnnouncementId",
                    fields: {
                        AnnouncementId: { editable: false, nullable: true },
                        Text: { validation: { required: true} },
                        Facebook: { type: "boolean" },
                        Twitter: { type: "boolean" },
                        Phone: { type: "boolean" },
                        Lead: { type: "boolean" }
                    }
                }
            },
            batch: true,
            pageSize: 5
        },
        sortable: true,
        pageable: true,
        detailInit: detailInit,
        columns: [
            {
                field: "AnnouncementId",
                title: "Duyuru No",
                width: "100px"
            },
            {
                field: "Text",
                title: "Duyuru Icerigi",
                editor: zipCodesEditor
            },
            {
                field: "Facebook",
                title: "Facebook",
                width: "1px"
            },
            {
                field: "Twitter",
                title: "Twitter",
                width: "1px"
            },
            {
                field: "Phone",
                title: "Telefon",
                width: "1px"
            },
            {
                field: "Lead",
                title: "Kilavuz",
                width: "1px"
            },
            {
                command: ["edit"],
                title: "&nbsp;",
                width: "150px"
            }
        ],
        editable: "popup"
    });
}

function detailInit(e) {
    $("<div/>").appendTo(e.detailCell).kendoGrid({
        dataSource: {
            type: "json",
            transport: {
                read: "http://" + serverName + "/BloodServiceServiceImpl.svc/JSONRetrieveMessageByAnnouncementId/" + e.data.AnnouncementId
            },
            schema: {
                data: "JSONRetrieveMessageByAnnouncementIdResult.messages",
                total: "JSONRetrieveMessageByAnnouncementIdResult.TotalCount"
            },
            pageSize: 4
        },
        scrollable: false,
        sortable: true,
        pageable: true,
        columns: [
                            { field: "MessageId", title: "Mesaj No", width: "110px" },
                            { field: "MessageText", title: "Icerik" },
                            { field: "Channel", title: "Kanal" },
                            {
                                field: "Send",
                                title: "Durum",
                                template: "<img src=" + "# if (Send){# " + "../../Images/ok.jpg" + "# } else {#" + "../../Images/no.jpg" + "#}# title=\"image\" height=\"24\" alt=\"image\"/>"
                            }
                        ]
    });
}

var zipCodesEditor = function (container, options) {
    $('<textarea id="message-area" data-bind="value: ' + options.field + '"></textarea>').appendTo(container);
    $('<div id="message-count" class="k-edit-field">0</div>').appendTo(container);
};