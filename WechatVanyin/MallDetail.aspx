<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MallDetail.aspx.cs" Inherits="WechatVanyin.MallDetail" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="/css/orderdetail.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="orderdetail">

            <div class="orderdetailbox">
                <div class="orderdetailtop">
                    <p>订单基本信息</p>
                </div>
                <div class="orderdetaillist">
                    <p>订单编号：<%= modelOrder.Num %></p>
                    <p>下单时间：<%= modelOrder.Addtime %></p>
                    
                    <p>订单状态：<%= GetStateName(modelOrder.StateInfo.ToString()) %> </p>
                </div>
            </div>

            <div class="detailproduct">
                <ul class="producttop">
                    <li>
                        <img src="<%=GetFileServer(10000)+ modelMall.ImgUrl %>" /></li>
                    <li>
                        <p><%= modelMall.NameInfo %></p>
                        <p></p>
                    </li>
                    <li>
                        <p><%= modelMall.Integral %></p>
                        <p>×<%= modelOrder.OrderNum %></p>
                    </li>
                </ul>
            </div>


            <div class="orderdetailbox">
                <div class="orderdetailtop">
                    <p>联系人信息</p>
                </div>
                <div class="orderdetaillist">
                    <p>联系人：<%= modelAddress.Name %></p>
                    <p>联系电话：<%= modelAddress.Phone %></p>
                    <p>收货地址：<%= GetCityName(modelAddress.City)+modelAddress.AddressInfo %></p>
                </div>
            </div>

        </div>
        
        <asp:Button runat="server" ID="btnOk" CssClass="btnorderdetail "  OnClick="btnOk_Click" Text="确认收货" />


       <%-- 网站底部 Begin --%>
        <uc1:Footer runat="server" ID="Footer" />
        <%-- 网站底部 End --%>

    </form>
</body>
</html>
