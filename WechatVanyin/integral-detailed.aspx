<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="integral-detailed.aspx.cs" Inherits="WechatVanyin.integral_detailed" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网-积分明细</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/integral.css" />
</head>

<body>

    <!--积分明细 Begin-->
    <div class="integraldetailed">
        <ul class="detailedtop">
            <li>
                <p><%= GetUsableIntegral(Vanyin.Common.Utils.GetCookie("MemberId")) %></p>
                <p>可用积分</p>
            </li>
            <li>
                <p><%= GetCountIntegral(Vanyin.Common.Utils.GetCookie("MemberId")) %></p>
                <p>总积分</p>
            </li>
        </ul>
        <p class="detailedtitle">收支明细</p>

        <asp:Repeater runat="server" ID="RepIntegral">
            <ItemTemplate>
                <div class="detailedlist">
                    <p><span>订单号 <%# Eval("Identifier") %></span><span><%# Eval("Num") %></span></p>
                    <p><span><%# GetCategoryName(int.Parse(Eval("TypeId").ToString())) %></span><span><%# Convert.ToDateTime(Eval("AddTime").ToString()).ToString("yyyy-MM-dd") %></span></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>



    </div>
    <!--积分明细 End-->
    <!--底部导航 Begin-->
    <uc1:Footer runat="server" ID="Footer" />

    <!--底部导航 End-->
</body>

</html>
