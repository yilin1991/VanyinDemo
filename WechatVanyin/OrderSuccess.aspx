<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSuccess.aspx.cs" Inherits="WechatVanyin.OrderSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网首页</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="successbox">
            <img class="successimg" src="../img/ico/successico.png" />
            <p class="p1">提交成功</p>
            <p class="p2">您的订单号为：<span><%= orderNum %></span></p>
            <p class="p3">
                您的需求已提交成功，
            </p>
            <p class="p3">
                万印网客服人员会于2小时内与您取得联系。
            </p>
            <a href="index.aspx">返回首页</a>
            <a href="<%= orderDetail %>" class="detailorder">查看订单</a>
        </div>
    </form>
</body>
</html>
