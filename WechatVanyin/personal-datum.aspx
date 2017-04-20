<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="personal-datum.aspx.cs" Inherits="WechatVanyin.personal_datum" %>

<%@ Register Src="~/Controls/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>


<!DOCTYPE html>
<html>

	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
		<title>万印网-个人资料</title>
		<link rel="stylesheet" type="text/css" href="css/style.css" />
		<link rel="stylesheet" type="text/css" href="css/personal.css" />
	</head>

	<body class="datum">
	

		<!--个人资料 Begin-->

		<div class="datumbox">

			<div class="datumlist">
				<span>用户名</span><span><%= model.Account %></span>
			</div>
			<div class="datumlist">
				<span>性别</span><span><%= model.Sex==0?"男":"女" %></span>
			</div>
			<div class="datumlist">
				<span>手机号</span><span><%= model.Phone %></span>
			</div>
			<div class="datumlist">
				<span>邮箱</span><span><%= string.IsNullOrEmpty( model.Email)?"未设置":model.Email %></span>
			</div>
			<div class="datumlist">
				<a href="address.aspx"><span>收货地址</span><span><img src="img/personal/home/homerightico.png"/></span></a>
			</div>

			
			

		</div>

        <a href="/Tools/QuitLogin.ashx" class="quitlogin">退出登录</a>

		<!--个人资料 End-->

		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
		<!--底部导航 End-->
	</body>

</html>
