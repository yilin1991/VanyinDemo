<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="design-template.aspx.cs" Inherits="WechatVanyin.design_template" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/designtemplate.css" />
</head>

<body>

    <div class="template">

        <div class="templatetop">
            <p>选择设计模板</p>
        </div>

        <div class="templatelist">

            <asp:Repeater runat="server" ID="repTemplate">
                <ItemTemplate>
                    <div class="templateli">
                        <div class="templateimg">
                            <img src="<%#GetFileServer(10000)+ Eval("ImgUrl") %>" />
                            <input type="hidden" id="hidTemId" value="<%# Eval("Id") %>" />
                        </div>
                        <div class="templatetext">
                            <p><%#Eval("Title") %></p>
                            <p>
                                <span>高端</span>
                                <span>直角</span>
                                <span>圆角</span>
                                <span>企业</span>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>





        </div>

    </div>

    <div class="showtemplate">

        <div class="showtemplatebox">
            <div class="showtemimg">
                <img src="img/design/designtemimg.png" />
            </div>
            <div class="showtemtext">
                <p>简约精品商务名片简约精品商务名片简约精品商务名片简约精品商务名片</p>
                <div class="showtemtextbox">
                    <a class="collection">
                        <p>收藏</p>
                    </a>
                    <a class="selecttemplate" href="design.aspx<%= Request.Url.Query %>" >
                        <p>选择此款</p>
                    </a>
                </div>

            </div>

        </div>

        <a class="closetemplate">
            <img src="img/design/closeshowtemplate.png" /></a>
    </div>

    <script src="/js/jquery-1.11.1.min.js"></script>
    <script>
        $(function () {

            $(".templateli").click(function () {

                var temId = $(this).find("input[type=hidden]").val();
                $.ajax({
                    type: "POST",
                    url: "/Tools/GetTemplateDetail.ashx",
                    data: { temId: temId },
                    dataType: "json",
                    success: function (data) {
                       
                        $(".selecttemplate").attr("href", $(".selecttemplate").attr("href") + "&temid=" + temId);

                        $(".showtemplate").find(".showtemimg img").attr("src", data.imgurl);
                        $(".showtemplate").find(".showtemtext > p").text(data.title);
                        $(".showtemplate").css("z-index","999").stop().delay(200).animate({ "opacity": "1" }, 500);

                       
                    }
                });

               

            })


            $(".closetemplate").click(function () {
                $(".showtemplate").stop().animate({ "opacity": "0" }, 500, function () {
                    $(".showtemplate").css("z-index", "0")
                });

            })



        })

    </script>



</body>

</html>
