$(document).ready(function () {
    loginControl();
});

function getMessagePage() {
    $("#page-wrapper").load("Message.html");
    $(".menu-li").removeClass("selected");
    $("#message-li").addClass("selected");
    setTimeout('getWrapperMessage()', 1000);
   // setTimeout('adjustTextAreaCounter()', 2000);
}

function getDashboard() {
    $("#page-wrapper").load("Dashboard.html");
    $(".menu-li").removeClass("selected");
    $("#dashboard-li").addClass("selected");
}

function getContentPage() {
    $("#page-wrapper").load("Content.html");
    $(".menu-li").removeClass("selected");
    $("#content-li").addClass("selected");
    setTimeout('getValidContentType()', 500);
    setTimeout('setHTMLeditor()', 500);
}