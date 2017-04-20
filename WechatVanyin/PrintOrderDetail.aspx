<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOrderDetail.aspx.cs" Inherits="WechatVanyin.PrintOrderDetail" %>

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
                    <p>订单编号：<%= model.NumId %></p>
                    <p>下单时间：<%= model.AddTime %></p>
                    <p>印刷类别：<%= GetCategoryName(model.TypeId) %></p>
                    <p>印刷数量：<%= model.PrintNum %></p>
                    <p>订单状态：<%= GetStateName(model.StateInfo.ToString()) %> </p>
                </div>
            </div>

       

            <div class="orderdetailbox">
                <div class="orderdetailtop">
                    <p>联系人信息</p>
                </div>
                <div class="orderdetaillist">
                    <p>联系人：<%= model.NameInfo %></p>
                    <p>联系电话：<%= model.Phone %></p>
                    <p>联系邮箱：<%= model.Email==""?"未填写":model.Email %></p>
                </div>
            </div>

        </div>
        
        <asp:Button runat="server" ID="btnOk" CssClass="btnorderdetail"  Text="确认完成"  OnClick="btnOk_Click" />


       <%-- 网站底部 Begin --%>
        <uc1:Footer runat="server" ID="Footer" />
        <%-- 网站底部 End --%>

    </form>
</body>
</html>


