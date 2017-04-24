<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address.aspx.cs" Inherits="WechatVanyin.address" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网-收货地址</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/address.css" />
</head>

<body class="datum">
    <!--收货地址 Begin-->
    <div class="address">
        <p>管理收货地址</p>

        <asp:Repeater runat="server" ID="RepAddressList">
            <ItemTemplate>
                <div class="addresslist">
                    <ul class="addressremark">
                        <li><span><%# Eval("Name") %></span><span><%# Eval("Phone") %></span></li>
                        <li>
                            <p><%# GetCityName(Eval("City").ToString())+Eval("AddressInfo") %></p>
                        </li>
                    </ul>
                    <div class="addressedit">
                        <%--<a href="#">删除</a>--%> 
                        <a href="EditAddress.aspx?id=<%# Eval("Id") %>">编辑</a>
                       <%# BindSelect(Eval("Id").ToString()) %>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>




    </div>
    <!--收货地址 End-->

    <a href="EditAddress.aspx<%= strPmid %>" class="addaddress">添加收货地址</a>

</body>

</html>
