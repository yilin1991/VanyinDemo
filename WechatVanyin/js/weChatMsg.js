/// <reference path="jquery-1.11.1.min.js" />


function wechatMsg(title, content) {


    var strHtml = "<div class=\"wechatmsgbody\">";
    strHtml += "<div class=\"wechatmsgbox\">";
    strHtml += "<p class=\"wechatmsgtitle\">"+title+"</p>";
    strHtml += " <p class=\"wechatmsgcontent\">"+content+"</p>";
    strHtml += " <a class=\"wechatmsgbtnOK\" onclick=\"wechatClose()\">确定</a>";
    strHtml += "</div>";
    strHtml += "</div>";


    $(".wechatmsgbody").height($(window).height());

    $("body").append(strHtml);
    
    $(".wechatmsgbody").animate({ "opacity": "1" }, 300);

}





function wechatClose() {

    $(".wechatmsgbody").animate({ "opacity": "0" }, 300, function () {

        $(".wechatmsgbody").remove();

    });


}

