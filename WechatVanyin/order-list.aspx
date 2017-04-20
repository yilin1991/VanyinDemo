<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order-list.aspx.cs" Inherits="WechatVanyin.order_list" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <title>万印网-订单列表</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" type="text/css" href="css/order.css" />
</head>

<body>

    <!--订单列表 Begin-->
    <div class="orderbody">

        <asp:Repeater runat="server" ID="RepOrderList">
            <ItemTemplate>
                <div class="orderlist">
                    
                    <div class="ordertop">
                        <span>订单编号：<%# Eval("OrderNum") %></span><span class="endstate"><%# Eval("OrderState") %></span>
                    </div>

                    <div class="orderlistbox">
                        <div class="listboxleft">
                            <p class="ordername"><span class="<%# Eval("TypeStyle") %>"><%# Eval("OrderType") %></span><%# Eval("OrderName") %></p>
                            <p class="orderdate">下单时间：<%# Eval("AddTime") %></p>
                        </div>
                        <div class="listboxright">
						<a href="<%# Eval("OrderDetail") %>">查看详情</a>
					</div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>






    </div>

    <!--订单列表 End-->

    <!--底部导航 Begin-->
    <uc1:Footer runat="server" ID="Footer" />
    <!--底部导航 End-->
</body>

</html>
