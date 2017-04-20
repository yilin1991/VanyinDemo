<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-home.aspx.cs" Inherits="WechatVanyin.integral_home" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/integral.css" />
    <link href="../css/weChatStyle.css" rel="stylesheet" />
</head>

<body>


    <!--积分商城 Begin-->
    <div class="integralhome">

        <!--积分商城顶部 Begin-->
        <div class="integraltop">
            <div class="integraltop_detail">
                <img src="img/integral/home/headerimg.jpg" />
                <span>15021952423</span>
                <a href="integral-detailed.aspx">积分明细</a>
            </div>
            <div class="integraltop_num">
                <p>可用积分<span>1000</span></p>
                <p>总积分<span>500</span></p>
            </div>

        </div>
        <!--积分商城顶部 End-->

        <!--积分兑换列表 Begin-->
        <div class="integrashop">
           <%-- <div class="integrashop_top">
                <span>积分范围</span>
                <select>
                    <option value="0">0-1000</option>
                </select>
            </div>--%>

            <div class="integrashop_box">


                <asp:Repeater runat="server" ID="RepMallList">
                    <ItemTemplate>
                        <div class="integrashop_list">
                            <div class="integrashop_img">
                                <img src="<%#GetFileServer(10000)+ Eval("ImgUrl") %>" />
                            </div>
                            <p class="shopname"><%# Eval("NameInfo") %></p>
                            <div class="shopnumbtn">
                                <span><%# Eval("Integral") %>积分</span>
                                <a class="btnexchange">兑换</a>
                                <input type="hidden" name="hidId" value="<%# Eval("Id") %>" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>




            </div>


        </div>
        <!--积分兑换列表 End-->


    </div>
    <!--积分商城 End-->

    <!--底部导航 Begin-->
    <uc1:Footer runat="server" ID="Footer" />
    <!--底部导航 End-->
    <script src="../js/jquery-1.11.1.min.js"></script>
    <script src="../js/weChatMsg.js"></script>
    <script>

        $(function () {

            $(".btnexchange").click(function () {

                var tid = $(this).parents(".integrashop_list").find("input[name=hidId]").val();
           

                $.ajax({
                    type: "POST",
                    url: "/Tools/CheckIntegra.ashx",
                    data: { pmid: tid },
                    dataType: "json",
                    success: function (data) {

                        if (data.state == "success") {
                            location.href = "integral-order.aspx?pmid=" + tid;
                        }
                        else {
                            wechatMsg("提示信息", data.msg);
                        }

                    }
                });
               
              
            })



        })

    </script>
    
</body>

</html>
