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
		<!--头部 Begin-->
		<div id="header">
			<p class="title">万印网</p>
			<a class="backbtn"><img src="img/header/backico.png" /></a>
		</div>
		<!--头部 End-->

		<!--个人资料 Begin-->

		<div class="datumbox">

			<div class="datumlist">
				<span>用户名</span><span>15000331415</span>
			</div>
			<div class="datumlist">
				<span>性别</span><span>未设置</span>
			</div>
			<div class="datumlist">
				<span>手机号</span><span>15000331415</span>
			</div>
			<div class="datumlist">
				<span>邮箱</span><span>未设置</span>
			</div>
			<div class="datumlist">
				<span>收货地址</span><span><img src="img/personal/home/homerightico.png"/></span>
			</div>

			
			
		</div>

		<!--个人资料 End-->

		<!--底部导航 Begin-->
        <uc1:Footer runat="server" ID="Footer" />
		<!--底部导航 End-->
	</body>

</html>
