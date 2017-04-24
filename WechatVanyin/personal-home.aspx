<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="personal-home.aspx.cs" Inherits="WechatVanyin.personal_home" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
		<title>万印网-个人中心</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/personal.css" />
	</head>

	<body>
	

		<!--个人中心 Begin-->

		<div class="perhome">

			<!--头部图片 Begin-->
			<div class="perhometop">
				<img src="img/personal/home/topimg.jpg" />
			</div>
			<!--头部图片 End-->

			<div class="perhomeheader">
				<!--头像及用户名 Begin-->
				<a href="#"><img src="img/personal/home/headerimg.jpg" /></a>
				<p><%=model.Phone %></p>
			</div>
			<!--头像及用户名 End-->

			<!--个人中心链接 Begin-->
			<div class="perhomelink">
				<a href="order-list.aspx">
					<span class="linkico"><img src="img/personal/home/homeico1.png"/></span>
					<span class="linkname">我的订单</span>
					<span class="linkright"><img src="img/personal/home/homerightico.png"/></span>
				</a>
				<a href="personal-datum.aspx">
					<span class="linkico"><img src="img/personal/home/homeico2.png"/></span>
					<span class="linkname">我的资料</span>
					<span class="linkright"><img src="img/personal/home/homerightico.png"/></span>
				</a>
				<a href="integral-home.aspx">
					<span class="linkico"><img src="img/personal/home/homeico3.png"/></span>
					<span class="linkname">我的积分</span>
					<span class="linknum"><%= GetUsableIntegral(Vanyin.Common.Utils.GetCookie("MemberId")) %>分</span>
					<span class="linkright"><img src="img/personal/home/homerightico.png"/></span>
				</a>
				<a href="#">
					<span class="linkico"><img src="img/personal/home/homeico4.png"/></span>
					<span class="linkname">了解万印</span>
					<span class="linkright"><img src="img/personal/home/homerightico.png"/></span>
				</a>
			</div>
			<!--个人中心链接 End-->
			
			<div class="perhometel">
				<span>咨询电话</span>
				<img src="img/personal/home/hometelico.png"/>
				<a href="tel:021-50110509">021-50110509</a>
			</div>
			
			
		</div>

		<!--个人中心 End-->

		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
		<!--底部导航 End-->
	</body>

</html>
